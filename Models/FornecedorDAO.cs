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
    internal class FornecedorDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Fornecedor fornecedor)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Fornecedor value " +
                    "(null, @NomeFantasia, @RazaoSocial, @CNPJ, @Email, @Telefone, @Endereco)";

                comando.Parameters.AddWithValue("@NomeFantasia", fornecedor.NomeFantasia);
                comando.Parameters.AddWithValue("@RazaoSocial", fornecedor.RazaoSocial);
                comando.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
                comando.Parameters.AddWithValue("@Email", fornecedor.Email);
                comando.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
                comando.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);

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

        public List<Fornecedor> List()
        {
            try
            {
                var lista = new List<Fornecedor>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Fornecedor";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var fornecedor = new Fornecedor();

                    fornecedor.Id = reader.GetInt32("id_forn");
                    fornecedor.NomeFantasia = DAOHelper.GetString(reader, "nomeFantasia_forn");
                    fornecedor.RazaoSocial = DAOHelper.GetString(reader, "razaoSoc_forn");
                    fornecedor.CNPJ = DAOHelper.GetString(reader, "cnpj_forn");
                    fornecedor.Email = DAOHelper.GetString(reader, "email_forn");
                    fornecedor.Telefone = DAOHelper.GetString(reader, "telefone_forn");
                    fornecedor.Endereco = DAOHelper.GetString(reader, "endereco_forn");
                    lista.Add(fornecedor);
                }
                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Fornecedor fornecedor)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Fornecedor WHERE id_forn = @id";
                comando.Parameters.AddWithValue("@id", fornecedor.Id);
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

        public void Update(Fornecedor fornecedor)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Fornecedor Set " +
                    "nomeFantasia_forn = @NomeFantasia, razaoSoc_forn = @RazaoSocial, cnpj_forn = @CNPJ, email_forn = @Email, telefone_forn = @Telefone, endereco_forn = @Endereco " +
                    "Where id_forn = @id";

                comando.Parameters.AddWithValue("@NomeFantasia", fornecedor.NomeFantasia);
                comando.Parameters.AddWithValue("@RazaoSocial", fornecedor.RazaoSocial);
                comando.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ);
                comando.Parameters.AddWithValue("@Email", fornecedor.Email);
                comando.Parameters.AddWithValue("@Telefone", fornecedor.Telefone);
                comando.Parameters.AddWithValue("@Endereco", fornecedor.Endereco);

                comando.Parameters.AddWithValue("@id", fornecedor.Id);

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
