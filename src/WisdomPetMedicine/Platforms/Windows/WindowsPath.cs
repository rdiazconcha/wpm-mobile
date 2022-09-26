namespace WisdomPetMedicine.DataAccess;
public class DbPath : IPath
{
    public void DeleteFile(string path)
    {
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public string GetDatabasePath(string filename = "wpm.db")
    {
        var localPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        return Path.Combine(localPath, filename);
    }
}