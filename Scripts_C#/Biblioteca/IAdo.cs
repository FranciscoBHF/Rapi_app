namespace Biblioteca;
public interface IAdo
{
    //cliente
    void AltaCliente(Cliente cliente, string pasword);
    // Métodos asíncronos
    Task<List<Cliente>>TodosClientes();
    Task AltaClienteAsync(Cliente cliente);
    Task<List<Cliente>> ObtenerClientesAsync();
    Task <List<Cliente>> buscarCliente(string cliente);


    //Restaurante
    void Restaurante(Restaurant restaurant);
    Restaurant? RestaurantPorPass(string email, string pass);
    Task<Restaurant?> RestaurantPorPassAsync(string email, string pass);
    void AltaRestaurant(Restaurant nuevoPapa, string pasword);
    Task AltaRestaurantAsync(Restaurant restaurant, string pasword);
    // Metodo Asincronico
    Task AltaRestauranteAsync(Restaurant restaurant);
    Task <List<Restaurant>> buscarRestaurant (string restaurante);
    Task <List<Plato>> buscarPlato(string nombre);
    Task <List<Plato>> TodosPlatosAsync();
    void AltaPlato(Plato plato, Plato idRestaurant);
    Task AltaPlatoAsync(Plato plato, Plato idRestaurant);
    Task <List<Restaurant>> TodosRestaurants();
}