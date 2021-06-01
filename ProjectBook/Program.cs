using System;
using System.Windows.Forms;
using ProjectBook.GUI;

namespace ProjectBook
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new Inicio());
            }
            catch(Exception e) { AppInsight.AppInsightMetrics.SendError(e); }
        }
    }
}
