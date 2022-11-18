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
    /// Lógica interna para CadFornecedor.xaml
    /// </summary>
    public partial class CadFornecedor : Window
    {
        public Fornecedor _forn = new Fornecedor();
        public CadFornecedor()
        {
            InitializeComponent();
            Loaded += CadFornecedor_Loaded;
        }
        public CadFornecedor(Fornecedor fornecedor)
        {
            InitializeComponent();
            Loaded += CadFornecedor_Loaded;
            _forn = fornecedor;
        }

        private void CadFornecedor_Loaded(object sender, RoutedEventArgs e)
        {
            if (_forn.Id > 0)
            {
                MessageBox.Show("Fornecedor: " + _forn.NomeFantasia);

                txtNomeFantasia.Text = _forn.NomeFantasia;
                txtCNPJ.Text = _forn.CNPJ;
                txtEmail.Text = _forn.Email;
                txtEndereco.Text = _forn.Endereco;
                txtRazaoSocial.Text = _forn.RazaoSocial;
                txtTelefone.Text = _forn.Telefone;

            }
            else
            {
                InitializeComponent();
                Loaded += CadFornecedor_Loaded;
            }
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtNomeFantasia.Clear();
            txtCNPJ.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtRazaoSocial.Clear();
            txtTelefone.Clear();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            _forn.NomeFantasia = txtNomeFantasia.Text;
            _forn.Email = txtEmail.Text;
            _forn.Telefone = txtTelefone.Text;
            _forn.CNPJ = txtCNPJ.Text;
            _forn.Endereco = txtEndereco.Text;
            _forn.RazaoSocial = txtRazaoSocial.Text;

            try
            {
                var dao = new FornecedorDAO();
                if (_forn.Id > 0)
                {
                    dao.Update(_forn);
                    MessageBox.Show("Registro do Fornecedor " + _forn.NomeFantasia + " atualizado com sucesso!");

                }
                else
                {
                    dao.Insert(_forn);
                    MessageBox.Show("Registro do Fornecedor " + _forn.NomeFantasia + " inseridos com sucesso!");
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btVoltar_click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FornecedorFormWindow();
            form.Show();
            this.Close();
        }
    }
}
