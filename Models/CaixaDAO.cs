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
    internal class CaixaDAO
    {
        private static Conexao _conn = new Conexao();
        public void Insert(Caixa caixa)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "call inserirCaixa(@Data, @SaldoInicial, @SaldoFinal, @Recebimentos, @Pagamentos, @Funcionario);";
                comando.Parameters.AddWithValue("@Data", caixa.Data);
                comando.Parameters.AddWithValue("@SaldoInicial", caixa.SaldoInicial);
                comando.Parameters.AddWithValue("@SaldoFinal", caixa.SaldoFinal);
                comando.Parameters.AddWithValue("@Recebimentos", caixa.Recebimentos);
                comando.Parameters.AddWithValue("@Pagamentos", caixa.Pagamentos);
                comando.Parameters.AddWithValue("@Funcionario", caixa.Funcionario.Id);
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
        public List<Caixa> List()
        {
            try
            {
                var lista = new List<Caixa>();
                var comando = _conn.Query();
                comando.CommandText = "SELECT * FROM Caixa";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var caixa = new Caixa();

                    caixa.Id = reader.GetInt32("id_cai");
                    caixa.Data = DAOHelper.GetDateTime(reader, "data_cai");
                    caixa.SaldoInicial = DAOHelper.GetDouble(reader, "saldoInic_cai");
                    caixa.SaldoFinal = DAOHelper.GetDouble(reader, "saldoFin_cai");
                    caixa.Recebimentos = DAOHelper.GetDouble(reader, "recebimento_cai");
                    caixa.Pagamentos = DAOHelper.GetDouble(reader, "pagamento_cai");
                    lista.Add(caixa);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(Caixa caixa)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Caixa WHERE id_cli = @id";
                comando.Parameters.AddWithValue("@id", caixa.Id);
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
        public void Update(Caixa caixa)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "call atualizarCaixa(@id, @Data, @SaldoInicial, @SaldoFinal, @Recebimentos, @Pagamentos);";

                comando.Parameters.AddWithValue("@Data", caixa.Data);
                comando.Parameters.AddWithValue("@SaldoInicial", caixa.SaldoInicial);
                comando.Parameters.AddWithValue("@SaldoFinal", caixa.SaldoFinal);
                comando.Parameters.AddWithValue("@Recebimentos", caixa.Recebimentos);
                comando.Parameters.AddWithValue("@Pagamentos", caixa.Pagamentos);
                comando.Parameters.AddWithValue("@IdFuncionario", caixa.Funcionario.Id);

                comando.Parameters.AddWithValue("@id", caixa.Id);

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