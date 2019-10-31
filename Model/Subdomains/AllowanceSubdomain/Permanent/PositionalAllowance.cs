namespace Model.Subdomains.AllowanceSubdomain.Permanent{
    /// <summary>
    /// Penampung untuk Tunjangan Jabatan
    /// </summary>
    public class PositionalAllowance{
        public int PositionalAllowanceID;
        public int PositionID;
        public int UnitID;
        public int SchoolID;
        public string EmployeeStatusID; // Pasti nilainya EMPLOYEESTATUS_PERMANENT
        public int Value;
    }
}