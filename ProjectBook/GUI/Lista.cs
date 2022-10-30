using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using ProjectBook.Properties;
using ClosedXML.Excel;
using ProjectBook.Util.Extensions;

namespace ProjectBook.GUI
{
    public partial class ListaPesquisa<T> : Form
    {
        private List<T> dataList { get; }
        public ListaPesquisa(List<T> dataList)
        {
            InitializeComponent();
            
            this.dataList = dataList;
            
            #region MenuClick
            mnuImprimirLista.Click += async (_, _) =>
            {
                pgbAsyncTask.Visible = true;

                if(!Verificadores.VerificarDataGrid(dgvLista))
                {
                    Imprimir.Imprimir imprimir = new();
                    await imprimir.ImprimirModelo(dgvLista);
                }

                pgbAsyncTask.Visible = false;
            };
            mnuExportarExcel.Click += async (_, _) =>
            {
                pgbAsyncTask.Visible = true;

                if(!Verificadores.VerificarDataGrid(dgvLista)) await ExportToSheets();

                pgbAsyncTask.Visible = false;
            };
            #endregion
        }

        private async void ListaPesquisa_Load(object sender, EventArgs e)
        {
            SetFonts();
            
            dgvLista.DataSource = await dataList.ToDataTableAsync();
            
            lblQItensExibidos.Text = dgvLista.Rows.Count.ToString();
            lblQColunas.Text = dgvLista.ColumnCount.ToString();
        }

        private void SetFonts()
        {
            PrivateFontCollection privateFont = new();
            try { privateFont.AddFontFile(Consts.FONT_LATO_BOLD); }
            catch { /*Nothing*/ }
            
            Font lato = new(privateFont.Families.Length > 1 ? privateFont.Families[0] : new("Arial"),
                8, FontStyle.Bold);
            
            foreach (DataGridViewColumn gridViewColumn in dgvLista.Columns)
                gridViewColumn.DefaultCellStyle.Font = lato;
        }

        private async Task ExportToSheets()
        {
            XLWorkbook workbook = new();
            IXLWorksheet worksheet = workbook.Worksheets.Add("Página 1");

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
            saveFileDialog.Filter = Consts.EXCEL_FILE_FILTER;
            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;


            workbook.SaveAs(saveFileDialog.FileName);
            MessageBox.Show(Resources.PlanilhaSalva, Resources.Informacao_MessageBox, MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
