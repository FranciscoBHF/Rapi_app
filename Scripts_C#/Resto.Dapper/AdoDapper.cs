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
    private static readonly string _queryClientePass
        = @"select *
        from Cliente
        where email = @unemail
        and pass = SHA2(@unpass, 256)
        LIMIT 1";
    public Cliente? ClientePorPass(string email, string pass)
        => _conexion.QueryFirstOrDefault<Cliente>(_queryClientePass, new {unEmail = email, unPass = pass});
    #endregion
}
