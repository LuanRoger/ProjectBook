using System.Configuration;
using System.Windows.Forms;
using KimToo;

namespace ProjectBook
{
    class Imprimir
    {
        private EasyHTMLReports reports = new();
        public void ImprimirModelo(DataGridView dataGrid)
        {
            if (AppConfigurationManager.exibirId) 
                try { dataGrid.Columns.Remove(dataGrid.Columns["ID"]); } catch { /* Continuar */ } //Remover coluna ID se existir

            reports.AddDatagridView(dataGrid);

            if (AppConfigurationManager.visualizarImpressao)
                reports.Print();
            else reports.ShowPrintPreviewDialog();
        }

    }
}
