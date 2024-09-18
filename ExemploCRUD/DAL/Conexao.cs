using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data; //Trabalhar com DADOS
using System.Data.SqlClient; //Cliente do serv. SQL

namespace ExemploCRUD.DAL
{
    public class Conexao
    {
        //Declaracao GLOBAL de um atributo de conexao com o serv. SQL
        private SqlConnection con; //null

        //Metodo Construtor
        // --> E executado SEMPRE que um objeto for instanciado
        //     a partir da classe. DEVE possuir o mesmo nome da classe.
        public Conexao()
        {
            con = new SqlConnection(); //Instanciou um objeto de conexao SQL
            //Configurar a conexao por uma string contendo:
            // - Endereco do Servidor (nome dele na rede ou IP)
            // - Nome da Base de Dados (BD)
            // - Autenticacao (Integrada ou nao --> usuario e senha)
            con.ConnectionString = @"Data Source=(local)\sqlexpress;
                                     Initial Catalog=BDContatos;
                                     Integrated Security=true";

            //con.ConnectionString = @"Data Source=(local)\sqlexpress;
            //                         Initial Catalog=BDContatos;
            //                         User=root ; Password=1234;";

        }//Chave do metodo construtor

        //Assinatura do Metodo
        // [Modificador de Acesso] <tipoRetorno> Nome(parametrosOpcionais)
        public SqlConnection Conectar()
        {
            //Verificar o estado da conexao (fechada ou aberta)
            if(con.State == ConnectionState.Closed)
            {
                con.Open(); //Abre a conexao com o servidor de bd
            }
            return con;
        }

        public void Desconectar()
        {
            if(con.State == ConnectionState.Open)
            {
                con.Close();//Fecha a conexao com o servidor de bd
            }
        }
    }
}
