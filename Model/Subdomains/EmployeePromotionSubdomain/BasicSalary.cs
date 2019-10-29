namespace Model.Subdomains.EmployeePromotionSubdomain{
    public abstract class BasicSalary{
        protected SchoolBasicSalaryPermanent SchoolBasicSalaryPermanent;
        public BasicSalary(SchoolBasicSalaryPermanent schoolBasicSalaryPermanent){
            SchoolBasicSalaryPermanent = schoolBasicSalaryPermanent;
        }
        BasicSalaryPermanent GetNextBasicSalary();
    }
}