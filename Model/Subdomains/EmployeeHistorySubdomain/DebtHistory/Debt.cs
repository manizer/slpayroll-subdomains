namespace Model.Subdomains.EmployeeHistorySubdomain.DebtHistory {
    public class Debt: IEmployeeHistoryItem{
        public int ID;
        public int DebtStatusID;
        public DateTime StartDate;
        public int Amount;
        public int RemainingDebt(){
            return 0;
        }
        public List<DebtInstallment> DebtInstallments;
    }
}