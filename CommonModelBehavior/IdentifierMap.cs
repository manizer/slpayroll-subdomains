public interface MasterData{
    int MasterDataID();
    string MasterDataName();
}

public static class MasterDataExtensions{
    public static string GetMasterDataName<T>(this List<T> MasterDatas, int MasterDataID){
        if(!(T is MasterData)) throw new System.Exception($"{T} is not an instance of MasterDate");
        for(int i = 0 ; i < MasterDatas.Count ; i++){
            if(((MasterData) MasterDatas[i]).MasterDataID() == MasterDataID) {
                return ((MasterData) MasterDatas[i]).MasterDataName();
            }
        }
    }
}

/**
 * Sample
 */
public class School: MasterData{
    public int ID;
    public string Name;
    public MasterDataID() => this.ID;
    public MasterDataName() => this.Name;
}

List<School> Schools = SchoolsFromDB();
string SchoolName = Schools.GetMasterDataName<School>(5);