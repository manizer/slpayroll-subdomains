namespace Model.Subdomains.EmployeePromotionSubdomain{
    /// <summary>
    /// (Detail Kenaikan) Informasi keputusan kenaikan untuk seorang anggota
    /// </summary>
    public class DecisionInformation{
        public string SKNumber;
        public DateTime SKDate;
        public string Note;
        public int PromotionStatusID;
    }
}