namespace Model.Subdomains.PrivilegeSubdomain{
    /// <summary>
    /// Privilege untuk sebuah menu bergantung pada RoleID yang sedang dipilih
    /// </summary>
    public class Privilege{
        public int ID;
        public int RoleID;
        public bool IsRead;
        public bool IsUpdate;
        public bool IsDelete;
        public bool IsDownload;
    }
}