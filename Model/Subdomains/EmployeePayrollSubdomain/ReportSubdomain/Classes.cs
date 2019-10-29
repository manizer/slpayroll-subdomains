public class School {
    public int ID;
    public string Name;
}

public class Profession {
    public int ID;
    public string Name;
}

public class Category {
    public int ID;
    public int Name;
}

public class FormalEducation{
    public int ID;
    public int EducationLevelID;
}

public class Employee{
    public int ID;
    public int SchoolID;
    public int UnitID;
    public int ProfessionID;
    public int ReligionID;
    public char Gender;
    public FormalEducation FormalEducation;
}