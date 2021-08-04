using System.Threading.Tasks;
using System.Windows.Forms;
using KimToo;
using ProjectBook.Managers;
using ProjectBook.Managers.Configuration;

namespace ProjectBook
{
    class Imprimir
    {
        private EasyHTMLReports reports = new();
        public async Task ImprimirModelo(DataGridView dataGrid)
        {
            if (AppConfigurationManager.configuration.ShowId)
                try { dataGrid.Columns.Remove(dataGrid.Columns["ID"]); } catch { /* Continuar */ } // Remover coluna ID se existir

            await Task.Run(() => reports.AddDatagridView(dataGrid));

            if (AppConfigurationManager.configuration.PreviewPrinter) reports.Print();
            else reports.ShowPrintPreviewDialog();

            reports.Dispose();
        }
    }
}
