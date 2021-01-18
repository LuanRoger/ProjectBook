using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DGVPrinterHelper;
using ProjectBook.DB;
using System.Configuration;

namespace ProjectBook
{
    public partial class ListaLivros : Form
    {
        public ListaLivros(DataTable data)
        {
            InitializeComponent();
            dgvListaLivros.DataSource = data;

            mnuImprimirLista.Click += (sender, e) =>
            {
                Imprimir imprimir = new Imprimir();
                
                if (ConfigurationManager.AppSettings["visualizarImpressao"] == "0") imprimir.ImprimirSemVisualizacaoModelo(dgvListaLivros);
                else imprimir.ImprimirModelo(dgvListaLivros);
            };
        }
    }
}
