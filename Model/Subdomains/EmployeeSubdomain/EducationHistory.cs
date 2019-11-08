namespace Model.Subdomains.EmployeeSubdomain{
    /// <summary>
    /// Riwayat pendidikan seorang karyawan
    /// </summary>
    public class EducationHistory{
        public FormalEducation FormalEducationHistory;
        public List<InformalEducation> InformalEducationHistories;
    }
}