namespace Model.Subdomains.EmployeeSubdomain{
    /// <summary>
    /// Informasi Personal seorang karyawan
    /// </summary>
    public class EmployeeProfile{
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
        public EmployeeJobInformation EmployeeJobInformation;
        public PermanentEmployeeInformation PermanentEmployeeInformation;
        public EducationHistory EducationHistory;
        public Family Family;
    }
}