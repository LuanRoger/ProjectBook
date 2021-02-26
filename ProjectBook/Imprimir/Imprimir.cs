using DGVPrinterHelper;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

namespace ProjectBook
{
    class Imprimir
    {
        private DGVPrinter printer = new DGVPrinter();

        public void ImprimirModelo(DataGridView dataGrid)
        {
            if (ConfigurationManager.AppSettings["ExibirID"] == "0") 
                try { dataGrid.Columns.Remove(dataGrid.Columns["ID"]); } catch { /* Continuar */ } //Remover coluna ID

            printer.Title = ConfigurationManager.AppSettings["TituloFolha"];
            printer.TitleAlignment = StringAlignment.Center;
            printer.TitleFont = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Point);

            printer.SubTitle = ConfigurationManager.AppSettings["SubtituloFolha"];
            printer.SubTitleAlignment = StringAlignment.Center;
            printer.SubTitleFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            
            printer.Footer = ConfigurationManager.AppSettings["Rodape"];
            printer.FooterFont = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);

            printer.PageNumbers = ConfigurationManager.AppSettings["NumeroPaginas"] == "1";
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;

            if (ConfigurationManager.AppSettings["visualizarImpressao"] == "0") printer.PrintDataGridView(dataGrid);
            else printer.PrintPreviewDataGridView(dataGrid);
        }

    }
}
