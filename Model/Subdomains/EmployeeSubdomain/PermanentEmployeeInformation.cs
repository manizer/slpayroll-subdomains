namespace Model.Subdomains.EmployeeSubdomain{
    /// <summary>
    /// Informasi karyawan tetap
    /// </summary>
    public class PermanentEmployeeInformation{
        public int GradeID;
        public int BasicSalaryPermanentID;
        public DateTime PermanentPromotionDate;
        public string LastDecreeNumber;
        public DateTime LastDecreeDate;
        List<ServiceYearAllowance> ServiceYearAllowances;
        public int AdditionalServiceYearAllowance;
        public int LastPromotionTypeID;
        public DateTime DecreeStartDate;
        public DateTime DecreeEndDate;
    }
}