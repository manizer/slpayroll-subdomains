namespace Model.Subdomains.EmployeePayrollSubdomain.SalarySlipSubdomain{
    public class EmployeeSalarySlipHonorer : IEmployeeSalarySlip{
        public List<MonthlyAllowance> MonthlyAllowanceList;
        public List<MonthlyDeduction> MonthlyDeductionList;
        public int GetNetSalary(){
            int totalNetSalary = 0;
            return totalNetSalary;
        }
    }
}