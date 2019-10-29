namespace Model.Subdomains.UserProfileSubdomain{
    /// <summary>
    /// Digunakan utk:
    /// - Simple Profil & Profil
    /// - Load list User
    /// - User detail, update user
    /// </summary>
    public class UserProfile{
        public int ID;
        public string PhotoURL;
        public string FullName;
        public int SchoolID;
        public int RoleID;
        public string NIK;
        public string Email;
        public string PhoneNumber;
        public DateTime LastLogin;
    }
}