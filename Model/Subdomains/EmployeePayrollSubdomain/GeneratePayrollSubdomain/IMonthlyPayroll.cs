namespace Model.Subdomains.EmployeePayrollSubdomain.GeneratePayrollSubdomain{
    public interface IMonthlyPayroll {
        int GetTotalIncome();
        int GetTotalDeduction();
    }
}