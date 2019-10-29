namespace Model.Subdomains.EmployeePayrollSubdomain.GeneratePayrollSubdomain{
    /// <summary>
    /// Penampung untuk data - data yang terdapat pada detail payroll bulanan karyawan honorer
    /// </summary>
    public class MonthlyPayrollHonorer : IMonthlyPayroll {
        public List<MonthlyAllowanceEntry> ListAllowance;
        public List<MonthlyAllowanceEntry> ListAdditionalAllowance;
        public List<MonthlyDeductionEntry> ListDeduction;
        public List<MonthlyDeductionEntry> ListAdditionalDeduction;
    }
}