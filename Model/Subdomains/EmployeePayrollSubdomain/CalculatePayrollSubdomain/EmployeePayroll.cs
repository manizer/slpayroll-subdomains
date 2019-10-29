namespace Model.Subdomains.EmployeePayrollSubdomain.CalculatePayrollSubdomain{
    public class EmployeePayroll<T> where T: MonthlyPayroll {
        public T MonthlyPayroll;
        public int WorkingDays;
        public int WorkingHours;
    }
}