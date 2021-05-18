using System;
using DGVPrinterHelper;
using System.Configuration;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectBook
{
    class Imprimir
    {
        private DGVPrinter printer = new();

        public void ImprimirModelo(DataGridView dataGrid)
        {
            if (ConfigurationManager.AppSettings["ExibirID"] == "0") 
                try { dataGrid.Columns.Remove(dataGrid.Columns["ID"]); } catch { /* Continuar */ } //Remover coluna ID se existir

            printer.PreviewDialogIcon = Properties.Resources.PrinteIcons;

            printer.Title = ConfigurationManager.AppSettings["TituloFolha"];
            printer.TitleAlignment = (StringAlignment)int.Parse(ConfigurationManager.AppSettings["AlinhamentoTitulo"]);
            printer.TitleFont = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Point);

            printer.SubTitle = ConfigurationManager.AppSettings["SubtituloFolha"];
            printer.SubTitleAlignment = (StringAlignment)int.Parse(ConfigurationManager.AppSettings["AlinhamentoSubtitulo"]);
            printer.SubTitleFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            
            printer.ColumnWidth = DGVPrinter.ColumnWidthSetting.Porportional;
            printer.CellFormatFlags = StringFormatFlags.NoClip | StringFormatFlags.LineLimit;

            printer.Footer = ConfigurationManager.AppSettings["Rodape"];
            printer.FooterAlignment = (StringAlignment)int.Parse(ConfigurationManager.AppSettings["AlinhamentoRodape"]);
            printer.FooterFont = new Font("Arial", 10, FontStyle.Bold, GraphicsUnit.Point);
            printer.FooterFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;

            printer.PageNumbers = ConfigurationManager.AppSettings["NumeroPaginas"] == "1";
            if (printer.PageNumbers)
            {
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
            }

            if (ConfigurationManager.AppSettings["visualizarImpressao"] == "0")
                printer.PrintDataGridView(dataGrid);
            else printer.PrintPreviewDataGridView(dataGrid);
        }

    }
}
