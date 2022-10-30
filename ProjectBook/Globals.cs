using ProjectBook.Controllers;

namespace ProjectBook;

public static class Globals
{
    private static DatabaseController? _databaseController { get; set; }
    public static DatabaseController databaseController
    {
        get
        {
            _databaseController ??= new();
            
            return _databaseController;
        }
    }
    public static bool isDatabaseControllerInited => _databaseController != null;
    
    private static ConfigurationController? _configurationController { get; set; }
    public static ConfigurationController configurationController
    {
        get
        {
            _configurationController ??= new();
            
            return _configurationController;
        }
    }
    public static bool isConfigurationControllerInited => _configurationController != null;
    
    private static UserSessionController? _userSessionController { get; set; }

    public static UserSessionController userSessionController
    {
        get
        {
            _userSessionController ??= new();
            
            return _userSessionController;
        }
    }
}