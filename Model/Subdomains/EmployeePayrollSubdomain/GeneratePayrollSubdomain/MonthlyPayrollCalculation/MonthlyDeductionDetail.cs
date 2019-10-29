namespace Model.Subdomains.EmployeePayrollSubdomain.GeneratePayrollSubdomain{
    /// <summary>
    /// Digunakan ketika melakukan penghitungan generate monthly payroll.
    /// 
    /// Digunakan sebagai penampung untuk table monthlyDeduction
    /// </summary>
    public class MonthlyDeductionDetail{
        public int ID;
        public int MonthlyPayrollDetailID;
        public int DeductionID;
        public int Amount;
    }
}