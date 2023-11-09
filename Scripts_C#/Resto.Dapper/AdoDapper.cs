using Biblioteca;
using MySqlConnector;
using System.Data;
using Dapper;

namespace Resto.Dapper;
public class AdoDapper : IAdo
{
    private readonly IDbConnection _conexion;
    public AdoDapper(IDbConnection conexion) => _conexion = conexion;
    public AdoDapper(string cadena)
        => _conexion = new MySqlConnection(cadena);
    
    #region Cliente ("Terminado")
    private static readonly string _queryClientePass
        = @"select *
        from Cliente
        where email = @unemail
        and pass = SHA2(@unpass, 256)
        LIMIT 1";
        private static readonly string _queryAltaCliente
        = @"INSERT INTO Cliente VALUES (@email, @cliente, @apellido, @password)";
        public void AltaCliente(Cliente cliente, string password)
        => _conexion.Execute(
                _queryAltaCliente,
                new
                {
                    email = cliente.email,
                    cliente = cliente.cliente,
                    apellido = cliente.apellido,
                    password = password
                }
            );
    public Cliente? ClientePorPass(string email, string pass)
        => _conexion.QueryFirstOrDefault<Cliente>(_queryClientePass, new {unEmail = email, unPass = pass});

    #endregion

    #region Restaurant ("Terminado")
    private static readonly string _queryRestoPass
        = @"select *
        from restaurant
        where email = @unemail
        and pass = SHA2(@unpass, 256)
        LIMIT 1";
        private static readonly string _queryAltaResto
        = @"INSERT INTO restaurant VALUES (@email, @restaurant, @domicilio, @password)";
        public void AltaRestaurant(Restaurant restaurant, string password)
        => _conexion.Execute(
                _queryAltaCliente,
                new
                {
                    email = restaurant.email,
                    restaurant = restaurant.restaurant,
                    domicilio = restaurant.domicilio,
                    password = password
                }
            );
    public Cliente? _queryAltaPorResto(string email, string pass)
        => _conexion.QueryFirstOrDefault<Cliente>(_queryRestoPass, new {unEmail = email, unPass = pass});

    #endregion

}
