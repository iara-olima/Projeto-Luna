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
    /// Lógica interna para CadCliente.xaml
    /// </summary>
    public partial class CadCliente : Window
    {
        public Cliente cliente = new Cliente();

        public CadCliente()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            cliente.Nome = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.CPF = txtCpf.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Sexo = cbSexo.Text;

            if (dtNasc.SelectedDate != null)
                cliente.DataNasc = dtNasc.SelectedDate;
            ShowMenssage();

            try
            {
                var dao = new ClienteDAO();
                if (cliente.Id > 0)
                {
                    dao.Update(cliente);
                    MessageBox.Show("Dados do Cliente atualizados com sucesso!");

                }
                else
                {
                    dao.Insert(cliente);
                    MessageBox.Show("Cliente cadastrado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ShowMenssage()
        {

            MessageBox.Show("Nome: " + cliente.Nome + Environment.NewLine +
                 "razão social= " + _escola.RazaoSocial + Environment.NewLine + "cnpj= " +
                             _escola.CNPJ + Environment.NewLine + "inscrição estadual= " + _escola.Inscricao + Environment.NewLine + "responsavel= " + _escola.Responsavel +
                             Environment.NewLine + "tipo= " + tipo + Environment.NewLine + Environment.NewLine + "data criação= " + _escola.DataCriacao +
                             Environment.NewLine + "responsavel= " + _escola.Responsavel + Environment.NewLine + "telefone resp= " + _escola.TelefoneResp + Environment.NewLine +
                             "e-mail= " + _escola.Email + Environment.NewLine + "telefone esc= " + _escola.TelefoneEsc + Environment.NewLine + " rua= " + _escola.Rua + Environment.NewLine +
                           "numero= " + _escola.Numero + Environment.NewLine + "bairro= " + _escola.Bairro + Environment.NewLine + "complemento= " + _escola.Complemento + Environment.NewLine +
                          "cep= " + _escola.CEP + Environment.NewLine + "cidade= " + _escola.Cidade + Environment.NewLine + "estado= " + _escola.Estado + Environment.NewLine
                             );


        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.ClienteFormWindow();
            form.Show();
            this.Close();
        }

        private void txtFuncao_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
