﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoLuna.DataBase;
using ProjetoLuna.Helpers;
using MySql.Data.MySqlClient;

namespace ProjetoLuna.Models
{
    internal class CompraDAO
    {
        private static Conexao _conn = new Conexao();
        public void Insert(Compra compra)
        {
            try
            {
                var comando = _conn.Query();
                comando.CommandText = "insert into Cliente value " +
                    "(null, @Valor, @Data, @Hora, @Parcela, @Descricao)";
                comando.Parameters.AddWithValue("@Valor", compra.Valor);
                comando.Parameters.AddWithValue("@Data", compra.Data);
                comando.Parameters.AddWithValue("@Hora", compra.Hora);
                comando.Parameters.AddWithValue("@Parcela", compra.Parcela);
                comando.Parameters.AddWithValue("@Descricao", compra.Descricao);
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

                    compra.Id = reader.GetInt32("id_cai");
                    compra.Valor = DAOHelper.GetDouble(reader, "valor_comp");
                    compra.Data = DAOHelper.GetDateTime(reader, "data_comp");
                    compra.Hora = DAOHelper.GetDateTime(reader, "hora_comp");
                    compra.Parcela = reader.GetInt32("pagamento_comp");
                    compra.Descricao = DAOHelper.GetString(reader, "descricao_comp");
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

        public void Update(Compra compra)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Compra Set" +
                    "valor_comp = @Valor, data_comp = @Data, " +
                    "hora_comp = @Hora, parcela_comp = @Parcela, descricao_comp = @Descricao";

                comando.Parameters.AddWithValue("@Valor", compra.Valor);
                comando.Parameters.AddWithValue("@Data", compra.Data);
                comando.Parameters.AddWithValue("@Hora", compra.Hora);
                comando.Parameters.AddWithValue("@Pagamento", compra.Parcela);
                comando.Parameters.AddWithValue("@Descricao", compra.Descricao);

                comando.Parameters.AddWithValue("@id", compra.Id);

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
