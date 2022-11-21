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
    /// Lógica interna para CompraFormWindow.xaml
    /// </summary>
    public partial class CompraFormWindow : Window
    {
        public CompraFormWindow()
        {
            InitializeComponent();
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.Painel();
            form.Show();
            this.Close();
        }

        private void btFuncionario_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FuncionarioFormWindow();
            form.Show();
            this.Close();
        }

        private void btCliente_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.ClienteFormWindow();
            form.Show();
            this.Close();
        }

        private void btVenda_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.VendaFormWindow();
            form.Show();
            this.Close();
        }

        private void btCompra_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btCaixa_Click(object sender, RoutedEventArgs e)
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

        private void Despesas_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.DespesaFormWindow();
            form.Show();
            this.Close();
        }

        private void btEstoque_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.EstoqueFormWindow();
            form.Show();
            this.Close();
        }

        private void btFornecedor_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FornecedorFormWindow();
            form.Show();
            this.Close();
        }

        private void btRegistrarComp_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.RegCompra();
            form.Show();
            this.Close();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btEmitir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
