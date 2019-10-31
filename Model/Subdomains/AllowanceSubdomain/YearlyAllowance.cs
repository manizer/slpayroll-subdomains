namespace Model.Subdomains.AllowanceSubdomain.Permanent{
    /// <summary>
    /// Penampung untuk Tunjangan Tahunan
    /// Hasil join dari table msYearAllowanceDetail & msAllowance
    /// </summary>
    public class YearlyAllowance{
        public int YearlyAllowanceID;
        public int SchoolID;
        public string Name;
        public string Formula;
        public int Value;
    }
}