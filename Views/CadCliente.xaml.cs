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
        public Cliente _cli = new Cliente();

        public CadCliente()
        {
            InitializeComponent();
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Masculino");
            Loaded += CadCliente_Loaded;

        }

        public CadCliente(Cliente cliente)
        {
            InitializeComponent();
            Loaded += CadCliente_Loaded;
            _cli = cliente;
        }

        private void CadCliente_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            _cli.Nome = txtNome.Text;
            _cli.Email = txtEmail.Text;
            _cli.Telefone = txtTelefone.Text;
            _cli.CPF = txtCpf.Text;
            _cli.Endereco = txtEndereco.Text;
            _cli.Sexo = cbSexo.Text;

            if (dtNasc.SelectedDate != null)
                _cli.DataNasc = dtNasc.SelectedDate;
            ShowMenssage();

            try
            {
                var dao = new ClienteDAO();
                if (_cli.Id > 0)
                {
                    dao.Update(_cli);
                    MessageBox.Show("Dados do Cliente atualizados com sucesso!");

                }
                else
                {
                    dao.Insert(_cli);
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

            MessageBox.Show("Nome: " + _cli.Nome + Environment.NewLine +
                 "Email: " + _cli.Email + Environment.NewLine + "Telefone: " +
                             _cli.Telefone + Environment.NewLine + "CPF: " + _cli.CPF + Environment.NewLine + "Endereço: " + _cli.Endereco +
                             Environment.NewLine + "Sexo: " + _cli.Sexo + Environment.NewLine + "Data Nascimento: " + _cli.DataNasc
                             );
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.ClienteFormWindow();
            form.Show();
            this.Close();
        }

    }
}
