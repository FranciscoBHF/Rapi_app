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
    public async Task<Cliente?> ClientePorPassAsync(string email, string pass)
    {
        var cliente = await _conexion.QueryFirstOrDefaultAsync<Cliente>(_queryClientePass,
                                                                        new { unEmail = email, unPass = pass });
        return cliente;
    }
    public async Task AltaClienteAsync(Cliente cliente, string pasword)
    {
        await _conexion.QueryAsync(_queryAltaCliente, new
        {
            Unemail = cliente.email,
            Uncliente = cliente.cliente,
            Unapellido = cliente.apellido,
            Unpasword = pasword
        });
    }
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

    public async Task<Restaurant?> RestaurantPorPassAsync(string email, string pasword)
    {
        var restaurant = await _conexion.QueryFirstOrDefaultAsync<Restaurant>(_queryRestoPass,
                                                                            new { unemail = email, unpasword = pasword });
        return restaurant;
    }

    public void AltaCliente(Cliente cliente)
    {
        throw new NotImplementedException();
    }

    public List<Cliente> ObtenerCliente()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Plato (Implementación)
    private static readonly string _queryTodosPlatos
        = @"select *
        from Plato";

    private static readonly string _queryBuscarPlato
        = @"select *
            from Plato
            where nombre like @nombre";

    // public async Task<List<Plato>> TodosPlatos()
    // {
    //     var platos = await _conexion.QueryAsync<Plato>(_queryTodosPlatos);
    //     return platos.ToList();
    // }

    public async Task<List<Plato>> TodosPlatos()
        => (await _conexion.QueryAsync<Plato>(_queryTodosPlatos)).ToList();

    public async Task<List<Plato>> buscarPlato(string nombre)
    {
        var platos = await _conexion.QueryAsync<Plato>(_queryBuscarPlato, new { nombre = $"%{nombre}%" });
        return platos.ToList();
    }

    public Task AltaRestaurantAsync(Restaurant restaurant, string pasword)
    {
        throw new NotImplementedException();
    }
    #endregion
}
