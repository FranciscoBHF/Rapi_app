﻿using Biblioteca;
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

    private static readonly string _queryAltaPlato
    = "CALL AltaPlato(@idRestaurant, @plato, @descripcion, @precio, @disponible )";


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
    public void DetalleCliente(int idCliente)
    {
        // using var multi = await _conexion.QueryMultipleAsync(_queryDetalleCliente, new { unidCliente = idCliente });
        // var cliente = await multi.ReadSingleOrDefaultAsync<Cliente>();

        // return cliente;
    }

    public Cliente? ClientePorPassword(string email, string password)
    {
        var cliente = _conexion.QueryFirstOrDefault<Cliente>(_queryClientePassword,
                                                            new { email, password });
        return cliente;
    }
    public Task AltaClienteAsync(Cliente cliente)
    {
        DynamicParameters parametros = ParametrosParaAltaCliente(cliente);
        return _conexion.ExecuteAsync("altaCliente", parametros, commandType: CommandType.StoredProcedure);
    }

    public List<Cliente> ObtenerClientes()
        => _conexion.Query<Cliente>(_queryTodosClientes).ToList();
    public async Task<Cliente> DetalleClienteAsync(int idCliente)
    {
        using var multi = await _conexion.QueryMultipleAsync(_queryDetalleCliente, new { idCliente });
        var cliente = await multi.ReadSingleOrDefaultAsync<Cliente>();
        return cliente;
    }


    //------------------------------
    // Métodos asíncronos
    //------------------------------

    public async Task<Cliente?> ClientePorPasswordAsync(string email, string password)
    {
        var cliente = await _conexion.QueryFirstOrDefaultAsync<Cliente>(_queryClientePassword,
                                                                        new { email, password });
        return cliente;
    }

    public async Task<List<Cliente>> ObtenerClientesAsync()
        => (await _conexion.QueryAsync<Cliente>(_queryTodosClientes)).ToList();

    public async Task<List<Cliente>> buscarCliente(string cliente)
    {
        var clientes = await _conexion.QueryAsync<Cliente>(_querybuscarCliente, new { cliente = $"%{cliente}%" });
        return clientes.ToList();
    }

    //-----------------------
    //plato
    //-----------------------

    #endregion

    #region Plato (Implementación)
    private static readonly string _queryTodosPlatos
        = @"select * from Plato p";

    private static readonly string _queryDetallePlato
    = @"SELECT p.id, p.plato, p.descripcion, p.precio, p.idRestaurant, p.disponible
        FROM Plato p
        WHERE p.id = @unidPlato;

        SELECT r.idRestaurant, r.restaurante, r.domicilio, r.email, r.pasword
        FROM Restaurante r
        WHERE r.idRestaurant = (SELECT idRestaurant FROM Plato WHERE id = @unidPlato);";
    private static readonly string _queryDetalleCliente
    = @"SELECT  c.idCliente,c.cliente,c.apellido,c.email,c.pasword
        FROM Cliente c
        WHERE c.idCliente = @idCliente";
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
    private static readonly string _querybuscarCliente
    = @"select *
        from Cliente
        where cliente like @cliente
        or apellido like @cliente
        or email like @cliente";

    #endregion
    public void AltaPlato(Plato plato, UInt16 idRestaurant)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@idRestaurant", idRestaurant);
        parametros.Add("@plato", plato.plato);
        parametros.Add("@descripcion", plato.descripcion);
        parametros.Add("@precio", plato.precio);
        parametros.Add("@disponible", plato.disponible);

        _conexion.Execute(_queryAltaPlato, parametros, commandType: CommandType.StoredProcedure);
    }
    public async Task<List<Plato>> TodosPlatos()
    {
        var platos = await _conexion.QueryAsync<Plato>(_queryTodosPlatos);
        return platos.ToList();
    }

    public async Task<List<Restaurant>> TodosRestaurants()
        => (await _conexion.QueryAsync<Restaurant>(_queryTodosRestaurants)).ToList();

    public async Task<List<Restaurant>> buscarRestaurant(string restaurante)
    {
        var restaurantes = await _conexion.QueryAsync<Restaurant>(_querybuscarRestaurant, new { restaurante = $"%{restaurante}%" });
        return restaurantes.ToList();
    }

    private static DynamicParameters ParametrosParaAltaRestaurante(Restaurant restaurant)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unIdRestaurante", direction: ParameterDirection.Output);
        parametros.Add("@unEmail", restaurant.email);
        parametros.Add("@unRestaurante", restaurant.restaurante);
        parametros.Add("@unDomicilio", restaurant.domicilio);
        parametros.Add("@unPasword", restaurant.pasword);
        return parametros;
    }
    public Task<List<Cliente>> TodosClientes()
    {
        throw new NotImplementedException();
    }
    public Task AltaPlatoAsync(Plato plato)
    {
        DynamicParameters parametros = ParametrosParaAltaPlato(plato);
        return _conexion.ExecuteAsync("altaPlato", parametros, commandType: CommandType.StoredProcedure);
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
    public void DetallePlato(int idPlato)
    {
        throw new NotImplementedException();
    }
    private static DynamicParameters ParametrosParaAltaPlato(Plato plato)
    {
        var parametros = new DynamicParameters();
        parametros.Add("@unidPlato", direction: ParameterDirection.Output);
        parametros.Add("@unplato", plato.plato);
        parametros.Add("@undescripcionp", plato.descripcion);
        parametros.Add("@unprecio", plato.precio);
        parametros.Add("@undisponible", plato.disponible);
        parametros.Add("@unidRestaurant", plato.idRestaurant);
        return parametros;
    }

    //------------------------------
    // Métodos asíncronos
    //------------------------------

    public async Task<List<Plato>> TodosPlatosAsync()
    {
        var platos = await _conexion.QueryAsync<Plato>(_queryTodosPlatos);
        return platos.ToList();
    }

    public async Task<List<Plato>> buscarPlato(string plato)
    {
        var platos = await _conexion.QueryAsync<Plato>(_querybuscarPlato, new { plato = $"%{plato}%" });
        return platos.ToList();
    }
    public async Task<Plato> DetallePlatoAsync(int idPlato)
    {
        using var multi = await _conexion.QueryMultipleAsync(_queryDetallePlato, new { unidPlato = idPlato });

        var plato = await multi.ReadSingleOrDefaultAsync<Plato>();
        var restaurant = await multi.ReadSingleOrDefaultAsync<Restaurant>();

        if (plato != null)
        {
            plato.Restaurant = restaurant;
        }

        return plato;
    }

    //-----------------------------
    //Restaurante
    //-----------------------------

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

    public Restaurant? ClientePorPass(string email, string pasword)
            => _conexion.QueryFirstOrDefault<Restaurant>(_queryRestoPass, new { unEmail = email, unPass = pasword });

    public void Restaurante(Restaurant restaurant)
    {
        throw new NotImplementedException();
    }

    //------------------------------
    // Métodos asíncronos
    //------------------------------
    public Task AltaRestaurantAsync(Restaurant restaurant, string pasword)
    {
        throw new NotImplementedException();
    }

    // public async Task<List<Restaurant>> TodosRestaurants()
    //     => (await _conexion.QueryAsync<Restaurant>(_queryTodosRestaurants)).ToList();
    // public async Task<List<Restaurant>> buscarRestaurant(string restaurante)
    // {
    //     var restaurantes = await _conexion.QueryAsync<Restaurant>(_querybuscarRestaurant, new { restaurante = $"%{restaurante}%" });
    //     return restaurantes.ToList();
    // }
    public async Task<Restaurant?> RestaurantPorPassAsync(string email, string pasword)
    {
        var restaurant = await _conexion.QueryFirstOrDefaultAsync<Restaurant>(_queryRestoPass,
                                                                            new { unemail = email, unpasword = pasword });
        return restaurant;
    }

    public Task AltaRestauranteAsync(Restaurant restaurant)
    {
        DynamicParameters parametros = ParametrosParaAltaRestaurante(restaurant);
        return _conexion.ExecuteAsync("altaRestaurante", parametros, commandType: CommandType.StoredProcedure);
    }

    Cliente? IAdo.ClientePorPass(string email, string pass)
    {
        throw new NotImplementedException();
    }

    public Task AltaClienteAsync(int idCliente)
    {
        throw new NotImplementedException();
    }
    // private static DynamicParameters ParametrosParaAltaRestaurante(Restaurant restaurant)
    // {
    //     var parametros = new DynamicParameters();
    //     parametros.Add("@unIdRestaurante", direction: ParameterDirection.Output);
    //     parametros.Add("@unEmail", restaurant.email);
    //     parametros.Add("@unRestaurante", restaurant.restaurante);
    //     parametros.Add("@unDomicilio", restaurant.domicilio);
    //     parametros.Add("@unPasword", restaurant.pasword);
    //     return parametros;
    // }
    #endregion
}
