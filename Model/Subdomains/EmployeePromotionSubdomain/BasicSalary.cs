namespace Model.Subdomains.EmployeePromotionSubdomain{
    /// <summary>
    /// Parent class untuk BasicSalaryHonorer & BasicSalaryPermanent
    /// </summary>
    public class BasicSalary{
        /// <summary>
        /// Merupakan penampung untuk semua Gaji Pokok dari suatu sekolah
        /// </summary>
        protected SchoolBasicSalaryPermanent SchoolBasicSalaryPermanent;
        public BasicSalary(SchoolBasicSalaryPermanent schoolBasicSalaryPermanent){
            SchoolBasicSalaryPermanent = schoolBasicSalaryPermanent;
        }
        /// <summary>
        /// Apabila seorang karyawan direkomendasikan untuk naik gaji pokoknya, fungsi ini dapat
        /// membantu mendapatkan gaji pokok berikutnya
        /// </summary>
        /// <returns>
        /// BasicSalaryPermanent, gaji pokok berikutnya untuk seorang karyawan
        /// </returns>
        public BasicSalaryPermanent GetNextBasicSalary() => SchoolBasicSalaryPermanent.GetNextBasicSalaryPermanent();
    }
}