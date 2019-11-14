namespace Model.Subdomains.EmployeeHistorySubdomain.PromotionHistory {
    public class Promotion: IEmployeeHistoryItem{
        public int PromotionTypeID;
        public int OldEmployeeStatusID;
        public int NewEmployeeStatusID;
        public string DecreeNumber;
        public DateTime DecreeIssueDate;
        public DateTime DecreeStartDate;
        public DateTime DecreeEndDate;
        public int OldGradeID;
        public int NewGradeID;
        public int OldBasicSalary;
        public int OldBasicSalaryID;
        public int NewBasicSalary;
        public int NewBasicSalaryID;
        public int ServiceYearAllowanceID;
        public string Note;
    }
}