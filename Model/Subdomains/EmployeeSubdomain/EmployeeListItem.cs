namespace Model.Subdomains.EmployeeSubdomain{
    /// <summary>
    /// Digunakan untuk menampilkan item dalam List Karyawan
    /// </summary>
    public class EmployeeListItem{
        public int ID;
        public string Code;
        public string Name;
        public string PhoneNumber;
        public int ProfessionID;
        public int EmployeeStatusID;
        public bool IsBPJSKesehatan;
        public bool IsBPJSKetenagaKerjaan;
    }
}