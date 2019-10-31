namespace Model.Subdomains.AllowanceSubdomain.Permanent{
    /// <summary>
    /// Penampung untuk Tunjangan Utama
    /// Hasil join dari table msAllowance & msAllowanceDetail
    /// </summary>
    public class AllowanceDetail{
        public int AllowanceDetailID;
        public int SchoolID;
        public int Name;
        public string Formula;
        public int Value;
    }
}