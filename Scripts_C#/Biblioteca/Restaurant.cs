namespace Biblioteca
{
    public class Restaurant
    {
        public UInt16 idRestaurant {get ; set ;}
        public string restaurante {get ; set ;}
        public string domicilio {get ; set ;}
        public string email {get ; set ;}
        public string pasword {get ; set ;}
        public Restaurant(string restaurante, string domicilio, string email,string pasword)
        {
            //this.id = idRestaurant;
            this.restaurante = restaurante;
            this.domicilio = domicilio;
            this.email = email;
            this.pasword = pasword;
        }

        //public Restaurant(string restaurante, string domicilio, string email)
        //{
        //    this.restaurante = restaurante;
        //    this.domicilio = domicilio;
        //    this.email = email;
        //}
        public Restaurant() { }
    }
}