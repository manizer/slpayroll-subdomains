using static Data.DBData.Lookup;
using static Data.DBData.Master;

public class EmployeePayrollService : IEmployeePayrollService
{
    private readonly IEmployeeRepository employeeRepository;
    private readonly IAllowanceRepository allowanceRepository;
    private readonly IAllowanceDetailRepository allowanceDetailRepository;
    private readonly IMonthlyPayrollRepository monthlyPayrollRepository;
    private readonly IMonthlyPayrollDetailRepository monthlyPayrollDetailRepository;
    private readonly IMonthlyPayrollAllowanceRepository monthlyPayrollAllowanceRepository;
    private readonly IBasicSalaryPermanentRepository basicSalaryPermanentRepository;
    private readonly ISpouseRepository spouseRepository;
    private readonly IChild childRepository;
    private readonly IGradeRepository gradeRepository;
    private readonly IFunctionalAllowanceRepository functionalAllowanceRepository;
    private readonly UnitOfWork unitOfWork;

    public void GenerateMonthlyPayroll(int SchoolID, int UnitID, PayrollPeriod payrollPeriod, GenerateMonthlyPayrollDefaultData generateMonthlyPayrollDefaultData)
    {
        // TODO: Generate Payroll for every employee in a given School, with a given unit wrt payrollPeriod & defaultMonthlyPayrollData
        List<EmployeeDTO> permanentEmployeeDTOs = employeeRepository.FindAllBySchoolAndUnitAndEmployeeStatus(
            SchoolID,
            UnitID,
            EmployeeStatus.PERMANEN
        );
        List<EmployeeDTO> honorerEmployeesDTOs = employeeRepository.FindAllBySchoolAndUnitAndEmployeeStatus(
            SchoolID,
            UnitID,
            EmployeeStatus.HONORER
        );

        // Check if monthly payroll exist, else insert
        MonthlyPayrollDTO monthlyPayrollDTO = monthlyPayrollRepository.FindBySchoolAndUnitAndMonthAndYear(SchoolID, UnitID, payrollPeriod.Month, payrollPeriod.Year);
        if (monthlyPayrollDTO == null)
        {
            monthlyPayrollDTO = monthlyPayrollRepository.Insert(new MonthlyPayrollDTO
            {
                SchoolID = SchoolID,
                UnitID = UnitID,
                Month = payrollPeriod.Month
            });
        }

        unitOfWork.Run((r, ctx) =>
        {
            // TODO: convert context of repositories

            foreach (EmployeeDTO employeeDTO in permanentEmployeeDTOs)
            {
                MonthlyPayrollDetailDTO monthlyPayrollDetailDTO = SaveMonthlyPayrollDetail(new MonthlyPayrollDetailDTO
                {
                    MonthlyPayrollID = monthlyPayrollDTO.ID,
                    EmployeeID = employeeDTO.ID,
                    EmployeeStatusID = EmployeeStatus.PERMANEN,
                    WorkingDays = generateMonthlyPayrollDefaultData.DefaultPermanentDayIn,
                    WorkingHours = generateMonthlyPayrollDefaultData.DefaultPermanentOverTime,
                });
                GeneratePermanentEmployeesMonthlyPayroll(monthlyPayrollDetailDTO.ID, employeeDTO);
            }
            foreach (EmployeeDTO employeeDTO in honorerEmployeesDTOs)
            {
                MonthlyPayrollDetailDTO monthlyPayrollDetailDTO = SaveMonthlyPayrollDetail(new MonthlyPayrollDetailDTO
                {
                    MonthlyPayrollID = monthlyPayrollDTO.ID,
                    EmployeeID = employeeDTO.ID,
                    EmployeeStatusID = EmployeeStatus.HONORER,
                    WorkingDays = generateMonthlyPayrollDefaultData.DefaultHonorerDayIn,
                    WorkingHours = generateMonthlyPayrollDefaultData.DefaultHonorerOverTime,
                });
                GenerateHonorerEmployeesMonthlyPayroll(SchoolID, UnitID, payrollPeriod, generateMonthlyPayrollDefaultData);
            }
        });
    }

