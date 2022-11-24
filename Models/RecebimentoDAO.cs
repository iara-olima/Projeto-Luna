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
    internal class RecebimentoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Recebimento rec)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call inserirRecebimento(@Data, @Parcela, @ValorParcela, @Valor, @Forma, @Vencimento, @Hora, @IdCaixa, @IdVenda);";

                comando.Parameters.AddWithValue("@Data", rec.Data?.ToString("D"));
                comando.Parameters.AddWithValue("@Parcela", rec.Parcela);
                comando.Parameters.AddWithValue("@ValorParcela", rec.ValorParcela);
                comando.Parameters.AddWithValue("@Valor", rec.Valor);
                comando.Parameters.AddWithValue("@Forma", rec.Forma);
                comando.Parameters.AddWithValue("@Vencimento", rec.Vencimento?.ToString("D"));
                comando.Parameters.AddWithValue("@Hora", rec.Hora?.ToString("T"));
                comando.Parameters.AddWithValue("@IdCaixa", rec.Caixa.Id);
                comando.Parameters.AddWithValue("@IdVenda", rec.Venda.Id);
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
                }
                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Recebimento recebimento)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Recebimento WHERE id_rec = @id";
                comando.Parameters.AddWithValue("@id", recebimento.Id);
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

        public void Update(Recebimento recebimento)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call atualizarRecebimento(@id, @Data, @Parcela, @ValorParcela, @Valor, @Forma, @Vencimento, @Hora, @IdCaixa, @IdVenda);";

                comando.Parameters.AddWithValue("@Data", recebimento.Data?.ToString("D"));
                comando.Parameters.AddWithValue("@Parcela", recebimento.Parcela);
                comando.Parameters.AddWithValue("@ValorParcela", recebimento.ValorParcela);
                comando.Parameters.AddWithValue("@Valor", recebimento.Valor);
                comando.Parameters.AddWithValue("@Forma", recebimento.Forma);
                comando.Parameters.AddWithValue("@Vencimento", recebimento.Vencimento?.ToString("D"));
                comando.Parameters.AddWithValue("@Hora", recebimento.Hora?.ToString("T"));
                comando.Parameters.AddWithValue("@IdCaixa", recebimento.Caixa.Id);
                comando.Parameters.AddWithValue("@IdVenda", recebimento.Venda.Id);

                comando.Parameters.AddWithValue("@id", recebimento.Id);

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
