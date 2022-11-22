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
using ProjetoLuna.DataBase;
using ProjetoLuna.Helpers;
using ProjetoLuna.Models;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql;

namespace ProjetoLuna.Views
{
    public partial class CadUser : Window
    {
        private static Conexao _conn = new Conexao();
        public CadUser()
        {
            InitializeComponent();
            Loaded += CadUser_Loaded;
        }

        private void CadUser_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFuncionarios();
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            var form = new Principal();
            form.Show();
            this.Close();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var form = new Login();
            form.Show();
            this.Close();
        }
        private void btCadastrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtSenha.Password.ToString() == txtSenhaConfirma.Password.ToString() && funcionarioCB.SelectedItem != null)
                {

                    Usuario usuario = new Usuario();
                    usuario.Funcionario = funcionarioCB.SelectedItem as Funcionario;
                    usuario.Senha = txtSenha.Password.ToString();

                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    usuarioDAO.Insert(usuario);
                }
                _conn.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadFuncionarios()
        {
            try
            {
                var dao = new FuncionarioDAO();

                funcionarioCB.ItemsSource = dao.List();
                //var comando = _conn.Query();
                //comando.CommandText = "select * from Funcionario;";
                //MySqlDataReader reader = comando.ExecuteReader();

                //while (reader.Read())
                //{
                //    var funcionario = new Funcionario();
                //    funcionario.Nome = reader.GetString("nome_fun");
                //    funcionarioCB.Items.Add(funcionario.Nome);
                //}
                //_conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
