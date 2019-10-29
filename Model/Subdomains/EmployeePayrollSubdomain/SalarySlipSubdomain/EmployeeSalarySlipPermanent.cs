namespace Model.Subdomains.EmployeePayrollSubdomain.SalarySlipSubdomain{
    public class EmployeeSalarySlipPermanent : EmployeeSalarySlip{
        public List<MonthlyAllowance> MonthlyPGPSAllowanceList;
        public List<MonthlyAllowance> MonthlySpecialAllowanceList;
        public List<MonthlyDeduction> MonthlyDeductionList;
        public int GetNetSalary(){
            int totalNetSalary = 0;
            return totalNetSalary;
        }
    }
}