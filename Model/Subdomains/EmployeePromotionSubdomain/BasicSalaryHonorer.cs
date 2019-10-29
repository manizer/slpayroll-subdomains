namespace Model.Subdomains.EmployeePromotionSubdomain{
    /// <summary>
    /// Penampung untuk gaji pokok karyawan honorer
    /// </summary>
    public class BasicSalaryHonorer : BasicSalary{
        public int ID;
        public int SchoolID;
        public int UnitID;
        public int Value;
        public string Formula;
    }
}