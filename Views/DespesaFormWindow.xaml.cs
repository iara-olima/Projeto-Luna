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
    /// Lógica interna para DespesaFormWindow.xaml
    /// </summary>
    public partial class DespesaFormWindow : Window
    {
        public DespesaFormWindow()
        {
            InitializeComponent();
            Loaded += DespesaFormWindow_Loaded;
        }

        private void DespesaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void btRegistrar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.RegDespesa();
            form.Show();
            this.Close();
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
                var dao = new DespesaDAO();
                List<Despesa> listaDespesa = dao.List();

                dataGridDespesa.ItemsSource = listaDespesa;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Verifica o valor selecionado no Data Grid e aciona a tela de cadastro com as informações carregadas nos campos
        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            var despesaSelected = dataGridDespesa.SelectedItem as Despesa;
            if (despesaSelected == null)
            {
                MessageBox.Show("Selecione a despesa que deseja editar.");
            }
            else
            {
                var form = new RegDespesa(despesaSelected);
                form.ShowDialog();
                this.Close();
            }
        }

        //Verifica o valor selecionado no Data Grid e exclui os valores de acordo
        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            var despesaSelected = dataGridDespesa.SelectedItem as Despesa;

            if (despesaSelected == null)
            {
                MessageBox.Show("Selecione a despesa que deseja excluir.");
            }
            else
            {
                var resultado = MessageBox.Show($"Tem certeza que deseja deletar a despesa {despesaSelected.Descricao} ?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                try
                {
                    if (resultado == MessageBoxResult.Yes)
                    {
                        var dao = new DespesaDAO();
                        dao.Delete(despesaSelected);

                        MessageBox.Show("Despesa removida com sucesso!");
                        var form = new DespesaFormWindow();
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

        private void Compra_Click(object sender, RoutedEventArgs e)
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
