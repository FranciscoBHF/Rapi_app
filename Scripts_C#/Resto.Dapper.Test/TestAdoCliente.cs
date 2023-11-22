using Resto.Dapper;
using Biblioteca;

namespace Resto.Dapper.Test;

public class TestAdoCliente : TestAdo
{
    [Theory]
    [InlineData("Robert@gmail.com", "Rupert", "Pelele")]
    [InlineData("Chema@gmail.com", "Chems", "Palete")]
    public void TraerCliente(string email, string cliente, string pasword)
    {
        //TODO: pensar en traer el cliente, sin su contraseña cargada (ni su modelo).
        var prueba = Ado.ClientePorPass(email, pasword);

        Assert.NotNull(prueba);
        Assert.Equal(cliente, prueba.cliente);
        Assert.Equal(email, prueba.email);
    }
    [Fact]
    public void AltaCliente()
    {
    uint idCliente = 4;
    string email = "Francisco@gmail.com";
    string cliente = "Francisco";
    string apellido = "Basualdo";
    string pasword = "Pituficulo";
    
    var cliente1 = Ado.ClientePorPass(email, pasword);

    Assert.Null(cliente);

    var nuevoBasualdo = new Cliente(email,cliente,apellido);
    }
}
