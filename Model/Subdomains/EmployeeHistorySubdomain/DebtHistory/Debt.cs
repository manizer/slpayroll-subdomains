namespace Model.Subdomains.EmployeeHistorySubdomain.DebtHistory {
    public class Debt{
        public int ID;
        public int DebtStatusID;
        public DateTime StartDate;
        public int Amount;
        public int RemainingDebt(){
            return 0;
        }
    }
}