using ProjectBook.Controllers;

namespace ProjectBook.Managers
{
    public static class AppManagers
    {
        private static AppController? _appController { get; set; } = new();

        public static AppController appController
        {
            get
            {
                _appController ??= new();
                
                return _appController;
            }
        }
        
        private static ConfigurationController? _configurationController { get; set; }

        public static ConfigurationController configurationController
        {
            get
            {
                _configurationController ??= new();
                
                return _configurationController;
            }
        }

        private static UserSessionController? _sessionController { get; set; } = new();

        public static UserSessionController sessionController
        {
            get
            {
                _sessionController ??= new();
                
                return _sessionController;
            }
        }
    }
}
