using Resto.Dapper;
using Biblioteca;

namespace Resto.Dapper.Test;

public class TestAdoCliente : TestAdo
{
    [Theory]
    [InlineData("Robert@gmail", "Rupert", "Pelele")]
    [InlineData("Chema@gmail.com", "Chems", "Palete")]
    public void TraerCliente(string email, string cliente, string password)
    {
        var prueba = Ado.ClientePorPass(email, password);

        Assert.NotNull(cliente);
        Assert.Equal(cliente, prueba.cliente);
        Assert.Equal(email, prueba.email);
    }
}
