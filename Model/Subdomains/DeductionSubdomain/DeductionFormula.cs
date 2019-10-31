namespace Model.Subdomains.AllowanceSubdomain.Permanent{
    /// <summary>
    /// 
    /// </summary>
    class DeductionFormula{
        public int DeductionID;
        public int DeductionFormulaID;
        public string Name;
        public string Formula;
        public float PercentageValue;
        public int MinimumValue;
        public int AllowanceIds;
        public int AdditionalAllowanceIds;
    }
}