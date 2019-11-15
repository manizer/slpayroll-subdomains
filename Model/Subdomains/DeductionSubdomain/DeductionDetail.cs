namespace Model.Subdomains.AllowanceSubdomain.Permanent{
    /// <summary>
    /// Untuk halaman formula potongan, hasil join table msDeductionDetail
    /// </summary>
    class DeductionDetail{
        public int ID;
        public float PercentageValue;
        public int MinimumValue;
        public List<Allowance> Allowances;
        public List<AdditionalAllowance> AdditionalAllowances;
    }
}