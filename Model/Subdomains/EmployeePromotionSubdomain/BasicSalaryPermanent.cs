namespace Model.Subdomains.EmployeePromotionSubdomain{
    /// <summary>
    /// Penampung untuk gaji pokok karyawan permanen
    /// </summary>
    public class BasicSalaryPermanent : BasicSalary{
        public int ID;
        public int GradeID;
        public int SchoolID;
        public int WorkPeriod;
        public int Value;
    }
}