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
    internal class VendaDAO
    {

        private static Conexao _conn = new Conexao();

        public void Insert(Venda venda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Venda values (null, @Valor, @Hora, @Data, @IdFuncionario, @IdCliente);";

                comando.Parameters.AddWithValue("@valor", venda.Valor);
                comando.Parameters.AddWithValue("@Hora", venda.Hora);
                comando.Parameters.AddWithValue("@Data", venda.Data);
                comando.Parameters.AddWithValue("@IdFuncionario", venda.IdFuncionario);
                comando.Parameters.AddWithValue("@IdCliente", venda.IdCliente);


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

        public List<Venda> List()
        {
            try
            {
                var lista = new List<Venda>();
                var comando = _conn.Query();

                comando.CommandText = "select * from Venda;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var venda = new Venda();

                    venda.Id = reader.GetInt32("id_vend");
                    venda.Valor = reader.GetDouble("valor_vend");
                    venda.Hora = DAOHelper.GetDateTime(reader, "hora_vend");
                    venda.Data = reader.GetDateTime("data_vend");
                    venda.IdFuncionario = reader.GetInt32("id_fun_fk");
                    venda.IdCliente = reader.GetInt32("id_cli_fk");
                    lista.Add(venda);
                }

                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Venda venda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "delete from Venda where id_Vend = @id";
                comando.Parameters.AddWithValue("id", venda.Id);
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

        public void Update(Venda venda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Venda Set" +
                    "valor_vend = @Valor, hora_vend = @Hora, " +
                    "data_vend = @Data, id_fun_fk = @IdFuncionario, id_cli_fk = @IdCliente";

                comando.Parameters.AddWithValue("@valor_vend", venda.Valor);
                comando.Parameters.AddWithValue("@hora_vend", venda.Hora);
                comando.Parameters.AddWithValue("@data_vend", venda.Data);
                comando.Parameters.AddWithValue("@id_fun_fk", venda.IdFuncionario);
                comando.Parameters.AddWithValue("@id_cli_fk", venda.IdCliente);

                comando.Parameters.AddWithValue("@id", venda.Id);

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
