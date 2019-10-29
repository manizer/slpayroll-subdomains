namespace Model.Subdomains.EmployeePayrollSubdomain.SalarySlipSubdomain{
    /// <summary>
    /// Operasi yang ada di slip gaji baik karyawan honorer maupun permanen
    /// </summary>
    public interface IEmployeeSalarySlip{
        int GetNetSalary();
    }
}