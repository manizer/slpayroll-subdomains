namespace Model.Subdomains.EmployeeSubdomain{
    /// <summary>
    /// Riwayat pendidikan seorang karyawan
    /// </summary>
    public class EducationHistory{
        public FormalEducationHistory FormalEducationHistory;
        public List<InformalEducationHistory> InformalEducationHistories;
    }
}