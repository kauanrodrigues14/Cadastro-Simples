using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploCRUD.BLL
{
    public class Amigo
    {
        //Atributo privado + Metodo de Acesso Publico --> PROPRIEDADE
        private int id; //Atributo (privado)
        //Metodo de acesso (publico)
        public int Id
        {
            //leitura "pegar"
            get { return id; }
            //gravacao
            set { id = value; }
        }

        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private string tel;
        public string Telefone
        {
            get { return tel; }
            set { tel = value; }
        }
    }
}
