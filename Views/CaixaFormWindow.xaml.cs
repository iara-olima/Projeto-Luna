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
using ProjetoLuna.DataBase;
using ProjetoLuna.Helpers;
using ProjetoLuna.Models;
using ProjetoLuna.Properties;
using ProjetoLuna.Views;
using MySql.Data.MySqlClient;

namespace ProjetoLuna.Views
{
    /// <summary>
    /// Lógica interna para CaixaFormWindow.xaml
    /// </summary>
    public partial class CaixaFormWindow : Window
    {
        public Caixa _cai = new Caixa();

        public CaixaFormWindow()
        {
            InitializeComponent();
            Loaded += CaixaFormWindow_Loaded;
        }

        public CaixaFormWindow(Caixa caixa)
        {
            InitializeComponent();
            Loaded += CaixaFormWindow_Loaded;
            _cai = caixa;
        }

        private void CaixaFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }
        private void CarregarListagem()
        {
            try
            {
                var dao = new CaixaDAO();
                List<Caixa> listaCaixa = dao.List();

                dataGridDespesa.ItemsSource = listaCaixa;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btOK_Click(object sender, RoutedEventArgs e)
        {


            if (double.TryParse(txtPagamentos.Text, out double Pagamentos))
                _cai.Pagamentos = Pagamentos;


            if (double.TryParse(txtSaldoInicial.Text, out double SaldoInicial))
                _cai.SaldoInicial = SaldoInicial;

            if (double.TryParse(txtSaldoFinal.Text, out double SaldoFinal))
                _cai.SaldoFinal = SaldoFinal;

            if (double.TryParse(txtRecebimentos.Text, out double Recebimentos))
                _cai.Recebimentos = Recebimentos;


            if (dtData.SelectedDate != null)
                _cai.Data = dtData.SelectedDate;

            try
            {
                var dao = new CaixaDAO();
                if (_cai.Id > 0)
                {
                    dao.Insert(_cai);
                    MessageBox.Show("Registro de Caixa " + _cai.Id + " inserido com sucesso!");

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

    }
}
