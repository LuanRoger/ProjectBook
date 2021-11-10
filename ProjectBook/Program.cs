using System;
using System.Windows.Forms;
using ProjectBook.GUI;
using ProjectBook.Properties;

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
            catch(Exception e) 
            { 
                MessageBox.Show("Não foi possivel inicializar o programa: " + e.Message,
                    Resources.Error_MessageBox,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                AppInsight.AppInsightMetrics.SendError(e);
            }
        }
    }
}
