namespace Model.Subdomains.UserSubdomain{
    class School: MasterData{
        public int ID;
        public int Name;
        public int ID() => this.ID;
        public string Name() => this.Name;
    }
}