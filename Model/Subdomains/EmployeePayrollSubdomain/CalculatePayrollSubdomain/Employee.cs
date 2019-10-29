namespace Model.Subdomains.EmployeePayrollSubdomain.CalculatePayrollSubdomain{
    public class Employee<T> where T : MonthlyPayroll{
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