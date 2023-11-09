namespace Resto.Dapper.Test;

public class TestAdoCliente
{
    [Theory]
    [InlineData("Robert@gmail", "Rupert", "Pelele")]
    [InlineData("Chema@gmail.com", "Chems", "Palete")]
    public void TraerCliente(string email, string cliente, string password)
    {
        var cliente = Ado.ClientePorPass()
        Assert.NotNull(cliente);
        Assert.Equals()
    }
}