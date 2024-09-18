namespace Biblioteca;
public interface IAdo
{
    //cliente
    void AltaCliente(Cliente cliente, string pasword);
    Cliente? ClientePorPass(string email, string pass);
    Task<Cliente?> ClientePorPassAsync(string email, string pass);    List<Cliente> ObtenerCliente();
    // Métodos asíncronos
    Task AltaClienteAsync(Cliente cliente, string pasword);
    Task<List<Cliente>> ObtenerClientesAsync();

    //Restaurante
    void Restaurante(Restaurant restaurant);
    Restaurant? RestaurantPorPass(string email, string pass);
    Task<Restaurant?> RestaurantPorPassAsync(string email, string pass);
    void AltaRestaurant(Restaurant nuevoPapa, string pasword);
    Task AltaRestaurantAsync(Restaurant restaurant, string pasword);
    // Metodo Asincronico
    Task AltaRestauranteAsync(Restaurant restaurant);
    Task <List<Plato>> buscarPlato(string nombre);
    Task <List<Cliente>> buscarCliente(string cliente);
    Task <List<Plato>> TodosPlatosAsync();
    void AltaPlato(Plato plato, Plato idRestaurant);
    Task AltaPlatoAsync(Plato plato, Plato idRestaurant);
    Task <List<Restaurant>> TodosRestaurants();
    Task<List<Cliente>>TodosClientes();
    Task AltaClienteAsync(Cliente cliente);
}