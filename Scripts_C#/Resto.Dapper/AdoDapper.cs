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
        where email = @unEmail
        and pasword = SHA2(@unPass, 256)
        LIMIT 1";
    private static readonly string _queryAltaCliente
    = @"CALL RegistrarCliente1(@email, @cliente, @apellido, @pasword)";
    public void AltaCliente(Cliente cliente, string pasword)
    => _conexion.Execute(
            _queryAltaCliente,
            new
            {
                email = cliente.email,
                cliente = cliente.cliente,
                apellido = cliente.apellido,
                pasword = pasword
            }
        );
    public Cliente? ClientePorPass(string email, string pasword)
        => _conexion.QueryFirstOrDefault<Cliente>(_queryClientePass, new { unEmail = email, unPass = pasword });

    #endregion

    #region Restaurant ("Terminado")
    private static readonly string _queryRestoPass
        = @"select *
        from Restaurante
        where email = @unEmail
        and pasword = SHA2(@unPass, 256)
        LIMIT 1";
    private static readonly string _queryAltaResto
    = @"CALL AltaRestaurante(@restaurante, @domicilio, @pasword, @email)";
    public void AltaRestaurant(Restaurant restaurante, string pasword)
    => _conexion.Execute(
            _queryAltaResto,
            new
            {
                restaurante = restaurante.restaurante,
                domicilio = restaurante.domicilio,
                email = restaurante.email,
                pasword = pasword
            }
        );
    public Restaurant? RestaurantPorPass(string email, string pasword)
        => _conexion.QueryFirstOrDefault<Restaurant>(_queryRestoPass, new { unEmail = email, unPass = pasword });

    public void AltaCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public List<Cliente> ObtenerCliente()
    {
        throw new NotImplementedException();
    }
    #endregion

}
