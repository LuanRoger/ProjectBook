using System.Reflection;
using NetMsixUpdaterFormsComponent.Enum;
using NetMsixUpdaterFormsComponent.Forms;

namespace ProjectBook.Managers
{
    public static class AppUpdateManager
    {
        private static UpdateForm _updateForm { get; set; }
        private static UpdateForm updateForm
        {
            get
            {
                if (_updateForm != null && !_updateForm.IsDisposed) return _updateForm;
                
                _updateForm = new(new(Assembly.GetExecutingAssembly(), Consts.YAML_UPDATER_SERVER_URL, "prod"));
                _updateForm.mandatoryType = MandatoryType.AutoUpdate;
                _updateForm.showUpdateState = true;

                return _updateForm;
            }
        }
        public static void StartUpdate() => updateForm.Start();
    }
}
