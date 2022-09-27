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
    /// Lógica interna para CadUser.xaml
    /// </summary>
    public partial class CadUser : Window
    {
        public CadUser()
        {
            InitializeComponent();
        }

        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtCadastro_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.Login();
            form.Show();
            this.Close();
        }
    }
}
