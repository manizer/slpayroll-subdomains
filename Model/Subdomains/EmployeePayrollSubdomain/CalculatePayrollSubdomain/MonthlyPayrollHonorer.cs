namespace Model.Subdomains.EmployeePayrollSubdomain.CalculatePayrollSubdomain{
    public class MonthlyPayrollHonorer : IMonthlyPayroll {
        public List<MonthlyAllowanceEntry> ListAllowance;
        public List<MonthlyAllowanceEntry> ListAdditionalAllowance;
        public List<MonthlyDeductionEntry> ListDeduction;
        public List<MonthlyDeductionEntry> ListAdditionalDeduction;
    }
}