    private void GeneratePermanentEmployeesMonthlyPayroll(int monthlyPayrollDetailID, EmployeeDTO employeeDTO)
    {
        List<AllowanceDTO> permanentAllowanceDTOs = allowanceRepository.FindAllByAllowanceType(AllowanceType.TETAP_PGPS).ToList()
            .AddRange(allowanceRepository.FindAllByAllowanceType(AllowanceType.TETAP_KHUSUS).ToList());
        foreach (AllowanceDTO allowanceDTO in permanentAllowanceDTOs)
        {
            MonthlyPayrollDetailDTO monthlyPayrollDetailDTO = monthlyPayrollDetailRepository.FindByMonthlyPayrollDetailAndAllowance(monthlyPayrollDetailID, allowanceDTO.ID);
            BasicSalaryPermanentDTO basicSalaryPermanentDTO = basicSalaryPermanentRepository.Find(employeeDTO.BasicSalaryPermanentID);
            switch (allowanceDTO.ID)
            {
                case Allowance.TETAP_PGPS_GAJIPOKOK:
                    SaveMonthlyPayrollAllowance(monthlyPayrollDetailDTO.ID, monthlyPayrollDetailID, allowanceDTO.ID, 0, 0, 0, basicSalaryPermanentDTO.Value);
                    break;
                case Allowance.TETAP_PGPS_ISTRI:
                    SpouseDTO spouseDTO = spouseRepository.Find(employeeDTO.ID);
                    int NumberOfSpouse = spouseDTO != null ? 1 : 0;
                    SaveMonthlyPayrollAllowance(monthlyPayrollDetailDTO.ID, monthlyPayrollDetailID, allowanceDTO.ID, 1, NumberOfSpouse, NumberOfSpouse * basicSalaryPermanentDTO.Value);
                    break;
                case Allowance.TETAP_PGPS_ANAK:
                    List<ChildDTO> childrenDTO = childRepository.FindAllByEmployeeID(employeeDTO.ID) ?? new List<ChildDTO>();
                    int NumberOfChildren = childrenDTO.Count > 3 ? 3 : childrenDTO.Count;
                    SaveMonthlyPayrollAllowance(monthlyPayrollDetailDTO.ID, monthlyPayrollDetailID, allowanceDTO.ID, 1, NumberOfChildren, NumberOfChildren * basicSalaryPermanentDTO.Value);
                    break;
                case Allowance.TETAP_PGPS_BERAS:

                    break;
                case Allowance.TETAP_PGPS_JABATAN:

                    break;
                case Allowance.TETAP_PGPS_FUNGSIONAL:
                    GradeDTO gradeDTO = gradeRepository.Find(employeeDTO.GradeID);
                    FunctionalAllowanceDTO functionalAllowanceDTO = functionalAllowanceRepository.FindBySchoolAndPayrollGroup(employeeDTO.SchoolID, gradeDTO.PayrollGroup);
                    SaveMonthlyPayrollAllowance(monthlyPayrollDetailDTO.ID, monthlyPayrollDetailID, allowanceDTO.ID, 1, 1, functionalAllowanceDTO.Value);
                    break;
            }
        }
    }

    private void GenerateHonorerEmployeesMonthlyPayroll(int monthlyPayrollDetailID, EmployeeDTO employeeDTO)
    {
        List<AllowanceDTO> honorerAllowanceDTOs = allowanceRepository.FindAllByAllowanceType(AllowanceType.HONORER);
        foreach (EmployeeDTO employeeDTO in honorerEmployeesDTOs)
        {
            foreach (AllowanceDTO allowanceDTO in honorerAllowanceDTOs)
            {

            }
        }
    }

    private MonthlyPayrollDetailDTO SaveMonthlyPayrollDetail(MonthlyPayrollDetailDTO monthlyPayrollDetailDTO)
    {
        if (monthlyPayrollDetailDTO.ID)
        {
            monthlyPayrollDetailRepository.Update(monthlyPayrollDetailDTO);
        }
        else
        {
            monthlyPayrollDetailRepository.Insert(monthlyPayrollDetailDTO);
        }
        return monthlyPayrollDetailDTO;
    }

    private MonthlyPayrollAllowanceDTO SaveMonthlyPayrollAllowance(int MonthlyPayrollDetailID, int MonthlyPayrollDetailID, int AllowanceID, float Variable1, float Variable2, float Variable3, int Amount)
    {
        MonthlyPayrollAllowanceDTO existingMonthlyPayrollAllowanceDTO = monthlyPayrollAllowanceRepository.FindByMonthlyPayrollDetailAndAllowance(MonthlyPayrollDetailID, AllowanceID);
        MonthlyPayrollAllowanceDTO monthlyPayrollAllowanceDTO = new MonthlyPayrollAllowanceDTO
        {
            ID = existingMonthlyPayrollAllowanceDTO != null ? existingMonthlyPayrollAllowanceDTO.ID : 0,
            MonthlyPayrollDetailID = MonthlyPayrollDetailID,
            AllowanceID = AllowanceID,
            Variable1 = Variable1,
            Variable2 = Variable2,
            Variable3 = Variable3,
            Amount = Amount
        };

        if (existingMonthlyPayrollAllowanceDTO)
        {
            return monthlyPayrollAllowanceRepository.Update(monthlyPayrollAllowanceDTO);
        }
        else
        {
            return monthlyPayrollAllowanceRepository.Insert(monthlyPayrollAllowanceDTO);
        }
    }
}