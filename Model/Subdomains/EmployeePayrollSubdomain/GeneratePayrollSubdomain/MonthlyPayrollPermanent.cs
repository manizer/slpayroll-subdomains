namespace Model.Subdomains.EmployeePayrollSubdomain.GeneratePayrollSubdomain{
    /// <summary>
    /// Penampung untuk data - data yang terdapat pada detail payroll bulanan karyawan permanen
    /// </summary>
    public class MonthlyPayrollPermanent : IMonthlyPayroll {
        public List<MonthlyAllowanceEntry> ListPGPS;
        public List<MonthlyAllowanceEntry> ListSpecialAllowance;
        public List<MonthlyAllowanceEntry> ListAdditionalAllowance;
        public List<MonthlyDeductionEntry> ListDeduction;
        public List<MonthlyDeductionEntry> ListAdditionalDeduction;
    }
}