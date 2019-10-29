namespace Model.Subdomains.EmployeePayrollSubdomain.SalarySlipSubdomain{
    public class Employee<T> where T : IEmployeeSalarySlip{
        public int ID;
        public int SchoolID;
        public int EmployeeStatusID;
        public int UnitID;
        public int ProfessionID;
        public string NIM;
        public string Name;
        public T EmployeeSalarySlip;
    }
}