using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ProjetoLuna.DataBase;
using ProjetoLuna.Views;
using ProjetoLuna.Helpers;
using ProjetoLuna.Models;
using MySql.Data.MySqlClient;

namespace ProjetoLuna.Views
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private static Conexao _conn = new Conexao();

        public Login()
        {
            InitializeComponent();
        }

        private void btEntrar_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    MySqlConnection conexao = new MySqlConnection();
            //    conexao.ConnectionString = ContentStringFormat;
            //    conexao.Open();

            //    var verificacao = _conn.Query();

            //    verificacao.CommandText = "SELECT * FROM Usuario WHERE Usuario=@CPF and Senha=@Senha";

            //    verificacao.Parameters.Add("@CPF", MySqlDbType.VarChar).Value = txtCPF.Text;
            //    verificacao.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = txtCPF.Text;

            //    verificacao.CommandType = System.Data.CommandType.Text;
            //    verificacao.Connection = conexao;

            //    MySqlDataReader reader = verificacao.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        var form = new Painel();
            //        form.Show();
            //        this.Close();
            //    }
            //    else
            //    {
            //        MessageBox.Show("CPF não encontrado!");
            //    }
            //    conexao.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //=============================

            string cpf = txtCPF.Text;
            string senha = txtSenha.Text;
            if ((cpf == "") && (senha == ""))
            {
                var form = new Views.Painel();
                form.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("A senha ou o CPF podem estar incorretos.");
            }

        }

        private void BtCadastro_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CadUser();
            form.Show();
            this.Close();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Principal();
            form.Show();
            this.Close();
        }

        private void txtCPF_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtCPF.SelectAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
