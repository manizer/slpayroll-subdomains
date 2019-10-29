namespace Model.Subdomains.EmployeePromotionSubdomain{
    public class SchoolBasicSalaryPermanent{
        public LinkedList<BasicSalaryPermanentsBySchool> BasicSalaryPermanentsBySchool;
        private BasicSalaryPermanent CurrentBasicSalaryPermanent;

        public SchoolBasicSalaryPermanent(LinkedList<BasicSalaryPermanent> BasicSalaryPermanentsBySchool){
            this.BasicSalaryPermanentsBySchool = BasicSalaryPermanentsBySchool;
        }

        public void SetCurrentBasicSalaryPermanent(int BasicSalaryPermanentID = 0){
            if(BasicSalaryPermanentID == 0) CurrentBasicSalaryPermanent = null;
            else CurrentBasicSalaryPermanent = BasicSalaryPermanentsBySchool.Find(x => x.ID == BasicSalaryPermanentID);
        }

        public BasicSalaryPermanent GetNextBasicSalaryPermanent(){
            // 
        }
    }

    /**
     * // Controller
     * RecommendedEmployee<BasicSalaryPermanent> recommendedEmployee = GetEmployeeFromService();
     * BasicSalaryPermanent nextBasicSalary = recommendedEmployee.BasicSalary.GetNextBasicSalary();
     */
}