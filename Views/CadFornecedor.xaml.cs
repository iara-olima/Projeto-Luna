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
    /// Lógica interna para CadFornecedor.xaml
    /// </summary>
    public partial class CadFornecedor : Window
    {
        public CadFornecedor()
        {
            InitializeComponent();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FornecedorFormWindow();
            form.Show();
            this.Close();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FornecedorFormWindow();
            form.Show();
            this.Close();
        }

        private void btVoltar_click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FornecedorFormWindow();
            form.Show();
            this.Close();
        }
    }
}
