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
        var prueba = Ado.ClientePorPass(email, pasword);

        Assert.NotNull(prueba);
        Assert.Equal(cliente, prueba.cliente);
        Assert.Equal(email, prueba.email);
    }
}
