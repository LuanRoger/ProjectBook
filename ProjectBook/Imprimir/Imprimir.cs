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
            if (ConfigurationManager.AppSettings["ExibirID"] == "0") 
                try { dataGrid.Columns.Remove(dataGrid.Columns["ID"]); } catch { /* Continuar */ } //Remover coluna ID se existir

            reports.AddDatagridView(dataGrid);

            if (ConfigurationManager.AppSettings["visualizarImpressao"] == "0")
                reports.Print();
            else reports.ShowPrintPreviewDialog();
        }

    }
}
