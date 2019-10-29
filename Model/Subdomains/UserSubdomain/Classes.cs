class User{
    public string PhotoURL;
    public string NIK;
    public string Name;
    public string Email;
    public string PhoneNumber;
    public int RoleID;
    public int SchoolID;
    public DateTime LastLogin;
}

class School: MasterData{
    public int ID;
    public int Name;
    public int ID() => this.ID;
    public string Name() => this.Name;
}

// controller
List<School> Schools = SchoolsFromDB();
string SchoolName = Schools.GetMasterDataName<School>(5);