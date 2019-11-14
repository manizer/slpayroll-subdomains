namespace Model.Subdomains.EmployeePromotionSubdomain{
    public class SchoolBasicSalaryPermanent{
        public List<BasicSalaryPermanent> AllBasicSalaryPermanentsBySchool;
        private int SchoolID;
        private int GradeID;
        private BasicSalaryPermanent CurrentBasicSalaryPermanent;

        public SchoolBasicSalaryPermanent(List<BasicSalaryPermanent> AllBasicSalaryPermanentsBySchool, int SchoolID, int GradeID, int CurrentEmployeeBasicSalaryPermanentID){
            this.AllBasicSalaryPermanentsBySchool = AllBasicSalaryPermanentsBySchool;
            this.SchoolID = SchoolID;
            this.GradeID = GradeID;

            // Validate BasicSalaryPermanentsBySchool
            SetCurrentBasicSalaryPermanent(CurrentEmployeeBasicSalaryPermanentID);
        }

        private void SetCurrentBasicSalaryPermanent(int BasicSalaryPermanentID = 0){
            if(BasicSalaryPermanentID == 0) CurrentBasicSalaryPermanent = null;
            else CurrentBasicSalaryPermanent = AllBasicSalaryPermanentsBySchool.Find(x => x.ID == BasicSalaryPermanentID);
        }

        public BasicSalaryPermanent GetNextBasicSalaryPermanent(){
            // 
        }

        public List<SchoolBasicSalaryPermanent> GetAllNextBasicSalaryPermanents(){

        }
    }

    /**
     * // Controller
     * RecommendedEmployee<BasicSalaryPermanent> recommendedEmployee = GetEmployeeFromService();
     * BasicSalaryPermanent nextBasicSalary = recommendedEmployee.BasicSalary.GetNextBasicSalary();
     */
}