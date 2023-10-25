using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Cliente
    {
        public int id {get ; set ;}
        public string email {get ; set ;}
        public string cliente {get ; set ;}
        public string apellido {get ; set ;}
        public string password {get ; set ;}
        public Cliente(int id, string email, string cliente, string apellido, string password)
            {
                this.id = id;
                this.email = email;
                this.cliente = cliente;
                this.apellido = apellido;
                this.password = password;
            }
    }
}