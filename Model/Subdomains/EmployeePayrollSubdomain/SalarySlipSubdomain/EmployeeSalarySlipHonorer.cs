namespace Model.Subdomains.EmployeePayrollSubdomain.SalarySlipSubdomain{
    /// <summary>
    /// Penapung untuk detail slip gaji karyawan honorer
    /// </summary>
    public class EmployeeSalarySlipHonorer : IEmployeeSalarySlip{
        public List<MonthlyAllowance> MonthlyAllowanceList;
        public List<MonthlyDeduction> MonthlyDeductionList;
        public List<MonthlyAdditionalDeduction> MonthlyAdditionalDeductionList;
        public override int GetNetSalary(){
            int totalNetSalary = 0;
            return totalNetSalary;
        }
    }
}