using Resto.Dapper;
using Biblioteca;

namespace Resto.Dapper.Test;
public class TestAdoRestaurant : TestAdo
{
   [Theory]
   [InlineData("LasPalmitas@gmail.com", "Las palmitas", "pe")]
   [InlineData("LaRioja@gmail.com", "La rioja", "Che")]
   public void TraerResto(string email, string restaurant, string pasword)
   {
       var prueba = Ado.RestaurantPorPass(email, pasword);


       Assert.NotNull(prueba);
       Assert.Equal(restaurant, prueba.restaurant);
       Assert.Equal(email, prueba.email);
   }
}
