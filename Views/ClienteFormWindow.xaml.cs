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
    public partial class ClienteFormWindow : Window
    {
        public ClienteFormWindow()
        {
            InitializeComponent();
            Loaded += ClienteFormWindow_Loaded;
        }

        private void ClienteFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }


        private void btCadastar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CadCliente();
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
                var dao = new ClienteDAO();
                List<Cliente> listaClientes = dao.List();

                dataGridCliente.ItemsSource = listaClientes;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Verifica o valor selecionado no Data Grid e aciona a tela de cadastro com as informações carregadas nos campos
        private void btEditar_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelected = dataGridCliente.SelectedItem as Cliente;

<<<<<<< Updated upstream
            if (clienteSelected == null)
            {
                MessageBox.Show("Selecione o cliente que deseja editar.");
            }
            else
            {

                var form = new CadCliente(clienteSelected);
                form.ShowDialog();
                this.Close();
            }
=======
            var form = new CadCliente(clienteSelected);
            form.ShowDialog();
>>>>>>> Stashed changes
        }

        //Verifica o valor selecionado no Data Grid e exclui os valores de acordo
        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {
            var clienteSelected = dataGridCliente.SelectedItem as Cliente;

            if (clienteSelected == null)
            {
                MessageBox.Show("Selecione o cliente que deseja excluir.");
            }
            else
            {
                var resultado = MessageBox.Show($"Tem certeza que deseja deletar o cliente {clienteSelected.Nome} ?", "Confirmação de Exclusão", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                try
                {
                    if (resultado == MessageBoxResult.Yes)
                    {
                        var dao = new ClienteDAO();
                        dao.Delete(clienteSelected);

                        MessageBox.Show("Cliente removido com sucesso!");
                        var form = new ClienteFormWindow();
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
            var form = new Views.FuncionarioFormWindow();
            form.Show();
            this.Close();
        }

        private void btCliente_Click(object sender, RoutedEventArgs e)
        {
            
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

        private void btCompra_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CompraFormWindow();
            form.Show();
            this.Close();
        }
    }
}
