public class School {
    public int ID;
    public string Name;
}

public class Employee {
    public int ID;
    public int SchoolID;
    public int ProfessionID;
    public int UnitID;
    public string NIK;
    public string Name;
    public string Photo;    
    public EmployeeDebt EmployeeDebt;   
}

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

public class EmployeeDebtInstallment{
    public int ID;
    public int DueMonth;
    public int DueYear;
    public int InstallmentAmount;
    public int InstallmentStatusID;
    public int Note;
}

// List Karyawan
public class EmployeeSearch{
    public int ID;
    public int SchoolID;
    public int ProfessionID;
    public int UnitID;
    public string NIK;
    public string Name;
    public string Photo;
}