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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SistemaMarques
{
    public partial class Galeria : Form
    {
        private int Id;
        public Galeria()
        {
            InitializeComponent();
            lvtabela.View = View.Details;
            lvtabela.Columns.Add("id", 200);
            lvtabela.Columns.Add("nome_album", 200);
            lvtabela.Columns.Add("nome_cli", 200);
            lvtabela.Columns.Add("email_cli", 200);
            StartPosition = FormStartPosition.Manual;
            this.Left = 0;

        }

        private void Galeria_Load(object sender, EventArgs e)
        {
            lvtabela.Items.Clear();

            Connection conn = new Connection();
            SqlCommand sqlCom = new SqlCommand();

            sqlCom.Connection = conn.ReturnConnection();
            sqlCom.CommandText = "SELECT * FROM Imagens";

            try
            {
                SqlDataReader dr = sqlCom.ExecuteReader();

                //Enquanto for possível continuar a leitura das linhas que foram retornadas na consulta, execute.
                while (dr.Read())
                {
                    ListViewItem lv = new ListViewItem(dr["id"].ToString());
                    //lv.SubItems.Add(dr["imagens_binar"].ToString());
                    lv.SubItems.Add(dr["nome_album"].ToString());
                    lv.SubItems.Add(dr["nome_cli"].ToString());
                    lv.SubItems.Add(dr["email_cli"].ToString());


                    lvtabela.Items.Add(lv);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void pixelPOSDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
