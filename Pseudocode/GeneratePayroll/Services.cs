using static Data.DBData.Lookup;
using static Data.DBData.Master;

public class EmployeePayrollService : IEmployeePayrollService
{
    private readonly IEmployeeRepository employeeRepository;
    private readonly IAllowanceRepository allowanceRepository;
    private readonly IAllowanceDetailRepository allowanceDetailRepository;
    private readonly IAdditionalAllowanceRepository additionalAllowanceRepository;
    private readonly IMonthlyPayrollRepository monthlyPayrollRepository;
    private readonly IMonthlyPayrollDetailRepository monthlyPayrollDetailRepository;
    private readonly IMonthlyPayrollAllowanceRepository monthlyPayrollAllowanceRepository;
    private readonly IMonthlyPayrollAdditionalAllowanceRepository monthlyPayrollAdditionalAllowanceRepository;
    private readonly IBasicSalaryPermanentRepository basicSalaryPermanentRepository;
    private readonly IBasicSalaryHonorerRepository basicSalaryHonorerRepository;
    private readonly ISpouseRepository spouseRepository;
    private readonly IChildRepository childRepository;
    private readonly IGradeRepository gradeRepository;
    private readonly IFunctionalAllowanceRepository functionalAllowanceRepository;
    private readonly IPositionalAllowanceRepository positionalAllowanceRepository;
    private readonly IKaryaAllowanceRepository karyaAllowanceRepository;
    private readonly IServiceYearAllowanceRepository serviceYearAllowanceRepository;
    private readonly IDeductionRepository deductionRepository;
    private readonly IDeductionDetailRepository deductionDetailRepository;
    private readonly IAdditionalDeductionRepository additionalDeductionRepository;
    private readonly IMonthlyPayrollDeductionRepository monthlyPayrollDeductionRepository;
    private readonly IMonthlyPayrollAdditonalDeductionRepository monthlyPayrollAdditionalDeductionRepository;
    private readonly UnitOfWork unitOfWork;

    public void GenerateMonthlyPayroll(int schoolID, int unitID, PayrollPeriod payrollPeriod, GenerateMonthlyPayrollDefaultData generateMonthlyPayrollDefaultData)
    {
        List<EmployeeDTO> permanentEmployeeDTOs = employeeRepository.FindAllBySchoolAndUnitAndEmployeeStatus(
            schoolID,
            unitID,
            EmployeeStatus.TETAP
        ).ToList();

        List<EmployeeDTO> honorerEmployeesDTOs = employeeRepository.FindAllBySchoolAndUnitAndEmployeeStatus(
            schoolID,
            unitID,
            EmployeeStatus.HONORER
        ).ToList();

        MonthlyPayrollDTO monthlyPayrollDTO = monthlyPayrollRepository
            .FindBySchoolAndUnitAndMonthAndYear(schoolID, unitID, payrollPeriod.Month, payrollPeriod.Year);
        if (monthlyPayrollDTO == null)
        {
            monthlyPayrollDTO = monthlyPayrollRepository.Insert(new MonthlyPayrollDTO
            {
                SchoolID = schoolID,
                UnitID = unitID,
                Month = payrollPeriod.Month
            });
        }

        unitOfWork.Run((r, ctx) =>
        {
            foreach (EmployeeDTO employeeDTO in permanentEmployeeDTOs)
            {
                MonthlyPayrollDetailDTO monthlyPayrollDetailDTO = SaveMonthlyPayrollDetail(new MonthlyPayrollDetailDTO
                {
                    MonthlyPayrollID = monthlyPayrollDTO.ID,
                    EmployeeID = employeeDTO.ID,
                    EmployeeStatusID = EmployeeStatus.TETAP,
                    WorkingDays = generateMonthlyPayrollDefaultData.DefaultPermanentDayIn,
                    WorkingHours = generateMonthlyPayrollDefaultData.DefaultPermanentOverTime
                });
                GeneratePermanentEmployeeMonthlyPayrollAllowances(monthlyPayrollDetailDTO, employeeDTO);
                GenerateMonthlyPayrollAdditionalAllowances(monthlyPayrollDetailDTO.ID, employeeDTO);
                GeneratePermanentEmployeeMonthlyPayrollDeductions(monthlyPayrollDetailDTO.ID, employeeDTO);
                GenerateMonthlyPayrollAdditionalDeductions(monthlyPayrollDetailDTO.ID, employeeDTO);
            }
            foreach (EmployeeDTO employeeDTO in honorerEmployeesDTOs)
            {
                MonthlyPayrollDetailDTO monthlyPayrollDetailDTO = SaveMonthlyPayrollDetail(new MonthlyPayrollDetailDTO
                {
                    MonthlyPayrollID = monthlyPayrollDTO.ID,
                    EmployeeID = employeeDTO.ID,
                    EmployeeStatusID = EmployeeStatus.HONORER,
                    WorkingDays = generateMonthlyPayrollDefaultData.DefaultHonorerDayIn,
                    WorkingHours = generateMonthlyPayrollDefaultData.DefaultHonorerOverTime
                });
                GenerateHonorerEmployeeMonthlyPayrollAllowances(monthlyPayrollDetailDTO, employeeDTO);
                GenerateMonthlyPayrollAdditionalAllowances(monthlyPayrollDetailDTO.ID, employeeDTO);
                GenerateHonorerEmployeeMonthlyPayrollDeductions(monthlyPayrollDetailDTO.ID, employeeDTO);
                GenerateMonthlyPayrollAdditionalDeductions(monthlyPayrollDetailDTO.ID, employeeDTO);
            }
        });
    }

