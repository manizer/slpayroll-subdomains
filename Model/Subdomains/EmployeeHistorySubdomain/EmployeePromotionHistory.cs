namespace Model.Subdomains.EmployeeHistorySubdomain {
    public class Employee{
        public int ID;
        public string Name;
        public string PhotoURL;
        public string NIK;
        public List<Promotion> PermanentPromotions;
        public List<Promotion> GradePromotions;
        public List<Promotion> RegularPromotions;
    }
}