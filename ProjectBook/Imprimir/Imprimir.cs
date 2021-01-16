using DGVPrinterHelper;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectBook
{
    class Imprimir
    {
        private DGVPrinter printer = new DGVPrinter();

        public void ImprimirSemVisualizacaoModelo(DataGridView dataGrid)
        {
            try { dataGrid.Columns.Remove(dataGrid.Columns["ID"]); } catch { /* Continuar */ } //Remover coluna ID

            printer.Title = "Relatorio de livros";
            printer.TitleAlignment = StringAlignment.Center;
            printer.TitleFont = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Point);
            printer.SubTitleAlignment = StringAlignment.Center;
            printer.SubTitleFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.PageNumbers = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = $"{DateTime.Now}";
            printer.FooterFont = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            printer.PrintDataGridView(dataGrid);
        }
        public void ImprimirModelo(DataGridView dataGrid)
        {
            try { dataGrid.Columns.Remove(dataGrid.Columns["ID"]); } catch { /* Continuar */ } //Remover coluna ID

            printer.Title = "Relatorio de livros";
            printer.TitleAlignment = StringAlignment.Center;
            printer.TitleFont = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Point);
            printer.SubTitleAlignment = StringAlignment.Center;
            printer.SubTitleFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.PageNumbers = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = $"{DateTime.Now}";
            printer.FooterFont = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            printer.PrintPreviewDataGridView(dataGrid);
        }

    }
}
