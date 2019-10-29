namespace Model.Subdomains.EmployeePayrollSubdomain.GeneratePayrollSubdomain{
    /// <summary>
    /// Digunakan ketika melakukan penghitungan generate monthly payroll.
    /// 
    /// Digunakan sebagai penampung untuk table monthlyAllowannce
    /// </summary>
    public class MonthlyAllowanceDetail{
        public int ID;
        public int MonthlyPayrollDetailID;
        public int AllowanceID;
        public float Variable1;
        public float Variable2;
        public float Variable3;
        public int Amount;
    }
}