using System.Drawing;
using System.Drawing.Text;
using System.Reflection;
using System.Windows.Forms;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class Sobre : Form
    {
        public Sobre()
        {
            InitializeComponent();
        }

        private void Sobre_Load(object sender, System.EventArgs e)
        {
            PrivateFontCollection privateFont = new PrivateFontCollection();
            privateFont.AddFontFile(Application.StartupPath + @"font\\Montserrat-ExtraBold.ttf");
            lblProgramName.Font = new Font(privateFont.Families[0], 20, FontStyle.Bold);

            lblProgramName.Text = Assembly.GetExecutingAssembly().GetName().Name;
            lblProgramVersion.Text = $"v{Assembly.GetExecutingAssembly().GetName().Version}";

            lblCreditsIcons.Text = Resources.CreditosIcones;
            lblProjectUrl.Text = Resources.UrlProjeto;
            lblCreator.Text = Resources.TheCreator;
            lblLicense.Text = Resources.Licensa;
        }
    }
}
