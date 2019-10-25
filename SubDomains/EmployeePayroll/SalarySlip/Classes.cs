/**
 * Slip Gaji
 */
public class Employee<T> where T : EmployeeSalarySlip{
    public int ID;
    public int SchoolID;
    public int EmployeeStatusID;
    public int UnitID;
    public int ProfessionID;
    public string NIM;
    public string Name;
    public EmployeeSalarySlip<T> EmployeeSalarySlip;
}

public interface EmployeeSalarySlip{
    int GetNetSalary();
}

public class EmployeeSalarySlipPermanent : EmployeeSalarySlip{
    public List<MonthlyAllowance> MonthlyPGPSAllowanceList;
    public List<MonthlyAllowance> MonthlySpecialAllowanceList;
    public List<MonthlyDeduction> MonthlyDeductionList;
    public int GetNetSalary(){
        int totalNetSalary = 0;
        return totalNetSalary;
    }
}

public class EmployeeSalarySlipHonorer : EmployeeSalarySlip{
    public List<MonthlyAllowance> MonthlyAllowanceList;
    public List<MonthlyDeduction> MonthlyDeductionList;
    public int GetNetSalary(){
        int totalNetSalary = 0;
        return totalNetSalary;
    }
}

public class MonthlyAllowance {
    public int ID;
    public int AllowanceID;
    public int Variable1;
    public int Variable2;
    public int Variable3;
    public int Amount;

    public string AllowanceName;
    public string Formula;
}

public class MonthlyDeduction {
    public int ID;
    public int DeductionID;
    public int Amount;
    public string DeductionName;
}