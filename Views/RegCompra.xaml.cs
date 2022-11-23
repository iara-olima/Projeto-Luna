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
    /// Lógica interna para RegCompra.xaml
    /// </summary>
    public partial class RegCompra : Window
    {
        private Compra _compra = new Compra();

        private List<CompraItem> _compraItensList = new List<CompraItem>();

        public RegCompra()
        {
            InitializeComponent();
            cbFormaPag.Items.Add("Cartão");
            cbFormaPag.Items.Add("Dinheiro");
            cbFormaPag.Items.Add("Cheque");
            cbFormaPag.Items.Add("Outro");
            Loaded += RegCompra_Loaded;
        }

        private void RegCompra_Loaded(object sender, RoutedEventArgs e)
        {
            cbFuncionario.ItemsSource = new FuncionarioDAO().List();
            cbFornecedor.ItemsSource = new FornecedorDAO().List();
            LoadData();
        }

        private void btRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (dtData.SelectedDate != null)
                _compra.Data = (DateTime)dtData.SelectedDate;

            if (cbFuncionario.SelectedItem != null)
                _compra.Funcionario = cbFuncionario.SelectedItem as Funcionario;

            if (int.TryParse(txtQtdParc.Text, out int qtdParc))
                _compra.Parcela = qtdParc;

            if (double.TryParse(txtValorParc.Text, out double valorParc))
                _compra.ValorParc = valorParc;

            if (cbFornecedor.SelectedItem != null)
                _compra.Fornecedor = cbFornecedor.SelectedItem as Fornecedor;

            _compra.FormaPagamento = cbFormaPag.Text;
            _compra.Valor = UpdateValorTotal();
            _compra.Itens = _compraItensList;

            SalvarCompra();
        }

        private void btProdComp_Click(object sender, RoutedEventArgs e)
        {
            var window = new ProdutoCompraFormWindow();
            window.ShowDialog();

            var produtosSelecionadosList = window.ProdutosSelecionados;
            var count = 1;

            foreach (Produto produto in produtosSelecionadosList)
            {

                if (!_compraItensList.Exists(item => item.Produto.Id == produto.Id))
                {
                    _compraItensList.Add(new CompraItem()
                    {
                        Id = count,
                        Produto = produto,
                        Quantidade = 1,
                        Valor = produto.ValorCompra,
                        ValorTotal = produto.ValorCompra
                    });

                    count++;
                }
            }

            LoadDataGrid();
        }

        private void BtRemoverProduto_Click(object sender, RoutedEventArgs e)
        {
            var itemSelected = dataGridProdutos.SelectedItem as CompraItem;
            _compraItensList.Remove(itemSelected);
            LoadDataGrid();
        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var item = e.Row.Item as CompraItem;

            var value = (e.EditingElement as TextBox).Text;
            _ = int.TryParse(value, out int quantidade);

            if (quantidade > 1)
            {
                item.Quantidade = quantidade;
                item.ValorTotal = quantidade * item.Valor;
            }

            LoadDataGrid();
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CompraFormWindow();
            form.Show();
            this.Close();
        }


        private void SalvarCompra()
        {
            try
            {

                var dao = new CompraDAO();
                dao.Insert(_compra);

                MessageBox.Show($"Compra realizada com sucesso!", "Sucesso", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double UpdateValorTotal()
        {
            double valor = 0.0;

            _compraItensList.ForEach(item => valor += item.ValorTotal);

            txtValorTotal.Text = valor.ToString("C");

            return valor;
        }

        private void LoadDataGrid()
        {
            _ = UpdateValorTotal();
            dataGridProdutos.ItemsSource = null;
            dataGridProdutos.ItemsSource = _compraItensList;
        }

        private void LoadData()
        {
            dtData.SelectedDate = DateTime.Now;

            try
            {
                cbFuncionario.ItemsSource = new FuncionarioDAO().List();
                cbFornecedor.ItemsSource = new FornecedorDAO().List();

                //  cbFuncionario.SelectedValue = Usuario.GetFuncionarioId();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
