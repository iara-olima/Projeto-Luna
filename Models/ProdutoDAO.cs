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
    internal class ProdutoDAO
    {
        private static Conexao _conn = new Conexao();

        public void Insert(Produto produto)
        {

            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Produto value " +
                    "(null, @Nome, @Marca, @Quantidade, @ValorVenda, @ValorCompra, @Descricao )";

                comando.Parameters.AddWithValue("@Nome", produto.Nome);
                comando.Parameters.AddWithValue("@Marca", produto.Marca);
                comando.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                comando.Parameters.AddWithValue("@ValorVenda", produto.ValorVenda);
                comando.Parameters.AddWithValue("@ValorCompra", produto.ValorCompra);
                comando.Parameters.AddWithValue("@Descricao", produto.Descricao);

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

        public List<Produto> List()
        {
            try
            {
                var lista = new List<Produto>();
                var comando = _conn.Query();

                comando.CommandText = "SELECT * FROM Produto";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var produto = new Produto();

                    produto.Id = reader.GetInt32("id_prod");
                    produto.Nome = DAOHelper.GetString(reader, "nome_prod");
                    produto.Marca = DAOHelper.GetString(reader, "marca_prod");
                    produto.Quantidade = DAOHelper.GetString(reader, "qtd_prod");
                    produto.ValorVenda = DAOHelper.GetDouble(reader, "valorVenda_prod");
                    produto.ValorCompra = DAOHelper.GetDouble(reader, "valor_compra");
                    produto.Descricao = DAOHelper.GetString(reader, "descricao_prod");
                    lista.Add(produto);
                }
                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Produto produto)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "DELETE FROM Produto WHERE id_prod = @id";
                comando.Parameters.AddWithValue("@id", produto.Id);
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

        public void Update(Produto produto)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Produto Set " +
                    "nome_prod = @Nome, marca_prod = @Marca, qtd_prod = @Quantidade, valor_venda_prod = @ValorVenda, valor_compra_prod = @ValorCompra " +
                    "Where id_prod = @id";

                comando.Parameters.AddWithValue("@Nome", produto.Nome);
                comando.Parameters.AddWithValue("@Marca", produto.Marca);
                comando.Parameters.AddWithValue("@Quantidade", produto.Quantidade);
                comando.Parameters.AddWithValue("@ValorVenda", produto.ValorVenda);
                comando.Parameters.AddWithValue("@ValorCompra", produto.ValorCompra);
                comando.Parameters.AddWithValue("@Descricao", produto.Descricao);

                comando.Parameters.AddWithValue("@id", produto.Id);

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
