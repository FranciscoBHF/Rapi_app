namespace Biblioteca;
public interface IAdo
{
    Restaurant? RestaurantPorPass(string email, string pass);
    Task<Restaurant?> RestaurantPorPassAsync(string email, string pass);
    void AltaRestaurant(Restaurant nuevoPapa, string pasword);
    Task AltaRestaurantAsync(Restaurant restaurant, string pasword);
    Task <List<Plato>> buscarPlato(string nombre);
    Task <List<Plato>> TodosPlatosAsync();

    //cliente
    void AltaCliente(Cliente cliente, string pasword);
    Cliente? ClientePorPass(string email, string pass);
    Task<Cliente?> ClientePorPassAsync(string email, string pass);    List<Cliente> ObtenerCliente();
    // Métodos asíncronos
    Task AltaClienteAsync(Cliente cliente, string pasword);
    Task<List<Cliente>> ObtenerClientesAsync();
}