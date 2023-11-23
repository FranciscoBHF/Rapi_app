using Biblioteca;

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
    [Fact]
    public void AltaRestaurant()
    {
    string restaurante = "El PAPA";
    string domicilio = "Baticano 356";
    string email = "Jesus@hotmail.com";
    string pasword = "Plegarias";
    
    var restaurante1 = Ado.RestaurantPorPass(email, pasword);

    Assert.Null(restaurante1);

    var nuevoPapa = new Restaurant(restaurante,domicilio,email);

    Ado.AltaRestaurant (nuevoPapa, pasword);

    var mismoRestaurant = Ado.RestaurantPorPass (email, pasword);

    Assert.NotNull(mismoRestaurant);
    Assert.Equal(restaurante, mismoRestaurant.restaurante);
    Assert.Equal(domicilio, mismoRestaurant.domicilio);
    }
}
