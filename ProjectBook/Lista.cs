using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace ProjectBook
{
    public partial class ListaPesquisa : Form
    {
        public ListaPesquisa(DataTable data)
        {
            InitializeComponent();
            dgvListaLivros.DataSource = data;

            mnuImprimirLista.Click += (sender, e) =>
            {
                Imprimir imprimir = new Imprimir();
                switch (ConfigurationManager.AppSettings["visualizarImpressao"])
                {
                    case "0":
                        imprimir.ImprimirSemVisualizacaoModelo(dgvListaLivros);
                        break;
                    case "1":
                        imprimir.ImprimirModelo(dgvListaLivros);
                        break;
                }
            };
        }
    }
}
