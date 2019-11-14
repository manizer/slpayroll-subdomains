namespace Model.Subdomains.EmployeeHistorySubdomain {
    public class Employee<T> where T: IEmployeeHistoryItem{
        public int ID;
        public string Name;
        public string PhotoURL;
        public string NIK;
        public List<T> Histories;
    }
}