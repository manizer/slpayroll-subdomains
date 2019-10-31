namespace Model.Subdomains.EmployeeHistorySubdomain.PayrollHistory {
    public class PayrollHistoryEntry{
        public int MonthlyPayrollDetailID;
        public int Month;
        public int Year;
        public int EmployeeStatusID;
        public int DaysIn;
        public int OvertimeHours;
        public List<MonthlyAllowanceEntry> ListPGPS;
        public List<MonthlyAllowanceEntry> SpecialAllowances;
        public List<MonthlyAllowanceEntry> AdditionalAllowances;
        public List<MonthlyDeductionEntry> Deductions;
        public List<MonthlyDeductionEntry> AdditionalDeductions;
        public int TotalIncome(){
            return 0;
        }
        public int TotalDeduction(){
            return 0;
        }
        public int CleanIncome(){
            return 0;
        }
    }
}