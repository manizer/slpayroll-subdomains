namespace Model.Subdomains.EmployeePromotionSubdomain{
    /// <summary>
    /// Karyawan yang direkomendasikan untuk naik
    /// </summary>
    /// <typeparam name="T">
    /// Menandakan gaji karyawan saat ini berdasar status 
    /// (BasicSalaryHonorer untuk karyawan honorer / BasicSalaryPermanent untuk karyawan permanent)
    /// </typeparam>
    public class RecommendedEmployee<T> where T: BasicSalary {
        public int ID;
        public string Photo;
        public string NIK;
        public string Name;
        public int ProfessionID;
        public int UnitID;
        public int GradeID;
        T BasicSalary;
        public int ServiceYearAllowanceAccumulation;
        DecisionInformation DecisionInformation;
    }
}