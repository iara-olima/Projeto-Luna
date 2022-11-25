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
using ProjetoLuna.DataBase;

namespace ProjetoLuna.Views
{
    public partial class Login : Window
    {
        private static Conexao _conn = new Conexao();
        public Login()
        {
            InitializeComponent();
            Loaded += Login_Loaded;
            _conn.Restart();
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            txtCPF.Focus();
        }

        private void btEntrar_Click(object sender, RoutedEventArgs e)
        {
            LogarConta();
        }

        private void BtCadastro_Click(object sender, RoutedEventArgs e)
        {
            AcoesClick("Cadastro".ToUpper());
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            AcoesClick("Cancelar".ToUpper());
        }


        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtCPF.Clear();
            txtSenha.Clear();
        }

        private void LogarConta ()
        {
            string cpf = txtCPF.Text;
            string senha = txtSenha.Password.ToString();
            if (Usuario.Login(cpf, senha))
            {
                var form = new Views.Painel();
                form.Show();
                this.Close();
            }
            else MessageBox.Show("A senha ou o CPF podem estar incorretos.");
        }

        private void AcoesClick(string acao)
        {
            var cadUser = new CadUser();
            var principalPage = new Principal();

            if (acao == "Logar".ToUpper())
            {
                cadUser.Show();
                this.Close();
            }
            if (acao == "Cancelar".ToUpper())
            {
                principalPage.Show();
                this.Close();
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && txtSenha.IsFocused)
            {
                LogarConta();
            }
        }
    }
}
