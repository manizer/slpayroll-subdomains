namespace Model.Subdomains.EmployeePayrollSubdomain.GeneratePayrollSubdomain{
    /// <summary>
    /// Digunakan ketika melakukan penghitungan generate monthly payroll.
    /// 
    /// Digunakan sebagai penampung untuk table monthlyAdditionalDeduction
    /// </summary>
    public class MonthlyAdditionalDeductionDetail{
        public int ID;
        public int MonthlyPayrollDetailID;
        public int AdditionalDeductionID;
        public int Amount;
    } 
}