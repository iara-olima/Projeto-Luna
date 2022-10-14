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
    internal class RecebimentoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Recebimento rec)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Recebimento value " +
                    "(null, @Data, @Parcela, @Valor, @Forma, @Status, @Vencimento, @Hora, @ValorParcela, @null,@null)";

                comando.Parameters.AddWithValue("@Data", rec.Data?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@Parcela", rec.Parcela);
                comando.Parameters.AddWithValue("@Valor", rec.Valor);
                comando.Parameters.AddWithValue("@Forma", rec.Forma);
                comando.Parameters.AddWithValue("@Status", rec.Status);
                comando.Parameters.AddWithValue("@Vencimento", rec.Vencimento);
                comando.Parameters.AddWithValue("@Hora", rec.Hora);
                comando.Parameters.AddWithValue("@ValorParcela", rec.ValorParc);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
   

        public List<Recebimento> List()
        {
            try
            {
                var lista = new List<Recebimento>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Recebimento";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var recebimento = new Recebimento();


                  /*  recebimento.Id = reader.GetInt32("id_rec");
                    recebimento.Data = DAOHelper.GetDateTime(reader, "data_rec");
                    recebimento.Parcela = DAOHelper.(reader, "parcela_rec");
                    recebimento.Valor = DAOHelper.GetString(reader, "funcao_fun");
                    recebimento.Forma = DAOHelper.GetString(reader, "cpf_fun");
                    recebimento.Status = DAOHelper.GetString(reader, "email_fun");
                    recebimento.Vencimento= DAOHelper.GetString(reader, "telefone_fun");
                    recebimento.Hora = DAOHelper.GetString(reader, "endereco_fun");
                    recebimento.ValorParcela = DAOHelper.GetString(reader, "sexo_fun");
                    lista.Add(funcionario); */
                }
                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Funcionario WHERE id_fun = @id";
                comando.Parameters.AddWithValue("@id", funcionario.Id);
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

        public void Update(Funcionario funcionario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Funcionario Set" +
                    "nome_fun = @Nome, data_nasc_fun = @DataNasc, salario_fun = @Salario, funcao_fun = @Funcao, cpf_fun = @CPF,email_fun = @Email, telefone_fun = @Telefone, endereco_fun = @Endereco, sexo_fun = @Sexo" +
                    "Where id_fun = @id";

                comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@DataNasc", funcionario.DataNasc?.ToString("yyyy-MM-dd"));
                comando.Parameters.AddWithValue("@Salario", funcionario.Salario);
                comando.Parameters.AddWithValue("@Funcao", funcionario.Funcao);
                comando.Parameters.AddWithValue("@CPF", funcionario.CPF);
                comando.Parameters.AddWithValue("@Email", funcionario.Email);
                comando.Parameters.AddWithValue("@Telefone", funcionario.Telefone);
                comando.Parameters.AddWithValue("@Endereco", funcionario.Endereco);
                comando.Parameters.AddWithValue("@Sexo", funcionario.Sexo);

                comando.Parameters.AddWithValue("@id", funcionario.Id);

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
