namespace Model.Subdomains.EmployeePayrollSubdomain.SalarySlipSubdomain{
    /// <summary>
    /// Penapung untuk detail slip gaji karyawan permanen
    /// </summary>
    public class EmployeeSalarySlipPermanent : IEmployeeSalarySlip{
        public List<MonthlyAllowance> MonthlyPGPSAllowanceList;
        public List<MonthlyAllowance> MonthlySpecialAllowanceList;
        public List<MonthlyAdditionalAllowance> MonthlyAdditionalAllowanceList;
        public List<MonthlyDeduction> MonthlyDeductionList;
        public List<MonthlyAdditionalDeduction> MonthlyAdditionalDeductionList;
        public override int GetNetSalary(){
            int totalNetSalary = 0;
            return totalNetSalary;
        }
    }
}