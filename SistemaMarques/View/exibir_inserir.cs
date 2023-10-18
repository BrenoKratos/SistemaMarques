﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace SistemaMarques
{
    public partial class exibir_inserir : Form
    {
        public exibir_inserir()
        {
            InitializeComponent();
        }

        public void exibir_inserir_Load(object sender, EventArgs e)
        {
            //int larguraDesejada = 1200; // Substitua pelo valor desejado
            //int alturaDesejada = 800;  // Substitua pelo valor desejado

            // Modifique o tamanho do formulário
            //this.Size = new System.Drawing.Size(larguraDesejada, alturaDesejada);
        }

        private void pnupload_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnupload_Paint(object sender, DragEventArgs e)
        {
          
        }

        private void btnvermn_Click(object sender, EventArgs e)
        {

        }


        private byte[] armazenarimg;

        private void btnupload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Arquivos de imagem|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os arquivos|*.*";
            openFileDialog.Multiselect = true;
            openFileDialog.Title = "Selecione uma imagem";

            if (openFileDialog.ShowDialog() == DialogResult.OK && openFileDialog.FileNames.Length > 0)
            {
                byte[] imagemfile = File.ReadAllBytes(openFileDialog.FileName);
                armazenarimg = imagemfile;
            }
            else
            {
                return;
            }
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnenviar_Click(object sender, EventArgs e)
        { 
            Connection connection = new Connection();
            SqlCommand sqlCommand = new SqlCommand();


                
            sqlCommand.Connection = connection.ReturnConnection();
            sqlCommand.CommandText = "INSERT INTO Imagens Values(@imagens_binar,@nome_album,@nome_cli,@email_cli)";
            sqlCommand.Parameters.AddWithValue("@nome_album", txbnomealbum.Text);
            sqlCommand.Parameters.AddWithValue("@nome_cli", txbnomecli.Text);
            sqlCommand.Parameters.AddWithValue("@email_cli", txbemailcli.Text);
            sqlCommand.Parameters.AddWithValue("@imagens_binar", armazenarimg);
            try
            {
                //Insere o cliente
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                throw new Exception("Erro: Problemas ao inserir colaborador no banco.\n"
                    + err.Message);
            }
            finally
            {
                connection.CloseConnection();
            }
            MessageBox.Show(
                "Cadastrado com Sucesso",
                "CADASTRO",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
                );
        }
    }
}
