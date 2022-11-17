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
using MySql.Data.MySqlClient;

namespace ProjetoLuna.Views
{
    /// <summary>
    /// Lógica interna para CadProduto.xaml
    /// </summary>
    public partial class CadProduto : Window
    { 
        private Produto _prod = new Produto();
    
        public CadProduto()
        {
            InitializeComponent();
            Loaded += CadProduto_Loaded;
        }

        public CadProduto(Produto produto)
        {
            InitializeComponent();
            Loaded += CadProduto_Loaded;
            _prod = produto;
        }

        private void CadProduto_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _prod.Nome = txtNome.Text;
            _prod.Marca = txtMarca.Text;
            _prod.Quantidade = txtQuantidade.Text;
            _prod.Descricao = txtDescricao.Text;
            //txtValorVenda.Text = _prod.ValorVenda.ToString();//
            //txtValorCompra.Text = _prod.ValorCompra.ToString();//

            if (double.TryParse(txtValorVenda.Text, out double ValorVenda))
                _prod.ValorVenda = ValorVenda;

            if (double.TryParse(txtValorCompra.Text, out double ValorCompra))
                _prod.ValorCompra = ValorCompra;


            MessageBox.Show("Funcionando!");

            try
            {
                var dao = new ProdutoDAO();
                if (_prod.Id > 0)
                {
                    dao.Update(_prod);

                }
                else
                {
                    dao.Insert(_prod);
                }

                MessageBox.Show("Registro de Produto " + _prod.Nome + " atualizado com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtDescricao.Clear();
            txtMarca.Clear();
            txtNome.Clear();
            txtQuantidade.Clear();
            txtValorCompra.Clear();
            txtValorVenda.Clear();


        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.EstoqueFormWindow();
            form.Show();
            this.Close();
        }
    }
}
