namespace Model.Subdomains.EmployeePayrollSubdomain.CalculatePayrollSubdomain{
    public interface MonthlyPayroll {
        int GetTotalIncome();
        int GetTotalDeduction();
    }
}