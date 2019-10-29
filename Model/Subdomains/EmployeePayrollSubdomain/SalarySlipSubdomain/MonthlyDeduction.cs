namespace Model.Subdomains.EmployeePayrollSubdomain.SalarySlipSubdomain{
    /// <summary>
    /// Penampung untuk detail perhitungan tunjangan (dari table monthlyDeduction)
    /// </summary>
    public class MonthlyDeduction {
        public int ID;
        public int DeductionID;
        public int Amount;
        public string DeductionName;
    }
}