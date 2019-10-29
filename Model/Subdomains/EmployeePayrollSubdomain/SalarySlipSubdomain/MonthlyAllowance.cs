namespace Model.Subdomains.EmployeePayrollSubdomain.SalarySlipSubdomain{
    /// <summary>
    /// Penampung untuk detail perhitungan tunjangan (dari table monthlyAllowance)
    /// </summary>
    public class MonthlyAllowance {
        public int ID;
        public int AllowanceID;
        public int Variable1;
        public int Variable2;
        public int Variable3;
        public int Amount;

        public string AllowanceName;
        public string Formula;
    }
}