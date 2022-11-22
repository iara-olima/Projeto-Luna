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
    /// Lógica interna para RegVenda.xaml
    /// </summary>
    public partial class RegVenda : Window
    {
        private Venda _venda = new Venda();

        private List<VendaItem> _vendaItensList = new List<VendaItem>();

        public RegVenda()
        {
            InitializeComponent();
            Loaded += RegVenda_Loaded;
        }

        private void RegVenda_Loaded(object sender, RoutedEventArgs e)
        {
            cbFuncionario.ItemsSource = new FuncionarioDAO().List();
            cbCliente.ItemsSource = new ClienteDAO().List();
            LoadData();
        }

        private void btRegistrar_Click(object sender, RoutedEventArgs e)
        {
           

            if (dtData.SelectedDate != null)
                _venda.Data = (DateTime)dtData.SelectedDate;


            if (cbFuncionario.SelectedItem != null)
                _venda.Funcionario = cbFuncionario.SelectedItem as Funcionario;

            if (cbCliente.SelectedItem != null)
                _venda.Cliente = cbCliente.SelectedItem as Cliente;

            _venda.Itens = _vendaItensList;

            SalvarVenda();
        }

        private void btProdVend_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProdutoVendaFormWindow();
            window.ShowDialog();

            var produtosSelecionadosList = window.ProdutosSelecionados;
            var count = 1;

            foreach (Produto produto in produtosSelecionadosList)
            {

                if (!_vendaItensList.Exists(item => item.Produto.Id == produto.Id))
                {
                    _vendaItensList.Add(new VendaItem()
                    {
                        Id = count,
                        Produto = produto,
                        Quantidade = 1,
                        Valor = produto.ValorVenda
                    });

                    count++;
                }
            }

            LoadDataGrid();
        }

        private void BtRemoverProduto_Click(object sender, RoutedEventArgs e)
        {
            var itemSelected = dataGridProdutosVendidos.SelectedItem as VendaItem;
            _vendaItensList.Remove(itemSelected);
            LoadDataGrid();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var item = e.Row.Item as VendaItem;

            var value = (e.EditingElement as TextBox).Text;
            _ = int.TryParse(value, out int quantidade);

            if (quantidade > 1)
            {
                item.Quantidade = quantidade;
                item.Valor = quantidade * item.Valor;
            }

            LoadDataGrid();
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.VendaFormWindow();
            form.Show();
            this.Close();
        }


        private void SalvarVenda()
        {
      

                var dao = new VendaDAO();
                dao.Insert(_venda);

                MessageBox.Show($"Venda realizada com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);
                cbFuncionario.SelectedIndex = -1;
                cbCliente.SelectedIndex = -1;
                txtValor.Clear();

           
        }

        private double UpdateValorTotal()
        {
            double valor = 0.0;

            _vendaItensList.ForEach(item => valor += item.Valor);

            txtValor.Text = valor.ToString("C");

            return valor;
        }

        private void LoadDataGrid()
        {
            _ = UpdateValorTotal();
            dataGridProdutosVendidos.ItemsSource = null;
            dataGridProdutosVendidos.ItemsSource = _vendaItensList;
        }

        private void LoadData()
        {
            dtData.SelectedDate = DateTime.Now;
            Thora.SelectedTime = DateTime.Now;

           
                cbFuncionario.ItemsSource = new FuncionarioDAO().List();
                cbCliente.ItemsSource = new ClienteDAO().List();

        
        }
    }
}
