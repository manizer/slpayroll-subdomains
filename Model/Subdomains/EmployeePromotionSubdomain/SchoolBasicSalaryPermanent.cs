namespace Model.Subdomains.EmployeePromotionSubdomain{
    public class SchoolBasicSalaryPermanent{
        public List<BasicSalaryPermanent> BasicSalaryPermanentsBySchool;
        private int SchoolID;
        private BasicSalaryPermanent CurrentBasicSalaryPermanent;

        public SchoolBasicSalaryPermanent(List<BasicSalaryPermanent> BasicSalaryPermanentsBySchool, int SchoolID, int CurrentEmployeeBasicSalaryPermanentID){
            this.BasicSalaryPermanentsBySchool = BasicSalaryPermanentsBySchool;
            this.SchoolID = SchoolID;

            // Validate BasicSalaryPermanentsBySchool
            SetCurrentBasicSalaryPermanent(CurrentEmployeeBasicSalaryPermanentID);
        }

        private void SetCurrentBasicSalaryPermanent(int BasicSalaryPermanentID = 0){
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