    private void GeneratePermanentEmployeeMonthlyPayrollAllowances(MonthlyPayrollDetailDTO monthlyPayrollDetailDTO, EmployeeDTO employeeDTO)
    {
        List<AllowanceDTO> permanentAllowanceDTOs = allowanceRepository.FindAllByAllowanceType(AllowanceType.TETAP_PGPS)
            .Concat(allowanceRepository.FindAllByAllowanceType(AllowanceType.TETAP_KHUSUS)).ToList();
        BasicSalaryPermanentDTO basicSalaryPermanentDTO = basicSalaryPermanentRepository.Find(employeeDTO.BasicSalaryPermanentID);
        CalculateMonthlyPayrollAllowances(monthlyPayrollDetailDTO, employeeDTO, permanentAllowanceDTOs, basicSalaryPermanentDTO.Value);
    }

    private void GenerateHonorerEmployeeMonthlyPayrollAllowances(MonthlyPayrollDetailDTO monthlyPayrollDetailDTO, EmployeeDTO employeeDTO)
    {
        List<AllowanceDTO> honorerAllowanceDTOs = allowanceRepository.FindAllByAllowanceType(AllowanceType.HONORER).ToList();
        BasicSalaryHonorerDTO basicSalaryHonorerDTO = basicSalaryHonorerRepository.FindBySchoolAndUnit(employeeDTO.SchoolID, employeeDTO.UnitID);
        CalculateMonthlyPayrollAllowances(monthlyPayrollDetailDTO, employeeDTO, honorerAllowanceDTOs, basicSalaryHonorerDTO.Value);
    }

