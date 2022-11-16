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
        public Produto _prod = new Produto();
    
        public CadProduto()
        {
            InitializeComponent();
            Loaded += CadProduto_Loaded;
        }

        private void CadCliente(Produto produto)
        {
            InitializeComponent();
            Loaded += CadProduto_Loaded;
            _prod = produto;
        }

        private void CadProduto_Loaded(object sender, RoutedEventArgs e)
        {
            if (_prod.Id > 0)
            {
                MessageBox.Show("Produto: " + _prod.Nome);

                txtNome.Text = _prod.Nome;
                txtMarca.Text = _prod.Marca;
                txtQuantidade.Text = _prod.Quantidade;
                txtDescricao.Text = _prod.Descricao;
                txtValorVenda.Text = _prod.ValorVenda.ToString();
                txtValorCompra.Text = _prod.ValorCompra.ToString();
            }
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _prod.Nome = txtNome.Text;
            _prod.Marca = txtMarca.Text;
            _prod.Quantidade = txtQuantidade.Text;
            _prod.Descricao = txtDescricao.Text;
            txtValorVenda.Text = _prod.ValorVenda.ToString();
            txtValorCompra.Text = _prod.ValorCompra.ToString();


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

        //Informa os registros de cada atributo antes de realizar um novo cadastro ou uma atualização
        private void ShowMenssage()
        {

            MessageBox.Show("Nome: " + _prod.Nome + Environment.NewLine +
                 "Marca: " + _prod.Marca + Environment.NewLine + "Valor Venda: " +
                             _prod.ValorVenda + Environment.NewLine + "Valor Compra: " + _prod.ValorCompra + Environment.NewLine + "Quantidade: " + _prod.Quantidade +
                             Environment.NewLine + "Descrição: " + _prod.Descricao);
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
