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

            { 
                var comando = _conn.Query();
                comando.CommandText = "insert into Venda value " +
                    "(null, @Valor, @Data, @Hora, @IdFuncionario, @IdCliente)";
                comando.Parameters.AddWithValue("@Valor", venda.Valor);
                comando.Parameters.AddWithValue("@Data", venda.Data);
                comando.Parameters.AddWithValue("@Hora", venda.Hora);
                comando.Parameters.AddWithValue("@IdFuncionario", venda.Funcionario.Id);
                comando.Parameters.AddWithValue("@IdCliente", venda.Cliente.Id);
             

                var resultado = comando.ExecuteNonQuery();
                comando.CommandText = "SELECT LAST_INSERT_ID();";
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                int IdVenda = reader.GetInt32("LAST_INSERT_ID()");

                reader.Close();


                InsertItens(IdVenda, venda.Itens);
                if (resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações!");
                }
            }
           
        }

        private void InsertItens(long vendaId, List<VendaItem> itens)
        {

            foreach (VendaItem item in itens)
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO Produto_Venda (quantidade_itenv, valor_itenv, id_vend_fk, id_prod_fk) " +
                    "VALUES (@quantidade, @valor, @venda, @produto)";

                query.Parameters.AddWithValue("@venda", vendaId);
                query.Parameters.AddWithValue("@produto", item.Produto.Id);
                query.Parameters.AddWithValue("@quantidade", item.Quantidade);
                query.Parameters.AddWithValue("@valor", item.Valor);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Os itens da venda não foi adicionada. Verifique e tente novamente.");
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
                    venda.Funcionario.Id = reader.GetInt32("id_fun_fk");
                    venda.Cliente.Id = reader.GetInt32("id_cli_fk");
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
                comando.Parameters.AddWithValue("@id_fun_fk", venda.Funcionario.Id);
                comando.Parameters.AddWithValue("@id_cli_fk", venda.Cliente.Id);

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
