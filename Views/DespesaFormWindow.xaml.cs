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
    /// Lógica interna para DespesaFormWindow.xaml
    /// </summary>
    public partial class DespesaFormWindow : Window
    {
        public DespesaFormWindow()
        {
            InitializeComponent();
        }

        private void btRegistrar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.RegDespesa();
            form.Show();
            this.Close();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {

        }

        //COMANDOS MENU
        private void Funcionario_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FuncionarioFormWindow();
            form.Show();
            this.Close();
        }

        private void Cliente_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.ClienteFormWindow();
            form.Show();
            this.Close();
        }

        private void Venda_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.VendaFormWindow();
            form.Show();
            this.Close();
        }

        private void btCompra_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CompraFormWindow();
            form.Show();
            this.Close();
        }

        private void Caixa_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CaixaFormWindow();
            form.Show();
            this.Close();
        }

        private void Pagamentos_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.PagamentoFormWindow();
            form.Show();
            this.Close();
        }

        private void Recebimentos_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.RecebimentoFormWindow();
            form.Show();
            this.Close();
        }

        private void Estoque_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.EstoqueFormWindow();
            form.Show();
            this.Close();
        }
        private void Fornecedor_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FornecedorFormWindow();
            form.Show();
            this.Close();
        }

    }
}
