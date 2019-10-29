namespace Model.Subdomains.EmployeePayrollSubdomain.DebtSubdomain{
    /// <summary>
    /// Rincian cicilan hutang karyawan
    /// </summary>
    public class EmployeeDebtInstallment{
        public int ID;
        public int DueMonth;
        public int DueYear;
        public int InstallmentAmount;
        public int InstallmentStatusID;
        public int Note;
    }
}