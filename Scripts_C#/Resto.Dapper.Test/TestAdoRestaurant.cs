using Resto.Dapper;
using Biblioteca;
using System.ComponentModel.Design;

namespace Resto.Dapper.Test;
public class TestAdoRestaurant : TestAdo
{
    [Theory]
    [InlineData("Las Palmitas", "LasPalmitas@gmail.com","pe")]
    [InlineData("La Rioja","LaRioja@gmail.com","Che")]
    public void TraerResto(string restaurante,string email, string pasword)
    {
        var prueba = Ado.RestaurantPorPass(email,pasword);

        Assert.NotNull(prueba);
        Assert.Equal(restaurante, prueba.restaurante);
        Assert.Equal(email, prueba.email);
    }
}
