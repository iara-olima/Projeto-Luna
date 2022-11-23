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
    class CompraDAO
    {
        private static Conexao _conn = new Conexao();
        public void Insert(Compra compra)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "insert into Compra value " +
                    "(null, @Valor, @Data, @FormaPag, @Parcela, @Descricao, @ValorParc, @IdFornecedor, @IdFuncionario)";
                comando.Parameters.AddWithValue("@Valor", compra.Valor);
                comando.Parameters.AddWithValue("@Data", compra.Data);
                comando.Parameters.AddWithValue("@FormaPag", compra.FormaPagamento);
                comando.Parameters.AddWithValue("@Parcela", compra.Parcela);
                comando.Parameters.AddWithValue("@Descricao", compra.Descricao);
                comando.Parameters.AddWithValue("@ValorParc", compra.ValorParc);
                comando.Parameters.AddWithValue("@IdFornecedor", compra.Fornecedor.Id);
                comando.Parameters.AddWithValue("@IdFuncionario", compra.Funcionario.Id);


                var resultado = comando.ExecuteNonQuery();
                comando.CommandText = "SELECT LAST_INSERT_ID();";
                MySqlDataReader reader = comando.ExecuteReader();
                reader.Read();
                int IdCompra = reader.GetInt32("LAST_INSERT_ID()");

                reader.Close();

                InsertItens(IdCompra, compra.Itens);


                InsertItens(IdCompra, compra.Itens);
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

        private void InsertItens(long compraId, List<CompraItem> itens)
        {

            foreach (CompraItem item in itens)
            {
                var query = _conn.Query();
                query.CommandText = "INSERT INTO Produto_Compra (id_comp_fk, id_prod_fk, quantidade_itenc, valor_itenc, valor_total_itenc) " +
                    "VALUES (@compra, @produto, @quantidade, @valor, @valor_total)";

                query.Parameters.AddWithValue("@compra", compraId);
                query.Parameters.AddWithValue("@produto", item.Produto.Id);
                query.Parameters.AddWithValue("@quantidade", item.Quantidade);
                query.Parameters.AddWithValue("@valor", item.Valor);
                query.Parameters.AddWithValue("@valor_total", item.ValorTotal);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Os itens da compra não foi adicionada. Verifique e tente novamente.");
            }
        }

        public List<Compra> List()
        {
            try
            {
                var lista = new List<Compra>();
                var comando = _conn.Query();
                comando.CommandText = "SELECT * FROM Compra";
                MySqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var compra = new Compra();

                    compra.Id = reader.GetInt32("id_comp");
                    compra.Valor = DAOHelper.GetDouble(reader, "valor_comp");
                    compra.Data = DAOHelper.GetDateTime(reader, "data_comp");
                    compra.FormaPagamento = DAOHelper.GetString(reader, "formaPag_comp");
                    compra.Parcela = reader.GetInt32("pagamento_comp");
                    compra.Descricao = DAOHelper.GetString(reader, "descricao_comp");
                    compra.ValorParc = DAOHelper.GetDouble(reader, "valorParc_comp");
                    compra.Fornecedor.Id = reader.GetInt32("id_forn_fk");
                    compra.Fornecedor.Id = reader.GetInt32("id_fun_fk");

                    lista.Add(compra);
                }
                reader.Close();
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Compra compra)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Compra WHERE id_comp = @id";
                comando.Parameters.AddWithValue("@id", compra.Id);
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
    }
}
