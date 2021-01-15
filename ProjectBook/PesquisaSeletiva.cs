﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProjectBook.DB.SqlServerExpress;

namespace ProjectBook
{
    public partial class PesquisaSeletiva : Form
    {
        LivrosDb livrosDb = new LivrosDb();
        public PesquisaSeletiva()
        {
            InitializeComponent();
        }

        private void btnPesquisarSeletiva_Click(object sender, EventArgs e)
        {
            string termoPesquisa = txtTermoPesquisa.Text;
            DataTable resultadoPesquisa;

            livrosDb.AbrirConexaoDb();
            if (rabPesquisarId.Checked == true) resultadoPesquisa = livrosDb.BuscarLivrosId(termoPesquisa);
            else if (rabPesquisarTitulo.Checked == true) resultadoPesquisa = livrosDb.BuscarLivrosTitulo(termoPesquisa);
            else if (rabPesquisarAutor.Checked == true) resultadoPesquisa = livrosDb.BuscarLivrosAutor(termoPesquisa);
            else return;
            livrosDb.FechaConecxaoDb();

            ListaLivros listaLivros = new ListaLivros(resultadoPesquisa);
            listaLivros.Show();
        }
    }
}
