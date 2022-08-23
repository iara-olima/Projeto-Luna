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
            string senha = "1";
            string cpfN = "1";
            //fazer função desmascarar CPF (sem máscara: cpfN);

            if ((cpfN == "1") && (senha == "1"))
            {
                var form = new Views.Painel();
                form.Show();
                this.Close();
            }
            if ((cpfN != "1") || (senha != "1"))
            {
                MessageBox.Show("A senha ou o CPF podem estar incorretos.");
            }
            
        }
    }
}
