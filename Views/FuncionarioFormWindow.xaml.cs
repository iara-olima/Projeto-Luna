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
    /// Lógica interna para FuncionarioFormWindow.xaml
    /// </summary>
    public partial class FuncionarioFormWindow : Window
    {
        public FuncionarioFormWindow()
        {
            InitializeComponent();
            Loaded += FuncionarioFormWindow_Loaded;
        }

        private void FuncionarioFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void btCadastar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CadFuncionario();
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
                var dao = new FuncionarioDAO();
                List<Funcionario> listaFuncionarios = dao.List();

                dataGridFunc.ItemsSource = listaFuncionarios;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Verifica o valor selecionado no Data Grid e aciona a tela de cadastro com as informações carregadas nos campos
        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            var funcionarioSelected = dataGridFunc.SelectedItem as Funcionario;
            if (funcionarioSelected == null)
            {
                MessageBox.Show("Selecione o funcionário que deseja editar.");
            }
            else
            {
                var form = new CadFuncionario(funcionarioSelected);
                form.ShowDialog();
                this.Close();
            }
        }

        //Verifica o valor selecionado no Data Grid e exclui os valores de acordo
        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            var funcionarioSelected = dataGridFunc.SelectedItem as Funcionario;

            if (funcionarioSelected == null)
            {
                MessageBox.Show("Selecione o funcionário que deseja excluir.");
            }
            else
            {
                var resultado = MessageBox.Show($"Tem certeza que deseja deletar o funcionário {funcionarioSelected.Nome} ?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                try
                {
                    if (resultado == MessageBoxResult.Yes)
                    {
                        var dao = new FuncionarioDAO();
                        dao.Delete(funcionarioSelected);

                        MessageBox.Show("Funcionário removido com sucesso!");
                        var form = new FuncionarioFormWindow();
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

        //COMANDOS MENU
        private void btFuncionario_Click(object sender, RoutedEventArgs e)
        {
           
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
            var form = new Views.FornecedorFormWindow();
            form.Show();
            this.Close();
        }

        private void dataGridFunc_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
