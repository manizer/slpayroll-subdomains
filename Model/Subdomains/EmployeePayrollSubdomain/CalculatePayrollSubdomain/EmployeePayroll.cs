namespace Model.Subdomains.EmployeePayrollSubdomain.CalculatePayrollSubdomain{
    public class EmployeePayroll<T> where T: IMonthlyPayroll {
        public T MonthlyPayroll;
        public int WorkingDays;
        public int WorkingHours;
    }
}