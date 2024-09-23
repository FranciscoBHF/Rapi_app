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


    #region Cliente

    private static readonly string _queryClientePassword
        = @"SELECT *
            FROM Cliente
            WHERE email = @email AND password = SHA2(@password, 256)
            LIMIT 1";

    private static readonly string _queryAltaCliente
        = "CALL AltaCliente(@email, @cliente, @apellido, @password)";

    private static readonly string _queryTodosClientes
        = "SELECT * FROM Cliente ORDER BY cliente ASC, apellido ASC";

    public void AltaCliente(Cliente cliente, string password)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@email", cliente.email);
        parametros.Add("@cliente", cliente.cliente);
        parametros.Add("@apellido", cliente.apellido);
        parametros.Add("@password", password);

        _conexion.Execute(_queryAltaCliente, parametros, commandType: CommandType.StoredProcedure);
    }

    public Cliente? ClientePorPassword(string email, string password)
    {
        var cliente = _conexion.QueryFirstOrDefault<Cliente>(_queryClientePassword,
                                                            new { email, password });
        return cliente;
    }

    public List<Cliente> ObtenerClientes()
        => _conexion.Query<Cliente>(_queryTodosClientes).ToList();

    // Métodos asíncronos

    private static readonly string _queryAltaPlato
        = "CALL AltaPlato(@Plato, @descripcion, @precio, @idRestaurant)";
    public async Task AltaPlatoAsync(Plato plato)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@Plato", plato.plato);
        parametros.Add("@descripcion", plato.descripcion);
        parametros.Add("@precio", plato.precio);
        parametros.Add("@idRestaurant", plato.idRestaurant);
        await _conexion.ExecuteAsync(_queryAltaPlato, parametros, commandType: CommandType.StoredProcedure);
    }

    public async Task<Cliente?> ClientePorPasswordAsync(string email, string password)
    {
        var cliente = await _conexion.QueryFirstOrDefaultAsync<Cliente>(_queryClientePassword,
                                                                        new { email, password });
        return cliente;
    }

    public async Task<List<Cliente>> ObtenerClientesAsync()
        => (await _conexion.QueryAsync<Cliente>(_queryTodosClientes)).ToList();

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
        from Plato p";

    private static readonly string _queryTodosRestaurants
    = @"select *
    from Restaurante";
    private static readonly string _querybuscarPlato
        = @"select *
        from Plato
        where plato like @plato
        or descripcion like @plato";

    private static readonly string _querybuscarRestaurant
        = @"select *
        from Restaurante
        where restaurante like @restaurante";

    public async Task<List<Plato>> TodosPlatos()
    {
        var platos = await _conexion.QueryAsync<Plato>(_queryTodosPlatos);
        return platos.ToList();
    }

    public async Task<List<Plato>> TodosPlatosAsync()
    => (await _conexion.QueryAsync<Plato>(_queryTodosPlatos)).ToList();

    // public async Task<List<Plato>> TodosPlatosAsync()
    // {
    //     var productos = _conexion.Query<Plato,Restaurant, Plato>
    //         (_queryTodosPlatos,
    //         (plato, Restaurant) =>
    //         {
    //             Plato.Restaurant = Restaurant;
    //             return plato;
    //         },
    //         splitOn: "idRestaurant")
    //         .ToList();
    //         var restaurant = plato;
    //         return plato;
    // }
    public async Task<List<Restaurant>> TodosRestaurants()
        => (await _conexion.QueryAsync<Restaurant>(_queryTodosRestaurants)).ToList();

    public async Task<List<Plato>> buscarPlato(string plato)
    {
        var platos = await _conexion.QueryAsync<Plato>(_querybuscarPlato, new { plato = $"%{plato}%" });
        return platos.ToList();
    }

    public async Task<List<Restaurant>> buscarRestaurant(string restaurante)
    {
        var restaurantes = await _conexion.QueryAsync<Restaurant>(_querybuscarRestaurant, new { restaurante = $"%{restaurante}%" });
        return restaurantes.ToList();
    }
    public Task AltaRestaurantAsync(Restaurant restaurant, string pasword)
    {
        throw new NotImplementedException();
    }

    public Cliente? ClientePorPass(string email, string pass)
    {
        throw new NotImplementedException();
    }
    public void Restaurante(Restaurant restaurant)
    {
        throw new NotImplementedException();
    }

    // public Task AltaRestaurantAsync(Restaurant restaurant, string pasword)
    // {
    //     throw new NotImplementedException();
    // }

    public Task AltaRestauranteAsync(Restaurant restaurant)
    {
        throw new NotImplementedException();
    }

    public Task<List<Plato>> buscarCliente(string cliente)
    {
        throw new NotImplementedException();
    }

    public Task<List<Cliente>> TodosClientes()
    {
        throw new NotImplementedException();
    }

    public void AltaPlato(Plato plato, Plato idRestaurant)
    {
        throw new NotImplementedException();
    }

    Task<List<Cliente>> IAdo.buscarCliente(string cliente)
    {
        throw new NotImplementedException();
    }

    public Task AltaClienteAsync(Cliente cliente)
    {
        DynamicParameters parametros = ParametrosParaAltaCliente(cliente);
        return _conexion.ExecuteAsync("altaCliente", parametros, commandType: CommandType.StoredProcedure);
    }
    private static DynamicParameters ParametrosParaAltaCliente(Cliente cliente)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unIdCliente", direction: ParameterDirection.Output);
        parametros.Add("@unEmail", cliente.email);
        parametros.Add("@unCliente", cliente.cliente);
        parametros.Add("@unApellido", cliente.apellido);
        parametros.Add("@unPasword", cliente.pasword);
        return parametros;
    }

    public void AltaPlato(Plato plato)
    {
        throw new NotImplementedException();
    }
    #endregion
}
