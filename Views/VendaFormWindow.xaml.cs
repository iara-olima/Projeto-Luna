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
    /// Lógica interna para VendaFormWindow.xaml
    /// </summary>
    public partial class VendaFormWindow : Window
    {
        public VendaFormWindow()
        {
            InitializeComponent();
            Loaded += VendaFormWindow_Loaded;
        }
        private void VendaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.Painel();
            form.Show();
            this.Close();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new VendaDAO();
                List<Venda> listaVenda = dao.List();

                dataGrid.ItemsSource = listaVenda;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        }

        private void btCompra_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CompraFormWindow();
            form.Show();
            this.Close();
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

        private void btRegistrarVend_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.RegVenda();
            form.Show();
            this.Close();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            var vendaSelected = dataGrid.SelectedItem as Venda;
            if (vendaSelected == null)
            {
                MessageBox.Show("Selecione a venda que deseja editar.");
            }
            else
            {
                var form = new RegVenda(vendaSelected);
                form.ShowDialog();
                this.Close();
            }
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            var vendaSelected = dataGrid.SelectedItem as Venda;

            if (vendaSelected == null)
            {
                MessageBox.Show("Selecione a venda que deseja excluir.");
            }
            else
            {
                var resultado = MessageBox.Show($"Tem certeza que deseja deletar a venda {vendaSelected.Id} ?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                try
                {
                    if (resultado == MessageBoxResult.Yes)
                    {
                        var dao = new VendaDAO();
                        dao.Delete(vendaSelected);

                        MessageBox.Show("Venda removida com sucesso!");
                        var form = new VendaFormWindow();
                        form.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btEmitir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
