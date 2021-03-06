﻿using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using ProjectBook.Properties;
using ClosedXML.Excel;
using ProjectBook.AppInsight;
using System.Threading.Tasks;

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
                PrivateFontCollection privateFont = new();
                privateFont.AddFontFile(Application.StartupPath + @"font\Lato-Bold.ttf");
                Font lato = new(privateFont.Families[0], 8, FontStyle.Bold);

                int columnQuantidade = dgvLista.ColumnCount;
                for (int i = 0; i < columnQuantidade; i++)
                {
                    dgvLista.Columns[i].DefaultCellStyle.Font = lato;
                }
            }
            catch
            {
                MessageBox.Show(Resources.FaltaArquivoEscenciaisParaContinuar,
                    Resources.MessageBoxError, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Process.GetCurrentProcess().Kill();
            }

            #region MenuClick
            mnuImprimirLista.Click += async (sender, e) =>
            {
                pgbAsyncTask.Visible = true;

                if(!Verificadores.VerificarDataGrid(dgvLista))
                {
                    Imprimir imprimir = new();
                    await imprimir.ImprimirModelo(dgvLista);
                }

                pgbAsyncTask.Visible = false;
            };
            mnuExportarExcel.Click += async (sender, e) =>
            {
                pgbAsyncTask.Visible = true;

                if(!Verificadores.VerificarDataGrid(dgvLista)) await ExportToSheets();

                pgbAsyncTask.Visible = false;
            };
            #endregion

            Load += (_, _) => AppInsightMetrics.TrackForm("Lista");
        }

        private void ListaPesquisa_Load(object sender, System.EventArgs e)
        {
            lblQItensExibidos.Text = dgvLista.Rows.Count.ToString();
            lblQColunas.Text = dgvLista.ColumnCount.ToString();
        }

        private async Task ExportToSheets()
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Página 1");

            // Colocar o cabeçalho
            await Task.Run(() =>
            {
                for (int c = 1; c != dgvLista.Columns.Count; c++)
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

                    worksheet.Cell(1, c).Value = dgvLista.Columns[c - 1].HeaderText;
                }
            });

            // Colocar os valores
            await Task.Run(() =>
            {
                for (int r = 2; r != dgvLista.Rows.Count; r++)
                {
                    for (int c = 1; c != dgvLista.Columns.Count; c++)
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

                        worksheet.Cell(r, c).Value = dgvLista.Rows[r - 2].Cells[c - 1].Value;
                    }
                }
            });

            SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "Arquivo XLSX (*.xlsx) |*.xlsx| Arquivo XLSM (*.xlsm) |*.xlsm";
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;


            workbook.SaveAs(saveFileDialog.FileName);
            MessageBox.Show("Planilha salva com sucesso", Resources.MessageBoxInformacao, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
