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
    /// Lógica interna para FornecedorFormWindow.xaml
    /// </summary>
    public partial class FornecedorFormWindow : Window
    {
        public FornecedorFormWindow()
        {
            InitializeComponent();
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.Painel();
            form.Show();
            this.Close();
        }

        private void btCadastar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CadFuncionario();
            form.Show();
            this.Close();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CadFuncionario();
            form.Show();
            this.Close();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btListar_Ckick(object sender, RoutedEventArgs e)
        {

        }

        private void Acoes_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
