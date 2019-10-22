public class School {
    public int ID;
    public string Name;
}

public class Employee<T> where T : MonthlyPayroll{
    public int ID;
    public int SchoolID;
    public int EmployeeStatusID;
    public int UnitID;
    public int ProfessionID;
    public string NIM;
    public string Name;
    public EmployeePayroll<T> EmployeePayroll;
}

public class EmployeePayroll<T> where T: MonthlyPayroll {
    public T MonthlyPayroll;
    public int WorkingDays;
    public int WorkingHours;
}

public interface MonthlyPayroll {
    int GetTotalIncome();
    int GetTotalDeduction();
}

public class MonthlyPayrollPermanent : MonthlyPayroll {
    public List<MonthlyAllowanceEntry> ListPGPS;
    public List<MonthlyAllowanceEntry> ListSpecialAllowance;
    public List<MonthlyAllowanceEntry> ListAdditionalAllowance;
    public List<MonthlyDeductionEntry> ListDeduction;
    public List<MonthlyDeductionEntry> ListAdditionalDeduction;
}

public class MonthlyPayrollHonorer : MonthlyPayroll {
    public List<MonthlyAllowanceEntry> ListAllowance;
    public List<MonthlyAllowanceEntry> ListAdditionalAllowance;
    public List<MonthlyDeductionEntry> ListDeduction;
    public List<MonthlyDeductionEntry> ListAdditionalDeduction;
}

public class MonthlyAllowanceEntry {
    public int AllowanceID;
    public string Name;
    public int Amount;
}

public class MonthlyDeductionEntry {
    public int DeductionID;
    public string Name;
    public int Amount;
}

/**
 * Allowance yang di suffix "Detail" berfungsi saat pembuatan payroll (transaksi ke table monthlyallowance, dsb)
 */
public class MonthlyAllowanceDetail{
    public int ID;
    public int MonthlyPayrollDetailID;
    public int AllowanceID;
    public float Variable1;
    public float Variable2;
    public float Variable3;
    public int Amount;
}

public class MonthlyAdditionalAllowanceDetail{
    public int ID;
    public int MonthlyPayrollDetailID;
    public int AdditionalAllowanceID;
    public int Amount;
}

public class MonthlyDeductionDetail{
    public int ID;
    public int MonthlyPayrollDetailID;
    public int DeductionID;
    public int Amount;
}

public class MonthlyAdditionalDeductionDetail{
    public int ID;
    public int MonthlyPayrollDetailID;
    public int AdditionalDeductionID;
    public int Amount;
}   