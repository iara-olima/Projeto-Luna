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

        public void Insert(Pagamento pagamento)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "call inserirPagamento(@Data, @Valor, @FormaPag, @Vencimento, @Hora, @IdCaixa, @IdDespesa);";
                comando.Parameters.AddWithValue("@Data", pagamento.Data);
                comando.Parameters.AddWithValue("@Valor", pagamento.Valor);
                comando.Parameters.AddWithValue("@FormaPag", pagamento.FormaPag);
                comando.Parameters.AddWithValue("@Vencimento", pagamento.Vencimento);
                comando.Parameters.AddWithValue("@Hora", pagamento.Hora);
                comando.Parameters.AddWithValue("@IdCaixa", pagamento.Caixa.Id);
                comando.Parameters.AddWithValue("@IdDespesa", pagamento.Despesa.Id);

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
                    pagamento.Vencimento = DAOHelper.GetDateTime(reader, "vencimento_pag");
                    pagamento.Hora = DAOHelper.GetDateTime(reader, "hora_pag");

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

        public void Delete(Pagamento pagamento)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Pagamento WHERE id_pag = @id";
                comando.Parameters.AddWithValue("@id", pagamento.Id);
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
    
        public void Update(Pagamento pagamento)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call atualizarPagamento(@Data, @Valor, @FormaPag, @Vencimento, @Hora, @IdCaixa, @IdDespesa);";

                comando.Parameters.AddWithValue("@Data", pagamento.Data);
                comando.Parameters.AddWithValue("@Valor", pagamento.Valor);
                comando.Parameters.AddWithValue("@FormaPag", pagamento.FormaPag);
                comando.Parameters.AddWithValue("@Vencimento", pagamento.Vencimento);
                comando.Parameters.AddWithValue("@Hora", pagamento.Hora);
                comando.Parameters.AddWithValue("@IdCaixa", pagamento.Caixa.Id);
                comando.Parameters.AddWithValue("@IdDespesa", pagamento.Despesa.Id);

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



