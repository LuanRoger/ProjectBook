using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using ProjectBook.Properties;

namespace ProjectBook.GUI
{
    public partial class ListaPesquisa : Form
    {
        public ListaPesquisa(DataTable data)
        {
            InitializeComponent();

            dgvLista.DataSource = data;

            try
            {
                PrivateFontCollection privateFont = new PrivateFontCollection();
                privateFont.AddFontFile(Application.StartupPath + @"font\Lato-Bold.ttf");
                Font lato = new Font(privateFont.Families[0], 8, FontStyle.Bold);

                int columnQuantidade = dgvLista.ColumnCount;
                for (int i = 0; i < columnQuantidade; i++)
                {
                    dgvLista.Columns[i].DefaultCellStyle.Font = lato;
                }
            }
            catch
            {
                MessageBox.Show(Resources.está_faltando_arquivos_escenciais_para_abrir_o_programa__tente_reistalar_lo_novamente_,
                    Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
            }

            mnuImprimirLista.Click += (sender, e) =>
            {
                Imprimir imprimir = new Imprimir();
                imprimir.ImprimirModelo(dgvLista);
            };
            mnuExportarExcel.Click += (sender, e) => throw new NotImplementedException();
        }
    }
}
