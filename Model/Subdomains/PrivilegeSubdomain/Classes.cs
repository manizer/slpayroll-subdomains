public class Role{
    public int ID;
    public int Name;
}

public class Menu{
    public int ID;
    public string Name; 
    public Privilege Privilege;
    public bool IsRead;
    public bool IsUpdate;
    public bool IsDelete;
    public bool IsDownload;
}

public class Privilege{
    public int ID;
    public int RoleID;
    public bool IsRead;
    public bool IsUpdate;
    public bool IsDelete;
    public bool IsDownload;
}