namespace Model.Subdomains.EmployeePromotionSubdomain{
    public class RecommendedEmployee<T> where T: BasicSalary {
        public int ID;
        public string Photo;
        public string NIK;
        public string Name;
        public int ProfessionID;
        public int UnitID;
        T BasicSalary;
        DecisionInformation DecisionInformation;
    }
}