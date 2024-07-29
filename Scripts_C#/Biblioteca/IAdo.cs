namespace Biblioteca;
public interface IAdo
{
    Cliente? ClientePorPass(string email, string pass);
    Task<Cliente?> ClientePorPassAsync(string email, string pass);
    void AltaCliente (Cliente cliente, string pasword);
    Task AltaClienteAsync (Cliente cliente, string pasword);
    List<Cliente> ObtenerCliente();
    Restaurant? RestaurantPorPass(string email, string pass);
    Task<Restaurant?> RestaurantPorPassAsync(string email, string pass);
    void AltaRestaurant(Restaurant nuevoPapa, string pasword);
}