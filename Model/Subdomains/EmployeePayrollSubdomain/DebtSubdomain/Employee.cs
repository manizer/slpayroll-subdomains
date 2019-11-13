namespace Model.Subdomains.EmployeePayrollSubdomain.DebtSubdomain{
    /// <summary>
    /// Karyawan yang memiliki hutang.
    /// </summary>
    public class Employee {
        public int ID;
        public int SchoolID;
        public int ProfessionID;
        public int UnitID;
        public string NIK;
        public string Name;
        public string Photo;    
        public int GradeID;
        public int EmployeeStatusID;
        public EmployeeDebt EmployeeDebt;   
    }
}