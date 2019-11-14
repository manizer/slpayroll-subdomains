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
        public int NewBasicSalary;
        public int ServiceYearAllowanceID;
        public string Note;
        /**
         * Kurang Massa Kerja/Gaji Pokok
         */
    }
}