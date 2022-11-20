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
using ProjetoLuna.Models;

namespace ProjetoLuna.Views
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btEntrar_Click(object sender, RoutedEventArgs e)
        {
            string cpf = txtCPF.Text;
            string senha = txtSenha.Password.ToString();
            if (Usuario.Login(cpf, senha)) {
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


        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtCPF.Clear();
            txtSenha.Clear();
        }
    }
}
