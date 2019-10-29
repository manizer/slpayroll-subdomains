namespace Model.Subdomains.EmployeePayrollSubdomain.ReportSubdomain{
    /// <summary>
    /// Data karyawan yang digunakan untuk perhitungan di table laporan
    /// </summary>
    public class Employee{
        public int ID;
        public int SchoolID;
        public int UnitID;
        public int ProfessionID;
        public int ReligionID;
        public char Gender;
        public FormalEducation FormalEducation;
    }
}