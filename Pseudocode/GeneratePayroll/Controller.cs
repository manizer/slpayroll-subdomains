public class GeneratePayrollController
{
    private readonly IEmployeePayrollService employeePayrollService;
    public IActionResult GeneratePayroll(GeneratePayrollViewModel generatePayrollViewModel)
    {
        string payrollPeriod = generatePayrollViewModel.PayrollPeriod;
        // Generate Payroll
        employeePayrollService.GenerateMonthlyPayroll(
            generatePayrollViewModel.SchoolID,
            generatePayrollViewModel.UnitID,
            new PayrollPeriod
            {
                Month = Int32.Parse(payrollPeriod.Split('-')[0]),
                Year = Int32.Parse(payrollPeriod.Split('-')[1])
            },
            generatePayrollViewModel.GenerateMonthlyPayrollDefaultData
        );

        // return view component table karyawan tetap dan karyawan honorer
        return ViewComponent("...");
    }
}