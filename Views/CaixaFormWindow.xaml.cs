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
            
        }

        private void btRelatorio_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btEntrada_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btSaida_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
