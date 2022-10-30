using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace ProjectBook.Controllers;

public class AppController
{
    private static string applicationPath => 
        Application.StartupPath + Assembly.GetExecutingAssembly().GetName().Name + ".exe";
    
    public static void RestartApplication()
    {
        Process.Start(applicationPath);
        Process.GetCurrentProcess().Kill();
    }
}