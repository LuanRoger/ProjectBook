using NetMsixUpdater;
using System.Reflection;
using NetMsixUpdater.Updater.Extensions;

namespace ProjectBook.Managers
{
    public static class AppUpdateManager
    {
        private static MsixUpdater updater
        {
            get
            {
                MsixUpdater msixUpdater = new(Assembly.GetExecutingAssembly(), Consts.YAML_UPDATER_SERVER_URL);
                msixUpdater.Build();

                return msixUpdater;
            }
        }

        public static bool hasUpdated() => updater.hasUpdated;

        public static void Update() => updater.VerifyAndDownload();
    }
}
