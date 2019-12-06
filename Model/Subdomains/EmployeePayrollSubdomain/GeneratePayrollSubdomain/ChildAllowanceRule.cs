using static Data.DBData.Lookup;

namespace Model.Subdomains.EmployeePayrollSubdomain.GeneratePayrollSubdomain
{
    public static class ChildAllowanceRule
    {
        public static bool ValidateAge(DateTime dateOfBirth)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));
            int age = (now - dob) / 1000;

            if (age >= AllowanceRule.MAKS_UMUR_ANAK)
                return false;
            else
                return true;
        }
    }
}