public class GeneratePayrollViewModel
{
    public int SchoolID { get; set; }
    public List<SelectListItem> SchoolsDropdown { get; set; }
    public int UnitID { get; set; }
    public List<SelectListItem> UnitsDropdown { get; set; }
    public string PayrollPeriod { get; set; } // Payroll Period dari dropdown (format: month-year, e.g: 09-2019)
    public List<SelectListItem> PayrollPeriodsDropdown { get; set; }
    public GenerateMonthlyPayrollDefaultData GenerateMonthlyPayrollDefaultData { get; set; }
}