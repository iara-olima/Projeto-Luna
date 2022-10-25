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

namespace ProjetoLuna.Views
{
    /// <summary>
    /// Lógica interna para ClienteFormWindow.xaml
    /// </summary>
    /// 



    /*
     * - Deixar oculta algumas informaçoes
     * fazer botão voltar
     * colocar icones na parte superior e lado direito
     */
    public partial class ClienteFormWindow : Window
    {
        public ClienteFormWindow()
        {
            InitializeComponent();
            Loaded += ClienteFormWindow_Loaded;
        }

        private void ClienteFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CarregarListagem();
        }

        private void btCadastar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.CadCliente();
            form.Show();
            this.Close();
        }
        
        private void btVoltar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Views.Painel();
            form.Show();
            this.Close();
        }

        private void dataGridCliente_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CarregarListagem()
        {
            try
            {
                var dao = new ClienteDAO();
                List<Cliente> listaClientes = dao.List();

                dataGridCliente.ItemsSource = listaClientes;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btEditar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btExcluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btListar_Ckick(object sender, RoutedEventArgs e)
        {

        }

        private void Acoes_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
