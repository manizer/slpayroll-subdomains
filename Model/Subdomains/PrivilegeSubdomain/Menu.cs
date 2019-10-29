namespace Model.Subdomains.PrivilegeSubdomain{
    /// <summary>
    /// Digunakan untuk:
    /// - Menampung data master menu, dimana setiap menu akan memiliki Privilege yang disesuaikan dengan Role
    /// </summary>
    public class Menu{
        public int ID;
        public string Name; 
        public Privilege Privilege;
        public bool IsRead;
        public bool IsUpdate;
        public bool IsDelete;
        public bool IsDownload;
    }
}