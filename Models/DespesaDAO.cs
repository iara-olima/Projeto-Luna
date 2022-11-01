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
    internal class DespesaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Despesa despesa)
        {

            try
            {

                var comando = _conn.Query();

                comando.CommandText = "insert into Despesa value " +
                    "(null, @Descricao, @Data, @Hora, @Valor, @Parcelas, @Valor Parcela, @Tipo)";

                comando.Parameters.AddWithValue("@Descricao", despesa.Descricao);
                comando.Parameters.AddWithValue("@Data", despesa.Data);
                comando.Parameters.AddWithValue("@Hora", despesa.Hora);
                comando.Parameters.AddWithValue("@Valor", despesa.Valor);
                comando.Parameters.AddWithValue("@Parcelas", despesa.Parcelas);
                comando.Parameters.AddWithValue("@Valor Parcela", despesa.ValorParc);
                comando.Parameters.AddWithValue("@Tipo", despesa.Tipo);



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
    }
}
