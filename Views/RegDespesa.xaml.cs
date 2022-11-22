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
    /// Lógica interna para RegDespesa.xaml
    /// </summary>
    public partial class RegDespesa : Window
    {
        private Despesa _desp = new Despesa();
        public RegDespesa()
        {
            InitializeComponent();

            Loaded += RegDespesa_Loaded;

        }

        public RegDespesa(Despesa despesa)
        {
            InitializeComponent();
            Loaded += RegDespesa_Loaded;
            _desp = despesa;
            dtData.SelectedDate = DateTime.Now;
            Thora.SelectedTime = DateTime.Now;
        }

        //Verifica se a variavel _desp esta com valor maior que 0, se sim carrega as informações para editar um cadastro já salvo, senão realiza um novo cadastro
        private void RegDespesa_Loaded(object sender, RoutedEventArgs e)
        {
            if (_desp.Id > 0)
            {
                MessageBox.Show("Despesa: " + _desp.Descricao);

                txtDescricao.Text = _desp.Descricao;
                dtData.SelectedDate = _desp.Data;
                Thora.SelectedTime = _desp.Hora;
                if (int.TryParse(txtQtdParc.Text, out int qtdParc))
                    _desp.Parcelas = qtdParc;

                if (double.TryParse(txtValorParc.Text, out double valorParc))
                    _desp.ValorParc = valorParc;

  
            }
            else
            {
                InitializeComponent();
                Loaded += RegDespesa_Loaded;
            }
        }
        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {

            _desp.Descricao = txtDescricao.Text;
            if (dtData.SelectedDate != null)
                _desp.Data = dtData.SelectedDate;
            if (Thora.SelectedTime != null)
                _desp.Hora = Thora.SelectedTime;
            if (int.TryParse(txtQtdParc.Text, out int QtdParc))
                _desp.Parcelas = QtdParc;
            if (double.TryParse(txtValorParc.Text, out double ValorParc))
                _desp.ValorParc = ValorParc;

            try
            {
                var dao = new DespesaDAO();
                if (_desp.Id > 0)
                {
                    dao.Update(_desp);
                    MessageBox.Show("Registro da Despesa " + _desp.Descricao + " atualizado com sucesso!");

                }
                else
                {
                    dao.Insert(_desp);
                    MessageBox.Show("Registro da Despesa " + _desp.Descricao + " inseridos com sucesso!");
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
            txtDescricao.Clear();
            txtQtdParc.Clear();
            txtValorParc.Clear();
        }
    }
}
