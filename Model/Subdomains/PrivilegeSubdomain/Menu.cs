namespace Model.Subdomains.PrivilegeSubdomain{
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