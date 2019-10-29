namespace Model.Subdomains.EmployeePayrollSubdomain.DebtSubdomain{
    public class Employee {
        public int ID;
        public int SchoolID;
        public int ProfessionID;
        public int UnitID;
        public string NIK;
        public string Name;
        public string Photo;    
        public EmployeeDebt EmployeeDebt;   
    }
}