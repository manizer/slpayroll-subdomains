namespace Model.Subdomains.EmployeePayrollSubdomain.DebtSubdomain{
    public class EmployeeDebt {
        public int ID;
        public int DebtStatusID;
        public DateTime StartDate;
        public int Value;
        public List<EmployeeDebtInstallment> Installments;
        public int GetRemainingDebt(){
            int RemainingDebt = this.Value;
            Installments.ForEach(x => {
                if(x.InstallmentStatusID == Lookup.DebtInstallmentStatus.DIANGGAP_LUNAS || 
                    x.InstallmentStatusID == Lookup.DebtInstallmentStatus.TELAH_DIBAYAR)
                    RemainingDebt -= x.InstallmentAmount;
            });
            return RemainingDebt;
        }
    }
}