namespace Model.Subdomains.AllowanceAllowance.Permanent{
    public class SchoolBasicSalaryPermanent{
        public List<BasicSalary> BasicSalaryPermanentsBySchool;
        private BasicSalary CurrentBasicSalaryPermanent;

        public SchoolBasicSalaryPermanent(List<BasicSalary> BasicSalaryPermanentsBySchool){
            this.BasicSalaryPermanentsBySchool = BasicSalaryPermanentsBySchool;
        }

        
    }
}