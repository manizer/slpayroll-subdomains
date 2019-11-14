namespace Model.Subdomains.EmployeePromotionSubdomain{
    /// <summary>
    /// (Detail Kenaikan) Informasi keputusan kenaikan untuk seorang anggota
    /// </summary>
    public class DecisionInformation{
        public string DecreeNumber;
        public string Note;
        public int PromotionStatusID;
        public DateTime DecreeIssueDate;
        public DateTime DecreeStartDate;
        public DateTime DecreeEndDate;
        public int NewGradeID;
        public List<ServiceYearAllowance> ServiceYearAllowances;
        public int AdditionalServiceYearAllowance;
    }
}