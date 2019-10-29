public class EmployeeProfile: EmployeeStatus{
    public int ID;
    public int Name;
    public string PhotoURL;
    public string BirthPlace;
    public DateTime Birthdate;
    public char Gender;
    // kewarganegaraan
    public int ReligionID;
    public int MarriageStatusID;
    public string Address;
    public EmployeeWorkInformation EmployeeWorkInformation;
    public PermanentEmployeeInformation PermanentEmployeeInformation;
    public EducationHistory EducationHistory;
    public FamilyInsurance FamilyInsurance;

    public bool IsPermanentEmployee() => true;
    public bool IsRangkapEmployee() => true;
    public bool IsHonorerEmployee() => true;
}

public interface EmployeeStatus{
    bool IsPermanentEmployee();
    bool IsRangkapEmployee();
    bool IsHonorerEmployee();
}

public class EmployeeWorkInformation{
    public string NIK;
    public string PhoneNum;
    public string Email;
    public int ProfessionID;
    public int UnitID;
    public int SchoolID;
    public int EmployeeStatusID;
    public int PositionID;
    public DateTime JoinDate;
    public int BankNumber;
    public int RangkapUnitID;
}

public class PermanentEmployeeInformation{
    public int GradeID;
    public int BasicSalaryPermanentID;
    public DateTime PermanentPromotionDate;
    public string LastSKNumber;
    public DateTime LastSKDate;
    // tunjangan masa kerja
    public int LastPromotionTypeID;
    public DateTime StartSKElligibleDate;
    public DateTime EndSKElligibleDate;
}

public class EducationHistory{
    public FormalEducationHistory FormalEducationHistory;
    public List<InformalEducationHistory> InformalEducationHistories;
}

public class FormalEducationHistory{
    public int LastEducationID;
    public string InstitutionName;
    public string Major;
    public int GraduationYear;
}

public class InformalEducationHistory{
    public string InstitutionName;
    public int Year;
    public string CourseName;
    public string CourseDuration;
}

public class FamilyInsurance{
    public SpouseData SpouseData;
    public List<Child> Children;
}

public class SpouseData{
    public string Name;
    public string Birthplace;
    public DateTime Birthdate;
    public int EducationID;
    public string Work;
    public string MarriageLocation;
    public DateTime MarriageDate;
}

public class Child{
    public int ChildNumber;
    public string Name;
    public string Birthplace;
    public DateTime Birthdate;
}

public class BasicSalaryPermanent{
    public int ID;
    public int WorkPeriod;
    public int Value;
}

/**
 * List Karyawan
 */
public class EmployeeEntry{
    public int ID;
    public string Code;
    public string Name;
    public string PhoneNumber;
    public int ProfessionID;
    public int EmployeeStatusID;
    public bool IsBPJSKesehatan;
    public bool IsBPJSKetenagaKerjaan;
}