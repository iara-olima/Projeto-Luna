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

        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
