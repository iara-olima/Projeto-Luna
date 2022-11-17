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
            _fun= funcionario;
        }
        private void CadFuncionario_Loaded(object sender, RoutedEventArgs e)
        {
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
           
            _fun.Nome = txtNome.Text;
            _fun.CPF = txtCpf.Text;
            _fun.Email = txtEmail.Text;
            _fun.Funcao = txtFuncao.Text;
            _fun.Sexo = cbSexo.Text;
            _fun.Telefone = txtTelefone.Text;
            // txtSalario.Text= _fun.Salario.ToString();
            if (double.TryParse(txtSalario.Text, out double Salario))
                _fun.Salario = Salario;
            
            
            if (dt_DataNasc.SelectedDate != null)
                _fun.DataNasc = dt_DataNasc.SelectedDate;
            MessageBox.Show("Funcionando!");

            try
            {
                var dao = new FuncionarioDAO();
                if (_fun.Id > 0)
                {
                    dao.Update(_fun);

                }
                else
                {
                    dao.Insert(_fun);
                }

               // MessageBox.Show("Registro do Funcionário " + _fun.Nome + " atualizado com sucesso!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
           
    
   

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FuncionarioFormWindow();
            form.Show();
            this.Close();
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.FuncionarioFormWindow();
            form.Show();
            this.Close();
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
