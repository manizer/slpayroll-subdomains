namespace Model.Subdomains.EmployeePayrollSubdomain.SalarySlipSubdomain{
    /// <summary>
    /// Karyawan yang sedang ingin digenerate slip gajinya
    /// </summary>
    /// <typeparam name="T">
    /// Jenis slip gaji berdasar status karyawan
    /// <see cref="EmployeeSalarySlipHonorer"/> untuk karyawan honorer
    /// <see cref="EmployeeSalarySlipPermanent"/> untuk karyawan permanen
    /// </typeparam>
    public class Employee<T> where T : IEmployeeSalarySlip{
        public int ID;
        public int SchoolID;
        public int EmployeeStatusID;
        public int UnitID;
        public int ProfessionID;
        public string Name;
        public int GradeID;
        public T EmployeeSalarySlip;
    }
}