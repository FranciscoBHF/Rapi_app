using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Restaurant
    {
        public int id {get ; set ;}
        public string restaurant {get ; set ;}
        public string domicilio {get ; set ;}
        public char password {get ; set ;}
        public string email {get ; set ;}
        public Restaurant(int id, string restaurant, string domicilio, char password, string email)
        {
            this.id = id;
            this.restaurant = restaurant;
            this.domicilio = domicilio;
            this.password = password;
            this.email = email;
        }
    }
}