namespace ProjectBook.Services;

public class IOAppService
{
    private bool appDataFolderExist => Directory.Exists(Consts.APPLOCAL_FOLDER);
    public static bool userInfoFileExist => File.Exists(Consts.USER_FILE);
    
    /// <summary>
    /// Create the application's AppData folder if don't exists. 
    /// </summary>
    /// <returns>Return true if create, if exists return false.</returns>
    public bool CreateAppDataFolder()
    {
        if(!appDataFolderExist) return false;
        
        Directory.CreateDirectory(Consts.APPLOCAL_FOLDER);
        return true;
    }
    
    public void CreateFontsFileDirectory() => Directory.CreateDirectory(Consts.FONTS_FOLDER);
    
    public static void DeleteUserInfoFile()
    {
        if(!userInfoFileExist) return;
        
        File.Delete(Consts.USER_FILE);
    }
}