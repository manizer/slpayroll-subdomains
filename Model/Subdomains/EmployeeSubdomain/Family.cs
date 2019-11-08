namespace Model.Subdomains.EmployeeSubdomain{
    /// <summary>
    /// Tanggungan keluarga seorang karyawan
    /// </summary>
    public class Family{
        public SpouseData SpouseData;
        public List<Child> Children;
    }
}