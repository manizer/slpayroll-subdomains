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

        public static class Allowance
        {
            public const int TETAP_PGPS_GAJI_POKOK = 1;
            public const int TETAP_PGPS_ISTRI = 2;
            public const int TETAP_PGPS_ANAK = 3;
            public const int TETAP_PGPS_BERAS = 4;
            public const int TETAP_PGPS_FUNGSIONAL = 5;
            public const int TETAP_PGPS_JABATAN = 6;
            public const int TETAP_KHUSUS_KARYA = 7;
            public const int TETAP_KHUSUS_ISTRI = 8;
            public const int TETAP_KHUSUS_ANAK = 9;
            public const int TETAP_KHUSUS_MASA_KERJA = 10;
            public const int TETAP_KHUSUS_TRANSPORT_DAN_MAKAN = 11;
            public const int TETAP_KHUSUS_PENGOBATAN = 12;
            public const int TETAP_KHUSUS_JAM_KERJA_LEBIH = 13;
            public const int HONORER_GAJI_POKOK = 14;
            public const int HONORER_PENGOBATAN = 15;
            public const int HONORER_TRANSPORT_DAN_MAKAN = 16;
            public const int HONORER_JABATAN = 17;
        }

        public static class AllowanceRule
        {
            public const int BATAS_JUMLAH_ANAK = 3;
            public const int MAKS_UMUR_ANAK = 21;
        }
    }
}