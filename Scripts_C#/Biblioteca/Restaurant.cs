namespace Biblioteca
{
    public class Restaurant
    {
        public uint id {get ; set ;}
        public string restaurante {get ; set ;}
        public string domicilio {get ; set ;}
        public string email {get ; set ;}
        public char pasword {get ; set ;}
        public Restaurant(uint idRestaurant, string restaurante, string domicilio, string email,char pasword)
        {
            this.id = idRestaurant;
            this.restaurante = restaurante;
            this.domicilio = domicilio;
            this.email = email;
            this.pasword = pasword;
        }
    }
}