
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
    internal class UsuarioDAO
    {

        private static Conexao _conn = new Conexao();

        public void Insert(Usuario usuario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "insert into Usuario values (null, @CPF, @Senha, @IdFuncionario);";

                comando.Parameters.AddWithValue("@CPF", usuario.CPF);
                comando.Parameters.AddWithValue("@Senha", usuario.Senha);
                comando.Parameters.AddWithValue("@IdFuncionario", usuario.IdFuncionario);

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

        public List<Usuario> List()
        {
            try
            {
                var lista = new List<Usuario>();
                var comando = _conn.Query();

                comando.CommandText = "select * from Usuario;";

                MySqlDataReader reader = comando.ExecuteReader();

                while (reader.Read())
                {
                    var usuario = new Usuario();

                    usuario.Id = reader.GetInt32("id_usu");
                    usuario.CPF = reader.GetString("cpf_usu");
                    usuario.Senha = DAOHelper.GetString(reader, "senha_usu");
                    usuario.IdFuncionario = reader.GetInt32("id_fun_fk");
                    lista.Add(usuario);
                }

                reader.Close();

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(Usuario usuario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "delete from Usuario where id_usu = @id";
                comando.Parameters.AddWithValue("id", usuario.Id);
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

        public void Update(Usuario usuario)
        {
            try
            {
                var comando = _conn.Query();

                comando.CommandText = "Update Usuario Set" +
                    "cpf_usu = @CPF, senha_usu = @Senha, " +
                    "id_fun_fk = @IdFuncionario";

                comando.Parameters.AddWithValue("@cpf_usu", usuario.CPF);
                comando.Parameters.AddWithValue("@senha_usu", usuario.Senha);
                comando.Parameters.AddWithValue("@id_fun_fk", usuario.IdFuncionario);

                comando.Parameters.AddWithValue("@id", usuario.Id);

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
