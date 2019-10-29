namespace Model.Subdomains.EmployeePayrollSubdomain.GeneratePayrollSubdomain{
    /// <summary>
    /// Karyawan untuk dilihat rincian payroll bulanannya
    /// </summary>
    /// <typeparam name="T">
    /// Status payroll karyawan 
    /// <see cref="MonthlyPayrollHonorer"/> untuk Karyawan honorer
    /// <see cref="MonthlyPayrollPermanent"/> untuk karyawan permanen
    /// </typeparam>
    public class Employee<T> where T : IMonthlyPayroll{
        public int ID;
        public int SchoolID;
        public int EmployeeStatusID;
        public int UnitID;
        public int ProfessionID;
        public string NIM;
        public string Name;
        public EmployeePayroll<T> EmployeePayroll;
    }
}