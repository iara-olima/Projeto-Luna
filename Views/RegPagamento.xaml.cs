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
    /// Lógica interna para RegPagamento.xaml
    /// </summary>
    public partial class RegPagamento : Window
    {
        private Pagamento _pag = new Pagamento();
        public RegPagamento()
        {
            InitializeComponent();
            cbFormaPag.Items.Add("Cartão");
            cbFormaPag.Items.Add("Dinheiro");
            cbFormaPag.Items.Add("Cheque");
            cbFormaPag.Items.Add("Outro");
            dtData.SelectedDate = DateTime.Now;
            Thora.SelectedTime = DateTime.Now;
            Loaded += RegPagamento_Loaded;

        }

        public RegPagamento(Pagamento pagamento)
        {
            InitializeComponent();
            Loaded += RegPagamento_Loaded;
            _pag = pagamento;
         
        }

        //Verifica se a variavel _desp esta com valor maior que 0, se sim carrega as informações para editar um cadastro já salvo, senão realiza um novo cadastro
        private void RegPagamento_Loaded(object sender, RoutedEventArgs e)
        {
            dtData.SelectedDate = DateTime.Now;
            Thora.SelectedTime = DateTime.Now;
            cbCaixa.ItemsSource = new CaixaDAO().List();
            cbDespesa.ItemsSource = new DespesaDAO().List();
            if (_pag.Id > 0)
            {
                MessageBox.Show("Pagamento: " + _pag.Id);

                dtData.SelectedDate = _pag.Data;
                Thora.SelectedTime = _pag.Hora;
                if (double.TryParse(txtValor.Text, out double Valor))
                    _pag.Valor = Valor;
                dtVenc.SelectedDate = _pag.Vencimento;
                cbCaixa.ItemsSource = new CaixaDAO().List();
                cbDespesa.ItemsSource = new DespesaDAO().List();
                cbFormaPag.SelectedItem = _pag.FormaPag;
            }
            else
            {
                InitializeComponent();
                Loaded += RegPagamento_Loaded;
            }
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            if (dtData.SelectedDate != null)
                _pag.Data = dtData.SelectedDate;
            if (Thora.SelectedTime != null)
                _pag.Hora = Thora.SelectedTime;
            if (double.TryParse(txtValor.Text, out double Valor))
                _pag.Valor = Valor;
            if (dtVenc.SelectedDate != null)
                _pag.Vencimento = dtVenc.SelectedDate;
            _pag.Caixa = cbCaixa.SelectedItem as Caixa;
            _pag.Despesa = cbDespesa.SelectedItem as Despesa;
            _pag.FormaPag = cbFormaPag.Text;

            try
            {
                var dao = new PagamentoDAO();
                if (_pag.Id > 0)
                {
                    dao.Update(_pag);
                    MessageBox.Show("Registro do pagamento atualizado com sucesso!");

                }
                else
                {
                    dao.Insert(_pag);
                    MessageBox.Show("Registro do pagamento inserido com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.PagamentoFormWindow();
            form.Show();
            this.Close();
        }

        private void btLimpar_Click(object sender, RoutedEventArgs e)
        {
            txtValor.Clear();
            cbCaixa.SelectedIndex = -1;
            cbDespesa.SelectedIndex = -1;
            cbFormaPag.SelectedIndex = -1;
        }
    }
}
