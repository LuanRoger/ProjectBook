using ProjectBook.DB.SqlServerExpress;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjectBook
{
    public partial class ExcluirAluguel : Form
    {
        AluguelDb aluguelDb = new AluguelDb();
        public ExcluirAluguel()
        {
            InitializeComponent();
        }

        private void btnBuscarExcluirAluguel_Click(object sender, EventArgs e)
        {
            if (rabExcluirAluguelTitulo.Checked == true)
            {
                aluguelDb.AbrirConexaoDb();
                DataTable data = aluguelDb.BuscarAluguelLivro(txtBuscaAluguel.Text);
                aluguelDb.FechaConecxaoDb();

                if (Verificadores.VerificarDataTable(data) == true)
                {
                    MessageBox.Show("Este livro não existe", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult resultadoExcluir = MessageBox.Show($"Deseja realmente excluir {data.Rows[0][0]} alugado por {data.Rows[0][2]}?",
                "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                aluguelDb.AbrirConexaoDb();
                if (resultadoExcluir == DialogResult.Yes) aluguelDb.DeletarAluguelTitulo(data.Rows[0][0].ToString());
                aluguelDb.FechaConecxaoDb();
            }
            else if (rabExcluirAluguelCliente.Checked == true)
            {
                aluguelDb.AbrirConexaoDb();
                DataTable data = aluguelDb.BuscarAluguelCliente(txtBuscaAluguel.Text);
                aluguelDb.FechaConecxaoDb();

                if (Verificadores.VerificarDataTable(data) == true)
                {
                    MessageBox.Show("Este livro não existe", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DialogResult resultadoExcluir = MessageBox.Show($"Deseja realmente excluir {data.Rows[0][0]} alugado por {data.Rows[0][2]}?",
                "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

                aluguelDb.AbrirConexaoDb();
                if (resultadoExcluir == DialogResult.Yes) aluguelDb.DeletarAluguelCliente(data.Rows[0][2].ToString());
                aluguelDb.FechaConecxaoDb();
            }
        }
    }
}
