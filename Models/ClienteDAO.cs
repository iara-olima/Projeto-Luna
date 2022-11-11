using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLuna.DataBase;
using ProjetoLuna.Helpers;
using MySql.Data.MySqlClient;

namespace ProjetoLuna.Models
{
    internal class ClienteDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Cliente cliente)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Cliente value " +
                    "(null, @Nome, @DataNasc, @Email, @Telefone, @CPF, @Endereco, @Sexo)";

                comando.Parameters.AddWithValue("@Nome", cliente.Nome);
                comando.Parameters.AddWithValue("@DataNasc", cliente.DataNasc?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@Email", cliente.Email);
                comando.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@CPF", cliente.CPF);
                comando.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                comando.Parameters.AddWithValue("@Sexo", cliente.Sexo);

                var resultado = comando.ExecuteNonQuery();

                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Cliente> List()
        {
            try
            {
                var lista = new List<Cliente>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Cliente";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var cliente = new Cliente();

                    cliente.Id = reader.GetInt32("id_cli");
                    cliente.Nome = DAOHelper.GetString(reader, "nome_cli");
                    cliente.DataNasc = DAOHelper.GetDateTime(reader, "dataNasc_cli");
                    cliente.Email = DAOHelper.GetString(reader, "email_cli");
                    cliente.Telefone = DAOHelper.GetString(reader, "telefone_cli");
                    cliente.CPF = DAOHelper.GetString(reader, "cpf_cli");
                    cliente.Endereco = DAOHelper.GetString(reader, "endereco_cli");
                    cliente.Sexo = DAOHelper.GetString(reader, "sexo_cli");
                    lista.Add(cliente);
                }
                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Cliente cliente)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Cliente WHERE id_cli = @id";
                comando.Parameters.AddWithValue("@id", cliente.Id);
                var resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("Ocorreram problemas ao deletar as informações");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Cliente cliente)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Cliente Set " +
                    "nome_cli = @Nome, dataNasc_cli = @DataNasc, email_cli = @Email, telefone_cli = @Telefone, cpf_cli = @CPF, endereco_cli = @Endereco, sexo_cli = @Sexo " +
                    "Where id_cli = @id";

                comando.Parameters.AddWithValue("@id", cliente.Id);
                comando.Parameters.AddWithValue("@Nome", cliente.Nome);
                comando.Parameters.AddWithValue("@DataNasc", cliente.DataNasc?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@Email", cliente.Email);
                comando.Parameters.AddWithValue("@Telefone", cliente.Telefone);
                comando.Parameters.AddWithValue("@CPF", cliente.CPF);
                comando.Parameters.AddWithValue("@Endereco", cliente.Endereco);
                comando.Parameters.AddWithValue("@Sexo", cliente.Sexo);

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
