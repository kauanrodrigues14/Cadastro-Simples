using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace ExemploCRUD.DAL
{
    public class AmigoDAL
    {
        private Conexao con;
        public AmigoDAL()
        {
            con = new Conexao();
        }

        //Cadastrar
        public void Cadastrar(BLL.Amigo a)
        {
            //Declarar um objeto de COMANDO SQL
            SqlCommand cmd = new SqlCommand();
            //Configurar a conexao que sera executado o comando sql
            cmd.Connection = con.Conectar(); //Abre a conexao com o BD
            //Configurar o comando sql que sera executado
            cmd.CommandText = @"INSERT INTO TBAmigos(NOME,TEL)
                                VALUES(@nome,@telefone)";
            //Passar os valores para os paramentros SQL
            cmd.Parameters.AddWithValue("@nome"     , a.Nome);
            cmd.Parameters.AddWithValue("@telefone" , a.Telefone);
            cmd.ExecuteNonQuery();//Executa o comando sql
            con.Desconectar(); //Fecha a conexao com o BD
        }

        //Atualizar
        public void Atualizar(BLL.Amigo a)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"UPDATE TBAmigos SET
                                    NOME=@nome,
                                    TEL=@telefone
                                WHERE
                                    ID=@id";
            cmd.Parameters.AddWithValue("@nome"     , a.Nome);
            cmd.Parameters.AddWithValue("@telefone" , a.Telefone);
            cmd.Parameters.AddWithValue("@id"       , a.Id);
            cmd.ExecuteNonQuery();
            con.Desconectar(); 
        }

        //Excluir
        public void Excluir(BLL.Amigo a)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"DELETE FROM TBAmigos WHERE ID=@id";
            cmd.Parameters.AddWithValue("@id", a.Id);
            cmd.ExecuteNonQuery();
            con.Desconectar();
        }

        //Consultar
        public DataTable Consultar()
        {
            //Tabela de dados no PADRAO C# (int, string, float, double, ...)
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = "SELECT ID,NOME,TEL FROM TBAmigos";

            //ADAPTADOR DE DADOS - PADRAO SQL (int, varchar, char, money, ...)
            //                     PARA PADRAO C# (int, string, float, ...)
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd; //Configurando o local do comando "select"
            da.Fill(dt); //Preenche o DataTable com os dados ja adaptados para C#
            con.Desconectar();
            return dt;
        }

        //SOBRECARGA DE METODO
        //Sao metodos com o MESMO nome porem com ASSINATURAS DIFERENTES
        public DataTable Consultar(BLL.Amigo a)
        {
            //Tabela de dados no PADRAO C# (int, string, float, double, ...)
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT ID,NOME,TEL FROM TBAmigos
                                WHERE NOME LIKE @nome";
            cmd.Parameters.AddWithValue("@nome", "%" + a.Nome + "%");

            //ADAPTADOR DE DADOS - PADRAO SQL (int, varchar, char, money, ...)
            //                     PARA PADRAO C# (int, string, float, ...)
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd; //Configurando o local do comando "select"
            da.Fill(dt); //Preenche o DataTable com os dados ja adaptados para C#
            con.Desconectar();
            return dt;
        }


        public BLL.Amigo PreencherPeloId(BLL.Amigo a)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con.Conectar();
            cmd.CommandText = @"SELECT ID, NOME, TEL 
                                FROM TBAmigos
                                WHERE ID = @id";
            cmd.Parameters.AddWithValue("@id", a.Id);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.HasRows) //Possui Linhas ?
            {
                dr.Read();
                a.Id        = Convert.ToInt32( dr["ID"] );
                a.Nome      = dr["NOME"].ToString();
                a.Telefone  = dr["TEL"].ToString();
                dr.Close(); //Fechar o leitor (limpar da memoria)
            }
            else
            {
                a.Id = 0; //ZERO NAO EXISTE NO BANCO DE DADOS
            }
            con.Desconectar();
            return a;
        }

    }//CHAVE fecha a classe
}//CHAVE fecha o namespace
