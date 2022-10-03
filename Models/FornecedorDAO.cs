using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLuna.Database;
using ProjetoLuna.Helpers;
using MySql.Data.MySqlClient;

namespace ProjetoLuna.Models
{
    internal class FornecedorDAO
    {
        private static Conexao _conn = new Conexao();

        public void Update(Cliente cliente)
        {

            try
            {
                var comando = _conn.Query();


                comando.CommandText = "update Cliente Set " +
                        "nome_cli = @Nome, dataNasc_cli = @dataNasc, email_cli = @Email, telefone_cli = @Telefone," +
                        "cpf_cli = @CPF, endereco_cli = @Endereco, sexo_cli = @Sexo" +
                        "Where id_cli = @id";

                comando.Parameters.AddWithValue("@Nome", cliente.Nome);
                comando.Parameters.AddWithValue("@DataNasc", cliente.DataNasc?.ToString("yyyyy-MM-dd"));
                comando.Parameters.AddWithValue("@Email", cliente.Email);
                comando.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@CPF", cliente.CPF);
                comando.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                comando.Parameters.AddWithValue("@Sexo", cliente.Sexo);

                comando.Parameters.AddWithValue("@id", cliente.Id);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao atualizar as informações");
                }

            }

            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
