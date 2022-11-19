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
    /// Lógica interna para FornecedorFormWindow.xaml
    /// </summary>
    public partial class FornecedorFormWindow : Window
    {
        public FornecedorFormWindow()
        {
            InitializeComponent();
            Loaded += FornecedorFormWindow_Loaded;
        }

        private void FornecedorFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new FornecedorDAO();
                List<Fornecedor> listaFornecedor = dao.List();

                dataGridFornecedor.ItemsSource = listaFornecedor;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.Painel();
            form.Show();
            this.Close();
        }

        private void btCadastar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CadFornecedor();
            form.Show();
            this.Close();
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            var fornecedorSelected = dataGridFornecedor.SelectedItem as Fornecedor;

            var form = new CadFornecedor(fornecedorSelected);
            form.ShowDialog();
            this.Close();
        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            var fornecedorSelected = dataGridFornecedor.SelectedItem as Fornecedor;

            if (fornecedorSelected == null)
            {
                MessageBox.Show("Selecione o fornecedor que deseja excluir.");
            }
            else
            {
                var resultado = MessageBox.Show($"Tem certeza que deseja deletar o fornecedor {fornecedorSelected.NomeFantasia} ?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                try
                {
                    if (resultado == MessageBoxResult.Yes)
                    {
                        var dao = new FornecedorDAO();
                        dao.Delete(fornecedorSelected);

                        MessageBox.Show("Fornecedor removido com sucesso!");
                        var form = new FornecedorFormWindow();
                        form.Show();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        } //COMANDOS MENU
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
            
        }

        private void btCompra_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CompraFormWindow();
            form.Show();
            this.Close();
        }

        private void btEmitir_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

