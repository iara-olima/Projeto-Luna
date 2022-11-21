﻿using System;
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
    /// Lógica interna para ProdutoCompraFormWindow.xaml
    /// </summary>
    public partial class ProdutoCompraFormWindow : Window
    {
        private List<Produto> _produtosList = new List<Produto>();

        public List<Produto> ProdutosSelecionados { get; private set; } = new List<Produto>();

        public ProdutoCompraFormWindow()
        {
            InitializeComponent();
            Loaded += ProdutoCompraFormWindow_Loaded;
        }

        private void ProdutoCompraFormWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
        }

        private void btPesquisar_Click(object sender, RoutedEventArgs e)
        {
            var text = txtPesquisa.Text;

            var filteredList = _produtosList.Where(i => i.Nome.ToLower().Contains(text));
            dataGridProduto.ItemsSource = filteredList;
        }

        private void btAdicionar_Click(object sender, RoutedEventArgs e)
        {
            var itens = dataGridProduto.Items;
            ProdutosSelecionados.Clear();

            foreach (Produto produto in itens)
            {
                if (produto.IsSelected)
                    ProdutosSelecionados.Add(produto);
            }

            if (ProdutosSelecionados.Count == 0)
                MessageBox.Show("Nenhum produto foi selecionado!", "", MessageBoxButton.OK, MessageBoxImage.Information);

            this.Close();
        }
        private void LoadDataGrid()
        {
            try
            {
                _produtosList = new ProdutoDAO().List();
                dataGridProduto.ItemsSource = _produtosList;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Não Executado", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
