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
    /// Lógica interna para RegRecebimento.xaml
    /// </summary>
    public partial class RegRecebimento : Window
    {
        private Recebimento _rec = new Recebimento();
        public RegRecebimento()
        {
            InitializeComponent();
            cbFormaPag.Items.Add("Cartão");
            cbFormaPag.Items.Add("Dinheiro");
            cbFormaPag.Items.Add("Cheque");
            cbFormaPag.Items.Add("Outro");

            Loaded += RegRecebimento_Loaded;

        }

        public RegRecebimento(Recebimento recebimento)
        {
            InitializeComponent();
            Loaded += RegRecebimento_Loaded;
            _rec = recebimento;
            dtData.SelectedDate = DateTime.Now;
            Thora.SelectedTime = DateTime.Now;
        }

        //Verifica se a variavel _desp esta com valor maior que 0, se sim carrega as informações para editar um cadastro já salvo, senão realiza um novo cadastro
        private void RegRecebimento_Loaded(object sender, RoutedEventArgs e)
        {
            if (_rec.Id > 0)
            {
                MessageBox.Show("Recebimento: " + _rec.Id);

                dtData.SelectedDate = _rec.Data;
                Thora.SelectedTime = _rec.Hora;
                dtVenc.SelectedDate = _rec.Vencimento;
                if (double.TryParse(txtValor.Text, out double Valor))
                    _rec.Valor = Valor;
                if (double.TryParse(txtValorParc.Text, out double ValorParc))
                    _rec.ValorParcela = ValorParc;
                if (int.TryParse(txtQtdParc.Text, out int QtdParc))
                    _rec.Parcela = QtdParc;
                cbFormaPag.SelectedItem = _rec.Forma;
                cbCaixa.ItemsSource = new CaixaDAO().List();
                cbVenda.ItemsSource = new VendaDAO().List();
             
            }
            else
            {
                InitializeComponent();
                Loaded += RegRecebimento_Loaded;
            }
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            if (dtData.SelectedDate != null)
                _rec.Data = dtData.SelectedDate;
            if (Thora.SelectedTime != null)
                _rec.Hora = Thora.SelectedTime;
            if (double.TryParse(txtValor.Text, out double Valor))
                _rec.Valor = Valor;
            if (double.TryParse(txtValorParc.Text, out double ValorParc))
                _rec.ValorParcela = ValorParc;
            if (int.TryParse(txtQtdParc.Text, out int QtdParc))
                _rec.Parcela = QtdParc;
            if (dtVenc.SelectedDate != null)
                _rec.Vencimento = dtVenc.SelectedDate;
            _rec.Forma = cbFormaPag.Text;
            _rec.Caixa = cbCaixa.SelectedItem as Caixa;
            _rec.Venda = cbVenda.SelectedItem as Venda;

            try
            {
                var dao = new RecebimentoDAO();
                if (_rec.Id > 0)
                {
                    dao.Update(_rec);
                    MessageBox.Show("Registro do recebimento atualizado com sucesso!");

                }
                else
                {
                    dao.Insert(_rec);
                    MessageBox.Show("Registro do recebimento inserido com sucesso!");
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
            txtValor.Clear();
            txtValorParc.Clear();
            txtQtdParc.Clear();
            cbCaixa.SelectedIndex = -1;
            cbVenda.SelectedIndex = -1;
            cbFormaPag.SelectedIndex = -1;
        }
    }
}

