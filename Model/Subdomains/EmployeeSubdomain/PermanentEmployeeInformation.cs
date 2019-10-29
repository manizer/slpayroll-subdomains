namespace Model.Subdomains.EmployeeSubdomain{
    /// <summary>
    /// Informasi karyawan tetap
    /// </summary>
    public class PermanentEmployeeInformation{
        public int GradeID;
        public int BasicSalaryPermanentID;
        public DateTime PermanentPromotionDate;
        public string LastSKNumber;
        public DateTime LastSKDate;
        // tunjangan masa kerja
        public int LastPromotionTypeID;
        public DateTime StartSKElligibleDate;
        public DateTime EndSKElligibleDate;
    }
}