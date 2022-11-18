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
    /// Lógica interna para CadFuncionario.xaml
    /// </summary>
    public partial class CadFuncionario : Window
    {
        private Funcionario _fun = new Funcionario();
        public CadFuncionario()
        {
            InitializeComponent();
            cbSexo.Items.Add("Feminino");
            cbSexo.Items.Add("Masculino");
            Loaded += CadFuncionario_Loaded;

        }

        public CadFuncionario(Funcionario funcionario)
        {
            InitializeComponent();
            Loaded += CadFuncionario_Loaded;
            _fun = funcionario;
        }

        //Verifica se a variavel _fun esta com valor maior que 0, se sim carrega as informações para editar um cadastro já salvo, senão realiza um novo cadastro
        private void CadFuncionario_Loaded(object sender, RoutedEventArgs e)
        {
            if (_fun.Id > 0)
            {
                MessageBox.Show("Funcionário: " + _fun.Nome);

                txtNome.Text = _fun.Nome;
                dtDataNasc.SelectedDate = _fun.DataNasc;
                txtSalario.Text = _fun.Salario.ToString();
                txtCpf.Text = _fun.CPF;
                txtEmail.Text = _fun.Email;
                txtTelefone.Text = _fun.Telefone;
                if (_fun.Sexo == "Masculino")
                {
                    cbSexo.SelectedItem = "Masculino";
                    cbSexo.Items.Add("Masculino");
                    cbSexo.Items.Add("Feminino");
                }
                else
                {
                    cbSexo.SelectedItem = "Feminino";
                    cbSexo.Items.Add("Masculino");
                    cbSexo.Items.Add("Feminino");
                }
                txtFuncao.Text = _fun.Funcao;
            }
            else
            {
                InitializeComponent();
                Loaded += CadFuncionario_Loaded;
            }
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
           
            _fun.Nome = txtNome.Text;
            _fun.CPF = txtCpf.Text;
            _fun.Email = txtEmail.Text;
            _fun.Funcao = txtFuncao.Text;
            _fun.Sexo = cbSexo.Text;
            _fun.Telefone = txtTelefone.Text;
            if (double.TryParse(txtSalario.Text, out double Salario))
                _fun.Salario = Salario;
            
            
            if (dtDataNasc.SelectedDate != null)
                _fun.DataNasc = dtDataNasc.SelectedDate;

            try
            {
                var dao = new FuncionarioDAO();
                if (_fun.Id > 0)
                {
                    dao.Update(_fun);
                    MessageBox.Show("Registro do Funcionário " + _fun.Nome + " atualizado com sucesso!");

                }
                else
                {
                    dao.Insert(_fun);
                    MessageBox.Show("Registro do Funcionário " + _fun.Nome + " inseridos com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
           
        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FuncionarioFormWindow();
            form.Show();
            this.Close();
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtEmail.Clear();
            txtFuncao.Clear();
            cbSexo.Items.Clear();
            txtTelefone.Clear();
            txtSalario.Clear();
        }
    }
}
