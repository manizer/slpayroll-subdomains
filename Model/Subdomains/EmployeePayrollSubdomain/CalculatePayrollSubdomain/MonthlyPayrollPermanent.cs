namespace Model.Subdomains.EmployeePayrollSubdomain.CalculatePayrollSubdomain{
    public class MonthlyPayrollPermanent : IMonthlyPayroll {
        public List<MonthlyAllowanceEntry> ListPGPS;
        public List<MonthlyAllowanceEntry> ListSpecialAllowance;
        public List<MonthlyAllowanceEntry> ListAdditionalAllowance;
        public List<MonthlyDeductionEntry> ListDeduction;
        public List<MonthlyDeductionEntry> ListAdditionalDeduction;
    }
}