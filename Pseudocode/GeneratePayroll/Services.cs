using static Data.DBData.Lookup;
using static Data.DBData.Master;

public class MonthlyAllowanceDetailService : IMonthlyAllowanceDetailService
{
    private readonly IEmployeeRepository employeeRepository;
    private readonly IAllowanceRepository allowanceRepository;
    private readonly IAllowanceDetailRepository allowanceDetailRepository;
    private readonly IMonthlyPayrollRepository monthlyPayrollRepository;
    private readonly IMonthlyPayrollDetailRepository monthlyPayrollDetailRepository;
    private readonly UnitOfWork unitOfWork;

    public void GenerateMonthlyPayroll(int SchoolID, int UnitID, PayrollPeriod payrollPeriod, GenerateMonthlyPayrollDefaultData generateMonthlyPayrollDefaultData)
    {
        // TODO: Generate Payroll for every employee in a given School, with a given unit wrt payrollPeriod & defaultMonthlyPayrollData
        unitOfWork.Run((r, ctx) =>
        {
            r.ConvertContextOfRepository(employeeRepository).ToUse(ctx);
            r.ConvertContextOfRepository(allowanceRepository).ToUse(ctx);
            r.ConvertContextOfRepository(allowanceDetailRepository).ToUse(ctx);
            r.ConvertContextOfRepository(monthlyPayrollRepository).ToUse(ctx);
            r.ConvertContextOfRepository(monthlyPayrollDetailRepository).ToUse(ctx);

            GeneratePermanentEmployeesMonthlyPayroll(SchoolID, UnitID, payrollPeriod, generateMonthlyPayrollDefaultData);
            GenerateHonorerEmployeesMonthlyPayroll(SchoolID, UnitID, payrollPeriod, generateMonthlyPayrollDefaultData);
        });
    }

    private void GeneratePermanentEmployeesMonthlyPayroll(int SchoolID, int UnitID, PayrollPeriod payrollPeriod, GenerateMonthlyPayrollDefaultData generateMonthlyPayrollDefaultData)
    {
        List<EmployeeDTO> permanentEmployeeDTOs = employeeRepository.FindAllBySchoolAndUnitAndEmployeeStatus(
            SchoolID,
            UnitID,
            EmployeeStatus.PERMANEN
        );
        List<AllowanceDTO> permanentAllowanceDTOs = allowanceRepository.FindAllByAllowanceType(AllowanceType.TETAP_PGPS).ToList()
            .AddRange(allowanceRepository.FindAllByAllowanceType(AllowanceType.TETAP_KHUSUS).ToList());
        foreach (EmployeeDTO employeeDTO in permanentEmployeeDTOs)
        {
            foreach (AllowanceDTO allowanceDTO in permanentAllowanceDTOs)
            {

            }
        }
    }

    private void GenerateHonorerEmployeesMonthlyPayroll(int SchoolID, int UnitID, PayrollPeriod payrollPeriod, GenerateMonthlyPayrollDefaultData generateMonthlyPayrollDefaultData)
    {
        List<EmployeeDTO> honorerEmployeesDTOs = employeeRepository.FindAllBySchoolAndUnitAndEmployeeStatus(
            SchoolID,
            UnitID,
            EmployeeStatus.HONORER
        );
        List<AllowanceDTO> honorerAllowanceDTOs = allowanceRepository.FindAllByAllowanceType(AllowanceType.HONORER);
        foreach (EmployeeDTO employeeDTO in honorerEmployeesDTOs)
        {
            foreach (AllowanceDTO allowanceDTO in honorerAllowanceDTOs)
            {

            }
        }
    }
}