namespace Data.DBData
{
    public static class Lookup
    {
        public static class DebtInstallmentStatus
        {
            public const int BELUM_DIBAYAR = 1;
            public const int TELAH_DIBAYAR = 2;
            public const int DIANGGAP_LUNAS = 3;
        }

        public static class DebtStatus
        {
            public const int BELUM_LUNAS = 1;
            public const int LUNAS = 2;
        }

        public static class ReportCategory
        {
            public const int AGAMA = 1;
            public const int JENIS_KELAMIN = 2;
            public const int IJAZAH = 3;
            public const int TOTAL = 4;
        }

        public static class EmployeeStatus
        {
            public const int HONORER = 1;
            public const int PERMANEN = 2;
            public const int RANGKAP = 3;
            public const int TIDAK_AKTIF = 4;
        }

        public static class AllowanceType
        {
            public const int TETAP_PGPS = 1;
            public const int TETAP_KHUSUS = 2;
            public const int HONORER = 3;
        }
    }
}