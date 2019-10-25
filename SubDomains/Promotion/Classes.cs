public class School {
    public int ID;
    public string Name;
}

public class RecommendedEmployee<T>{
    public int ID;
    public string Photo;
    public string NIK;
    public string Name;
    public int ProfessionID;
    public int UnitID;
    T BasicSalary;
    DecisionInformation DecisionInformation;
}

public class DecisionInformation{
    public string SKNumber;
    public DateTime SKDate;
    public string Note;
    public int PromotionStatusID;
}

public abstract class BasicSalary{
    protected SchoolBasicSalaryPermanent SchoolBasicSalaryPermanent;
    public BasicSalary(SchoolBasicSalaryPermanent schoolBasicSalaryPermanent){
        SchoolBasicSalaryPermanent = schoolBasicSalaryPermanent;
    }
    BasicSalaryPermanent GetNextBasicSalary();
}

public class BasicSalaryHonorer : BasicSalary{
    public int ID;
    public int SchoolID;
    public int UnitID;
    public int Value;
    public string Formula;
}

public class BasicSalaryPermanent : BasicSalary{
    public int ID;
    public int GradeID;
    public int SchoolID;
    public int WorkPeriod;
    public int Value;
}

public class SchoolBasicSalaryPermanent{
    public LinkedList<BasicSalaryPermanentsBySchool> BasicSalaryPermanentsBySchool;
    private BasicSalaryPermanent CurrentBasicSalaryPermanent;

    public SchoolBasicSalaryPermanent(LinkedList<BasicSalaryPermanent> BasicSalaryPermanentsBySchool){
        this.BasicSalaryPermanentsBySchool = BasicSalaryPermanentsBySchool;
    }

    public void SetCurrentBasicSalaryPermanent(int BasicSalaryPermanentID = 0){
        if(BasicSalaryPermanentID == 0) CurrentBasicSalaryPermanent = null;
        else CurrentBasicSalaryPermanent = BasicSalaryPermanentsBySchool.Find(x => x.ID == BasicSalaryPermanentID);
    }

    public BasicSalaryPermanent GetNextBasicSalaryPermanent(){
        // 
    }
}