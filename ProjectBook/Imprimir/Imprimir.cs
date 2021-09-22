using System.Threading.Tasks;
using System.Windows.Forms;
using KimToo;
using ProjectBook.Managers.Configuration;

namespace ProjectBook
{
    class Imprimir
    {
        private EasyHTMLReports reports = new();
        public async Task ImprimirModelo(DataGridView dataGrid)
        {
            if (AppConfigurationManager.configuration.printer.ShowId && dataGrid.Columns["ID"] != null)
                dataGrid.Columns.Remove(dataGrid.Columns["ID"]);

            await Task.Run(() => reports.AddDatagridView(dataGrid));

            if (AppConfigurationManager.configuration.printer.PreviewPrinter) reports.Print();
            else reports.ShowPrintPreviewDialog();

            reports.Dispose();
        }
    }
}
