namespace Model.Subdomains.EmployeePayrollSubdomain.CalculatePayrollSubdomain{
    public interface IMonthlyPayroll {
        int GetTotalIncome();
        int GetTotalDeduction();
    }
}