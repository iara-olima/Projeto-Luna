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
using ProjetoLuna.Views;

namespace ProjetoLuna
{
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();

        }

        private void btEntrar_Click(object sender, RoutedEventArgs e)
        {
            EntrarLogin();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Space)
                EntrarLogin();
        }

        private void EntrarLogin()
        {
            Login form = new Login();
            form.Show();
            this.Close();
        }
    }
}
