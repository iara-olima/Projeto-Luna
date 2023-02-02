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
    internal class ProdutoVendaDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(ProdutoVenda produtoVenda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Produto_Venda values (null, @Quantidade, @Valor, @IdVenda, @IdProduto);";

                comando.Parameters.AddWithValue("@Quantidade", produtoVenda.Quantidade);
                comando.Parameters.AddWithValue("@Valor", produtoVenda.Valor);
                comando.Parameters.AddWithValue("@IdVenda", produtoVenda.IdVenda);
                comando.Parameters.AddWithValue("@IdProduto", produtoVenda.IdProduto);

                var resultado = comando.ExecuteNonQuery();

                if(resultado == 0)
                {
                    throw new Exception("Ocorreram erros ao salvar as informações!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ProdutoVenda> List()
        {
            try
            {
                var lista = new List<ProdutoVenda>();
                var comando = _conn.Query();

                comando.CommandText = "select * from Produto_Venda;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var produto_venda = new ProdutoVenda();

                    produto_venda.Id = reader.GetInt32("id_compProd");
                    produto_venda.Quantidade = reader.GetInt32("qtd_compProd");
                    produto_venda.Valor = DAOHelper.GetDouble(reader, "valor_compProd");
                    produto_venda.IdVenda = reader.GetInt32("id_vend_fk");
                    produto_venda.IdProduto = reader.GetInt32("id_prod_fk");
                    lista.Add(produto_venda);
                }

                reader.Close();

                return lista;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(ProdutoVenda produtoVenda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "delete from Produto_Venda where id_prodVend = @id";
                comando.Parameters.AddWithValue("id", produtoVenda.Id);
                var resultado = comando.ExecuteNonQuery();
                if(resultado == 0)
                {
                    throw new Exception("Ocorreram problemas ao deletar as informações");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(ProdutoVenda produtoVenda)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "update Produto_Venda set qtd_prodVend = @Quantidade, valor"
            }
        }
    }
}
