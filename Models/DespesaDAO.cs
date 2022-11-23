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
    internal class DespesaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Despesa despesa)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "call inserirDespesa(@Descricao, @Data, @Hora, @Valor, @Parcelas, @ValorParc, @Tipo);";
                comando.Parameters.AddWithValue("@Descricao", despesa.Descricao);
                comando.Parameters.AddWithValue("@Data", despesa.Data);
                comando.Parameters.AddWithValue("@Hora", despesa.Hora);
                comando.Parameters.AddWithValue("@Valor", despesa.Valor);
                comando.Parameters.AddWithValue("@Parcelas", despesa.Parcelas);
                comando.Parameters.AddWithValue("@ValorParc", despesa.ValorParc);
                comando.Parameters.AddWithValue("@Tipo", despesa.Tipo);

                var resultado = comando.ExecuteNonQuery();
                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao savar as informações!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Despesa> List()
        {
            try
            {
                var lista = new List<Despesa>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Despesa";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var despesa = new Despesa();

                    despesa.Id = reader.GetInt32("id_desp");
                    despesa.Descricao = DAOHelper.GetString(reader, "descricao_desp");
                    despesa.Data = DAOHelper.GetDateTime(reader, "data_desp");
                  //  despesa.Hora = DAOHelper.GetDateTime(reader, "hora_desp");
                    despesa.Valor = DAOHelper.GetDouble(reader, "valor_desp");
                    despesa.Parcelas = reader.GetInt32("parcelas_desp");
                    despesa.ValorParc = DAOHelper.GetDouble(reader, "valorParcela_desp");
                    despesa.Tipo = DAOHelper.GetString(reader, "tipo_desp");


                    lista.Add(despesa);
                }
                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Despesa despesa)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Despesa WHERE id_desp = @id";
                comando.Parameters.AddWithValue("@id", despesa.Id);
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
        public void Update(Despesa despesa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Despesa Set " +
                    "descricao_desp = @Descricao, data_desp = @Data, hora_desp = @Hora, valor_desp = @Valor +" +
                    " parcelas_desp = @Parcelas, valorParcela_desp = @ValorParcela, tipo_desp = @Tipo, id_forn_fk = @IdFornecedor " +
                    "Where id_cli = @id";

                comando.Parameters.AddWithValue("@Descricao", despesa.Descricao);
                comando.Parameters.AddWithValue("@Data", despesa.Data);
                comando.Parameters.AddWithValue("@Hora", despesa.Hora);
                comando.Parameters.AddWithValue("@Valor", despesa.Valor);
                comando.Parameters.AddWithValue("@Parcelas", despesa.Parcelas);
                comando.Parameters.AddWithValue("@ValorParcela", despesa.ValorParc);
                comando.Parameters.AddWithValue("@Tipo", despesa.Tipo);
                comando.Parameters.AddWithValue("@IdForncedor", despesa.Fornecedor.Id);

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
