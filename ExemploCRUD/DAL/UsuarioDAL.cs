using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD.DAL
{
    public class UsuarioDAL
    {
        Conexao con = new Conexao();
        BLL.Criptografia cripto = new BLL.Criptografia();
        public void Cadastrar(BLL.Usuario u)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"INSERT INTO TBUsuarios(
                                    Usuario,Senha,Tipo_Usuario) VALUES
                                (@usuario,@senha,@tipo)";
            cmd.Parameters.AddWithValue("@usuario"  , u.UsuarioLogin);
            cmd.Parameters.AddWithValue("@senha"    , cripto.RetornaMD5( u.Senha ) );
            cmd.Parameters.AddWithValue("@tipo"     , u.TipoUsuario );
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        public BLL.Usuario Autenticar(BLL.Usuario u)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT
                                    USUARIO,SENHA,TIPO_USUARIO
                                FROM TBUsuarios
                                WHERE USUARIO=@usuario AND SENHA=@senha";
            cmd.Parameters.AddWithValue("@usuario", u.UsuarioLogin);
            cmd.Parameters.AddWithValue("@senha"  , cripto.RetornaMD5( u.Senha ) );
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows) //Possui Linhas Resultado ?
            {
                dr.Read();
                u.UsuarioLogin  = dr["USUARIO"].ToString();
                u.Senha         = dr["SENHA"].ToString();
                u.TipoUsuario   = dr["TIPO_USUARIO"].ToString();
                dr.Close();
            }
            else
            {
                u.UsuarioLogin = "";
            }
            return u;
        }
    }
}
