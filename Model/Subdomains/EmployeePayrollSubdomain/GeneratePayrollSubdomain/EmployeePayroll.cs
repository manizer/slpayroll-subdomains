namespace Model.Subdomains.EmployeePayrollSubdomain.GeneratePayrollSubdomain{
    /// <summary>
    /// Data payroll karyawan yang ada baik pada karyawan honorer maupun permanen.
    /// Contoh:
    /// - Durasi Bekerja
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EmployeePayroll<T> where T: IMonthlyPayroll {
        public T MonthlyPayroll;
        public int WorkingDays;
        public int WorkingHours;
        public DateTime LastUpdatedAt;
        public string LastUpdatedUserName;
    }
}