using System;
using System.Windows.Forms;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class GetInput : Form
    {
        public string input { get; private set; }
        public bool hasCanceled { get; private set; }
        private string windowTitle { get; }
        private bool canBeNull { get; }

        public GetInput(string windowTitle, bool canBeNull = false)
        {
            InitializeComponent();
            
            this.windowTitle = windowTitle;
            this.canBeNull = canBeNull;
        }

        private void GetInput_Load(object sender, EventArgs e)
        {
            Text = windowTitle;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserInput.Text) && !canBeNull)
            {
                MessageBox.Show(Resources.PreencherCamposObrigatorios, Resources.Error_MessageBox, MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            input = txtUserInput.Text;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            hasCanceled = true;
            Close();
        }
    }
}