    private void CalculateMonthlyPayrollAllowances(MonthlyPayrollDetailDTO monthlyPayrollDetailDTO, EmployeeDTO employeeDTO, List<AllowanceDTO> allowanceDTOs, int basicSalary)
    {
        foreach (AllowanceDTO allowanceDTO in allowanceDTOs)
        {
            AllowanceDetailDTO allowanceDetailDTO = allowanceDetailRepository.FindByAllowanceAndSchool(allowanceDTO.ID, employeeDTO.SchoolID);
            switch (allowanceDTO.ID)
            {
                case Allowance.TETAP_PGPS_GAJI_POKOK:
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Amount = basicSalary
                    });
                    break;

                case Allowance.TETAP_PGPS_ISTRI:
                    SpouseDTO spouseDTO = spouseRepository.FindByEmployee(employeeDTO.ID);
                    int numOfSpouse = spouseDTO != null ? 1 : 0;
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = allowanceDetailDTO.Value,
                        Variable2 = numOfSpouse,
                        Variable3 = basicSalary,
                        Amount = Convert.ToInt32(allowanceDetailDTO.Value * basicSalary) * numOfSpouse
                    });
                    break;

                case Allowance.TETAP_PGPS_ANAK:
                    List<ChildDTO> childrenDTOs = childRepository.FindAllByEmployeeOrderByDateOfBirthDescending(employeeDTO.ID).ToList() ?? new List<ChildDTO>();

                    if (childrenDTOs.Count > AllowanceRule.BATAS_JUMLAH_ANAK)
                    {
                        childrenDTOs.RemoveRange(3, childrenDTOs.Count - AllowanceRule.BATAS_JUMLAH_ANAK);
                    }
                    childrenDTOs = childrenDTOs.Where(x => ChildAllowanceRule.ValidateAge(x.DateOfBirth)).ToList();

                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = allowanceDetailDTO.Value,
                        Variable2 = childrenDTOs.Count,
                        Variable3 = basicSalary,
                        Amount = Convert.ToInt32(allowanceDetailDTO.Value * basicSalary) * childrenDTOs.Count
                    });
                    break;

                case Allowance.TETAP_PGPS_BERAS:
                    childrenDTOs = childRepository.FindAllByEmployeeOrderByDateOfBirthDescending(employeeDTO.ID).ToList() ?? new List<ChildDTO>();
                    spouseDTO = spouseRepository.FindByEmployee(employeeDTO.ID);

                    numOfSpouse = spouseDTO != null ? 1 : 0;

                    if (childrenDTOs.Count > AllowanceRule.BATAS_JUMLAH_ANAK)
                    {
                        childrenDTOs.RemoveRange(3, childrenDTOs.Count - AllowanceRule.BATAS_JUMLAH_ANAK);
                    }
                    childrenDTOs = childrenDTOs.Where(x => ChildAllowanceRule.ValidateAge(x.DateOfBirth)).ToList();

                    int numOfChildren = childrenDTOs.Count;
                    int numOfFamilyMember = numOfSpouse + numOfChildren + 1;
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = allowanceDetailDTO.Value,
                        Variable2 = numOfFamilyMember,
                        Variable3 = 1,
                        Amount = Convert.ToInt32(allowanceDetailDTO.Value * basicSalary) * numOfFamilyMember
                    });
                    break;

                case Allowance.HONORER_JABATAN:
                case Allowance.TETAP_PGPS_JABATAN:
                    PositionalAllowanceDTO positionalAllowanceDTO = positionalAllowanceRepository
                        .FindByPositionAndSchoolAndEmployeeStatusAndUnit
                        (employeeDTO.PositionID, employeeDTO.SchoolID, employeeDTO.EmployeeStatusID, employeeDTO.UnitID);
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = positionalAllowanceDTO.Value,
                        Amount = positionalAllowanceDTO.Value
                    });
                    break;

                case Allowance.TETAP_PGPS_FUNGSIONAL:
                    GradeDTO gradeDTO = gradeRepository.Find(employeeDTO.GradeID);
                    FunctionalAllowanceDTO functionalAllowanceDTO = functionalAllowanceRepository
                        .FindBySchoolAndPayrollGroup(employeeDTO.SchoolID, gradeDTO.PayrollGroup);
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = functionalAllowanceDTO.Value,
                        Amount = functionalAllowanceDTO.Value
                    });
                    break;

                case Allowance.TETAP_KHUSUS_ISTRI:
                    spouseDTO = spouseRepository.FindByEmployee(employeeDTO.ID);
                    numOfSpouse = spouseDTO != null ? 1 : 0;
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = allowanceDetailDTO.Value,
                        Variable2 = numOfSpouse,
                        Amount = Convert.ToInt32(allowanceDetailDTO.Value * numOfSpouse)
                    });
                    break;

                case Allowance.TETAP_KHUSUS_ANAK:
                    childrenDTOs = childRepository.FindAllByEmployeeOrderByDateOfBirthDescending(employeeDTO.ID).ToList() ?? new List<ChildDTO>();

                    if (childrenDTOs.Count > AllowanceRule.BATAS_JUMLAH_ANAK)
                    {
                        childrenDTOs.RemoveRange(3, childrenDTOs.Count - AllowanceRule.BATAS_JUMLAH_ANAK);
                    }
                    childrenDTOs = childrenDTOs.Where(x => ChildAllowanceRule.ValidateAge(x.DateOfBirth)).ToList();

                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = allowanceDetailDTO.Value,
                        Variable2 = childrenDTOs.Count,
                        Amount = Convert.ToInt32(allowanceDetailDTO.Value * childrenDTOs.Count)
                    });
                    break;

                case Allowance.HONORER_TRANSPORT_DAN_MAKAN:
                case Allowance.TETAP_KHUSUS_TRANSPORT_DAN_MAKAN:
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = allowanceDetailDTO.Value,
                        Variable2 = monthlyPayrollDetailDTO.WorkingDays,
                        Amount = Convert.ToInt32(allowanceDetailDTO.Value * monthlyPayrollDetailDTO.WorkingDays)
                    });
                    break;

                case Allowance.TETAP_KHUSUS_KARYA:
                    KaryaAllowanceDTO karyaAllowanceDTO = karyaAllowanceRepository.FindBySchoolAndUnit(employeeDTO.SchoolID, employeeDTO.UnitID);
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = karyaAllowanceDTO.Value,
                        Amount = karyaAllowanceDTO.Value
                    });
                    break;

                case Allowance.TETAP_KHUSUS_MASA_KERJA:
                    ServiceYearAllowanceDTO serviceYearAllowanceDTO = serviceYearAllowanceRepository
                        .FindBySchoolAndCurrentDate(employeeDTO.SchoolID, DateTime.Now);
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = serviceYearAllowanceDTO.Value + employeeDTO.ServiceYearAllowanceAccumulation,
                        Amount = serviceYearAllowanceDTO.Value + employeeDTO.ServiceYearAllowanceAccumulation
                    });
                    break;

                case Allowance.HONORER_PENGOBATAN:
                case Allowance.TETAP_KHUSUS_PENGOBATAN:
                    double uangPengobatan = (employeeDTO.IsBPJSKesehatan) ? 0 : allowanceDetailDTO.Value;
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = uangPengobatan,
                        Amount = Convert.ToInt32(uangPengobatan)
                    });
                    break;

                case Allowance.TETAP_KHUSUS_JAM_KERJA_LEBIH:
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = allowanceDetailDTO.Value,
                        Variable2 = monthlyPayrollDetailDTO.WorkingHours,
                        Amount = Convert.ToInt32(allowanceDetailDTO.Value * monthlyPayrollDetailDTO.WorkingHours)
                    });
                    break;

                case Allowance.HONORER_GAJI_POKOK:
                    SaveMonthlyPayrollAllowance(new MonthlyAllowanceDetail
                    {
                        MonthlyPayrollDetailID = monthlyPayrollDetailDTO.ID,
                        AllowanceID = allowanceDTO.ID,
                        Variable1 = basicSalary,
                        Variable2 = monthlyPayrollDetailDTO.WorkingHours,
                        Amount = basicSalary * monthlyPayrollDetailDTO.WorkingHours
                    });
                    break;
            }
        }
    }

    private void GenerateMonthlyPayrollAdditionalAllowances(int monthlyPayrollDetailID, EmployeeDTO employeeDTO)
    {
        List<AdditionalAllowanceDTO> additionalAllowanceDTOs = additionalAllowanceRepository.FindAllByEmployeeStatusAndSchool(employeeDTO.EmployeeStatusID, employeeDTO.SchoolID).ToList();
        foreach (AdditionalAllowanceDTO additionalAllowanceDTO in additionalAllowanceDTOs)
        {
            SaveMonthlyPayrollAdditionalAllowance(new MonthlyAdditionalAllowanceDetail
            {
                MonthlyPayrollDetailID = monthlyPayrollDetailID,
                AdditionalAllowanceID = additionalAllowanceDTO.ID,
                Amount = additionalAllowanceDTO.Value
            });
        }
    }

    private void GeneratePermanentEmployeeMonthlyPayrollDeductions(int monthlyPayrollDetailID, EmployeeDTO employeeDTO)
    {
        List<DeductionDTO> permanentDeductionDTOs = deductionRepository.FindAllByEmployeeStatus(EmployeeStatus.TETAP).ToList();
        CalculateMonthlyPayrollDeductions(monthlyPayrollDetailID, employeeDTO, permanentDeductionDTOs);
    }

    private void GenerateHonorerEmployeeMonthlyPayrollDeductions(int monthlyPayrollDetailID, EmployeeDTO employeeDTO)
    {
        List<DeductionDTO> honorerDeductionDTOs = deductionRepository.FindAllByEmployeeStatus(EmployeeStatus.HONORER).ToList();
        CalculateMonthlyPayrollDeductions(monthlyPayrollDetailID, employeeDTO, honorerDeductionDTOs);
    }

    private void CalculateMonthlyPayrollDeductions(int monthlyPayrollDetailID, EmployeeDTO employeeDTO, List<DeductionDTO> deductionDTOs)
    {
        foreach (DeductionDTO deductionDTO in deductionDTOs)
        {
            DeductionDetailDTO deductionDetailDTO = deductionDetailRepository
                .FindBySchoolAndDeduction(employeeDTO.SchoolID, deductionDTO.ID);

            int tempValue = 0;
            string[] strList = deductionDetailDTO.AllowanceList.Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strList)
            {
                MonthlyPayrollAllowanceDTO allowanceDTO = monthlyPayrollAllowanceRepository.Find(int.Parse(str));
                tempValue += allowanceDTO.Amount;
            }

            strList = deductionDetailDTO.AdditionalAllowanceList.Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in strList)
            {
                MonthlyPayrollAdditionalAllowanceDTO additionalAllowanceDTO = monthlyPayrollAdditionalAllowanceRepository.Find(int.Parse(str));
                tempValue += additionalAllowanceDTO.Amount;
            }

            int allowanceAmount = tempValue * deductionDetailDTO.PercentageValue;
            int amount = (allowanceAmount < deductionDetailDTO.MinimumValue) ? deductionDetailDTO.MinimumValue : allowanceAmount;
            SaveMonthlyPayrollDeduction(new MonthlyDeductionDetail
            {
                MonthlyPayrollDetailID = monthlyPayrollDetailID,
                DeductionID = deductionDetailDTO.DeductionID,
                Amount = amount
            });
        }
    }

    private void GenerateMonthlyPayrollAdditionalDeductions(int monthlyPayrollDetailID, EmployeeDTO employeeDTO)
    {
        List<AdditionalDeductionDTO> additionalDeductionDTOs = (additionalDeductionRepository
            .FindAllByEmployeeStatusAndSchool(employeeDTO.EmployeeStatusID, employeeDTO.SchoolID)).ToList();
        foreach (AdditionalDeductionDTO additionalDeductionDTO in additionalDeductionDTOs)
        {
            SaveMonthlyPayrollAdditionalDeduction(new MonthlyAdditionalDeductionDetail
            {
                MonthlyPayrollDetailID = monthlyPayrollDetailID,
                AdditionalDeductionID = additionalDeductionDTO.ID,
                Amount = additionalDeductionDTO.Value
            });
        }
    }

    private MonthlyPayrollDetailDTO SaveMonthlyPayrollDetail(MonthlyPayrollDetailDTO monthlyPayrollDetailDTO)
    {
        MonthlyPayrollDetailDTO existingMonthlyPayrollDetailDTO = monthlyPayrollDetailRepository
            .FindByMonthlyPayrollAndEmployee(monthlyPayrollDetailDTO.MonthlyPayrollID, monthlyPayrollDetailDTO.EmployeeID);
        monthlyPayrollDetailDTO.ID = existingMonthlyPayrollDetailDTO != null ? existingMonthlyPayrollDetailDTO.ID : 0;

        if (existingMonthlyPayrollDetailDTO != null)
        {
            return monthlyPayrollDetailRepository.Insert(monthlyPayrollDetailDTO);
        }
        else
        {
            return monthlyPayrollDetailRepository.Update(monthlyPayrollDetailDTO);
        }
    }

    private MonthlyPayrollAllowanceDTO SaveMonthlyPayrollAllowance(MonthlyAllowanceDetail allowanceDetail)
    {
        MonthlyPayrollAllowanceDTO existingMonthlyPayrollAllowanceDTO =
            monthlyPayrollAllowanceRepository.FindByMonthlyPayrollDetailAndAllowance
            (allowanceDetail.MonthlyPayrollDetailID, allowanceDetail.AllowanceID);

        MonthlyPayrollAllowanceDTO monthlyPayrollAllowanceDTO = new MonthlyPayrollAllowanceDTO
        {
            ID = existingMonthlyPayrollAllowanceDTO != null ? existingMonthlyPayrollAllowanceDTO.ID : 0,
            MonthlyPayrollDetailID = allowanceDetail.MonthlyPayrollDetailID,
            AllowanceID = allowanceDetail.AllowanceID,
            Variable1 = allowanceDetail.Variable1,
            Variable2 = allowanceDetail.Variable2,
            Variable3 = allowanceDetail.Variable3,
            Amount = allowanceDetail.Amount
        };

        if (existingMonthlyPayrollAllowanceDTO != null)
        {
            return monthlyPayrollAllowanceRepository.Update(monthlyPayrollAllowanceDTO);
        }
        else
        {
            return monthlyPayrollAllowanceRepository.Insert(monthlyPayrollAllowanceDTO);
        }
    }

    private MonthlyPayrollAdditionalAllowanceDTO SaveMonthlyPayrollAdditionalAllowance(MonthlyAdditionalAllowanceDetail additionalAllowanceDetail)
    {
        MonthlyPayrollAdditionalAllowanceDTO existingMonthlyPayrollAdditionalAllowanceDTO =
            monthlyPayrollAdditionalAllowanceRepository.FindByMonthlyPayrollDetailAndAdditionalAllowance
            (additionalAllowanceDetail.MonthlyPayrollDetailID, additionalAllowanceDetail.AdditionalAllowanceID);

        MonthlyPayrollAdditionalAllowanceDTO monthlyPayrollAdditionalAllowanceDTO = new MonthlyPayrollAdditionalAllowanceDTO
        {
            ID = existingMonthlyPayrollAdditionalAllowanceDTO != null ? existingMonthlyPayrollAdditionalAllowanceDTO.ID : 0,
            MonthlyPayrollDetailID = additionalAllowanceDetail.MonthlyPayrollDetailID,
            AdditionalAllowanceID = additionalAllowanceDetail.AdditionalAllowanceID,
            Amount = additionalAllowanceDetail.Amount
        };

        if (existingMonthlyPayrollAdditionalAllowanceDTO != null)
        {
            return monthlyPayrollAdditionalAllowanceRepository.Update(monthlyPayrollAdditionalAllowanceDTO);
        }
        else
        {
            return monthlyPayrollAdditionalAllowanceRepository.Insert(monthlyPayrollAdditionalAllowanceDTO);
        }
    }

    private MonthlyPayrollDeductionDTO SaveMonthlyPayrollDeduction(MonthlyDeductionDetail deductionDetail)
    {
        MonthlyPayrollDeductionDTO existingMonthlyPayrollDeductionDTO =
            monthlyPayrollDeductionRepository.FindByMonthlyPayrollDetailAndDeduction
            (deductionDetail.MonthlyPayrollDetailID, deductionDetail.DeductionID);

        MonthlyPayrollDeductionDTO monthlyPayrollDeductionDTO = new MonthlyPayrollDeductionDTO
        {
            ID = existingMonthlyPayrollDeductionDTO != null ? existingMonthlyPayrollDeductionDTO.ID : 0,
            MonthlyPayrollDetailID = deductionDetail.MonthlyPayrollDetailID,
            DeductionID = deductionDetail.DeductionID,
            Amount = deductionDetail.Amount
        };

        if (existingMonthlyPayrollDeductionDTO != null)
        {
            return monthlyPayrollDeductionRepository.Update(monthlyPayrollDeductionDTO);
        }
        else
        {
            return monthlyPayrollDeductionRepository.Insert(monthlyPayrollDeductionDTO);
        }
    }

    private MonthlyPayrollAdditionalDeductionDTO SaveMonthlyPayrollAdditionalDeduction(MonthlyAdditionalDeductionDetail additionalDeductionDetail)
    {
        MonthlyPayrollAdditionalDeductionDTO existingMonthlyPayrollAdditionalDeductionDTO = 
            monthlyPayrollAdditionalDeductionRepository.FindByMonthlyPayrollDetailAndAdditionalDeduction
            (additionalDeductionDetail.MonthlyPayrollDetailID, additionalDeductionDetail.AdditionalDeductionID);

        MonthlyPayrollAdditionalDeductionDTO monthlyPayrollAdditionalDeductionDTO = new MonthlyPayrollAdditionalDeductionDTO
        {
            ID = existingMonthlyPayrollAdditionalDeductionDTO != null ? existingMonthlyPayrollAdditionalDeductionDTO.ID : 0,
            MonthlyPayrollDetailID = additionalDeductionDetail.MonthlyPayrollDetailID,
            AdditionalDeductionID = additionalDeductionDetail.AdditionalDeductionID,
            Amount = additionalDeductionDetail.Amount
        };

        if (existingMonthlyPayrollAdditionalDeductionDTO != null)
        {
            return monthlyPayrollAdditionalDeductionRepository.Update(monthlyPayrollAdditionalDeductionDTO);
        }
        else
        {
            return monthlyPayrollAdditionalDeductionRepository.Insert(monthlyPayrollAdditionalDeductionDTO);
        }
    }
}