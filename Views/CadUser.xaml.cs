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
using ProjetoLuna.Helpers;
using ProjetoLuna.Models;
using MySql.Data.MySqlClient;

namespace ProjetoLuna.Views
{
    public partial class CadUser : Window
    {
        private static Conexao _conn = new Conexao();
        public CadUser()
        {
            InitializeComponent();
        }
        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Principal();
            form.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var form = new Login();
            form.Show();
            this.Close();
        }
        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtSenha.Password.ToString() == txtSenhaConfirma.Password.ToString())
            {

            }
            else MessageBox.Show("Senhas Diferentes");

            _conn.Close();
        }
        private void funcionarioCB_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "select * from Funcionario;";
                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var funcionario = new Funcionario();
                    funcionario.Nome = reader.GetString("nome_fun");
                    funcionarioCB.Items.Add(funcionario.Nome);
                }
                _conn.Close();
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
