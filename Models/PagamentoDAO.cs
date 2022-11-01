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
    internal class PagamentoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Pagamento pag)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Pagamento value " +
                    "(null, @Data, @Valor, @FormaPag, @Status, @Vencimento, @Hora, @IdCaixa, @IdDespesa)";

                comando.Parameters.AddWithValue("@Data", pag.Data?.ToString("D"));
                comando.Parameters.AddWithValue("@Valor", pag.Valor);
                comando.Parameters.AddWithValue("@FormaPag", pag.FormaPag);
                comando.Parameters.AddWithValue("@Status", pag.Status);
                comando.Parameters.AddWithValue("@Vencimento", pag.Vencimento?.ToString("D"));
                comando.Parameters.AddWithValue("@Hora", pag.Hora?.ToString("T"));
                comando.Parameters.AddWithValue("@IdCaixa", pag.IdCaixa);
                comando.Parameters.AddWithValue("@IdDespesa", pag.IdDespesa);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public List<Pagamento> List()
        {
            try
            {
                var lista = new List<Pagamento>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Pagamento";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var pagamento = new Pagamento();

                    pagamento.Id = reader.GetInt32("id_pag");
                    pagamento.Data = DAOHelper.GetDateTime(reader, "data_pag");
                    pagamento.Valor = DAOHelper.GetDouble(reader, "valor_pag");
                    pagamento.FormaPag = DAOHelper.GetString(reader, "forma_pag");
                    pagamento.Status = DAOHelper.GetString(reader, "stts_pag");
                    pagamento.Vencimento = DAOHelper.GetDateTime(reader, "vencimento_pag");
                    pagamento.Hora = DAOHelper.GetDateTime(reader, "hora_pag");
                    pagamento.IdCaixa = reader.GetInt32("id_cai_fk");
                    pagamento.IdDespesa = reader.GetInt32("id_desp_fk");
                    lista.Add(pagamento);
                }
                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Pagamento pag)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Pagamento WHERE id_pag = @id";
                comando.Parameters.AddWithValue("@id", pag.Id);
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

        public void Update(Pagamento pag)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Pagamento Set" +
                    "data_pag = @Data, valor_pag = @Valor, forma_pag = @FormaPag, stts_pag = @Status, vencimento_pag = @Vencimento, hora_pag = @Hora, id_cai_fk = @IdCaixa, id_desp_fk = @IdDespesa" +
                    "Where id_pag = @id";

                comando.Parameters.AddWithValue("@Data", pag.Data?.ToString("D"));
                comando.Parameters.AddWithValue("@Valor", pag.Valor);
                comando.Parameters.AddWithValue("@FormaPag", pag.FormaPag);
                comando.Parameters.AddWithValue("@Status", pag.Status);
                comando.Parameters.AddWithValue("@Vencimento", pag.Vencimento?.ToString("D"));
                comando.Parameters.AddWithValue("@Hora", pag.Hora?.ToString("T"));
                comando.Parameters.AddWithValue("@IdCaixa", pag.IdCaixa);
                comando.Parameters.AddWithValue("@IdDespesa", pag.IdDespesa);

                comando.Parameters.AddWithValue("@id", pag.Id);

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
