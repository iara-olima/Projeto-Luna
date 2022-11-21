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
    internal class ProdutoCompraDAO
    {

        private static Conexao _conn = new Conexao();

        public void Insert(ProdutoCompra produtoCompra)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Produto_Compra values (null, @Quantidade, @Valor, @IdCompra, @IdProduto);";

                comando.Parameters.AddWithValue("@Quantidade", produtoCompra.Quantidade);
                comando.Parameters.AddWithValue("@Valor", produtoCompra.Valor);
                comando.Parameters.AddWithValue("@IdCompra", produtoCompra.IdCompra);
                comando.Parameters.AddWithValue("@IdProduto", produtoCompra.IdProduto);

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
        public List<ProdutoCompra> List()
        {
            try
            {
                var lista = new List<ProdutoCompra>();
                var comando = _conn.Query();

                comando.CommandText = "select * from Produto_Compra;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var produto_compra = new ProdutoCompra();

                    produto_compra.Id = reader.GetInt32("id_compProd");
                    produto_compra.Quantidade = reader.GetInt32("qtd_compProd");
                    produto_compra.Valor = DAOHelper.GetDouble(reader, "valor_compProd");
                    produto_compra.IdCompra = reader.GetInt32("id_comp_fk");
                    produto_compra.IdProduto = reader.GetInt32("id_prod_fk");
                    lista.Add(produto_compra);
                }

                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete(ProdutoCompra produtoCompra)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "delete from Produto_Compra where id_compProd = @id";
                comando.Parameters.AddWithValue("id", produtoCompra.Id);
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

        public void Update(ProdutoCompra produtoCompra)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Produto_Compra Set" +
                    "qtd_compProd = @Quantidade, valor_compProd = @Valor, " +
                    "id_comp_fk = @IdComp, id_prod_fk = @IdProduto";

                comando.Parameters.AddWithValue("@qtd_compProd", produtoCompra.Quantidade);
                comando.Parameters.AddWithValue("@valor_compProd", produtoCompra.Valor);
                comando.Parameters.AddWithValue("@id_comp_fk", produtoCompra.IdCompra);
                comando.Parameters.AddWithValue("@id_prod_fk", produtoCompra.IdProduto);

                comando.Parameters.AddWithValue("@id", produtoCompra.Id);

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
