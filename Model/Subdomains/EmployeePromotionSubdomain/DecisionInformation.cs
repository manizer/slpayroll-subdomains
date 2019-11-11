namespace Model.Subdomains.EmployeePromotionSubdomain{
    /// <summary>
    /// (Detail Kenaikan) Informasi keputusan kenaikan untuk seorang anggota
    /// </summary>
    public class DecisionInformation{
        public string DecreeNumber;
        public DateTime SKDate;
        public string Note;
        public int PromotionStatusID;
        public DateTime DecreeStartDate;
        public DateTime DecreeEndDate;
    }
}