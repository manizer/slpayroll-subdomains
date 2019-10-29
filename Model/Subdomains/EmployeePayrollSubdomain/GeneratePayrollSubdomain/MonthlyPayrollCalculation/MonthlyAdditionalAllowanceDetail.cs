namespace Model.Subdomains.EmployeePayrollSubdomain.GeneratePayrollSubdomain{
    /// <summary>
    /// Digunakan ketika melakukan penghitungan generate monthly payroll.
    /// 
    /// Digunakan sebagai penampung untuk table monthlyAdditionalAllowance
    /// </summary>
    public class MonthlyAdditionalAllowanceDetail{
        public int ID;
        public int MonthlyPayrollDetailID;
        public int AdditionalAllowanceID;
        public int Amount;
    }
}