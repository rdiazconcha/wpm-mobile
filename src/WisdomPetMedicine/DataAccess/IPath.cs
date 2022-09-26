namespace WisdomPetMedicine.DataAccess;
public interface IPath
{
    string GetDatabasePath(string filename = "wpm.db");
    void DeleteFile(string path);
}