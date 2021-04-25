using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using ProjectBook.Properties;
using ClosedXML.Excel;

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
<<<<<<< HEAD
                MessageBox.Show(Strings.FaltaArquivoEscenciaisParaContinuar,
                    Strings.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
=======
                MessageBox.Show(Resources.está_faltando_arquivos_escenciais_para_abrir_o_programa__tente_reistalar_lo_novamente_,
                    Resources.error_MessageBox, MessageBoxButtons.OK, MessageBoxIcon.Error);
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
                Process.GetCurrentProcess().Kill();
            }

            mnuImprimirLista.Click += (sender, e) =>
            {
                Imprimir imprimir = new Imprimir();
                imprimir.ImprimirModelo(dgvLista);
            };
            mnuExportarExcel.Click += (sender, e) =>
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Pagina 1");

                //Colocar o cabeçalho
                for(int c = 1; c != dgvLista.Columns.Count; c++)
                {
                    worksheet.Cell(1, c).Style.Font.FontName = "Lato";
                    worksheet.Cell(1, c).Style.Font.Bold = true;
                    worksheet.Cell(1, c).Style.Fill.BackgroundColor = XLColor.DarkCyan;

                    worksheet.Cell(1, c).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(1, c).Style.Border.LeftBorderColor = XLColor.DarkGray;

                    worksheet.Cell(1, c).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(1, c).Style.Border.TopBorderColor = XLColor.DarkGray;

                    worksheet.Cell(1, c).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(1, c).Style.Border.RightBorderColor = XLColor.DarkGray;

                    worksheet.Cell(1, c).Value = dgvLista.Columns[c-1].HeaderText;
                }
                for(int r = 2; r != dgvLista.Rows.Count; r++)
                {
                    for(int c = 1; c != dgvLista.Columns.Count; c++)
                    {
                        worksheet.Cell(r, c).Style.Font.FontName = "Lato";

                        worksheet.Cell(r, c).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(r, c).Style.Border.LeftBorderColor = XLColor.DarkGray;

                        worksheet.Cell(r, c).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(r, c).Style.Border.TopBorderColor = XLColor.DarkGray;

                        worksheet.Cell(r, c).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(r, c).Style.Border.RightBorderColor = XLColor.DarkGray;

                        worksheet.Cell(r, c).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(r, c).Style.Border.BottomBorderColor = XLColor.DarkGray;

                        worksheet.Cell(r, c).Value = dgvLista.Rows[r-2].Cells[c-1].Value;
                    }
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Arquivo XLSX (*.xlsx) |*.xlsx| Arquivo XLSM (*.xlsm) |*.xlsm";
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                

                workbook.SaveAs(saveFileDialog.FileName);

<<<<<<< HEAD
                MessageBox.Show("Planilha salva com sucesso", Strings.MessageBoxInformacao, MessageBoxButtons.OK,
=======
                MessageBox.Show("Planilha salva com sucesso", Resources.informacao_MessageBox, MessageBoxButtons.OK,
>>>>>>> parent of e20e8c2 (v0.5.4-beta)
                    MessageBoxIcon.Information);
            };
        }
    }
}
