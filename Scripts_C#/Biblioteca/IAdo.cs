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
    Task <List<Restaurant>> TodosRestaurants();
    Restaurant? RestaurantPorPass(string email, string pass);
    Task<Restaurant?> RestaurantPorPassAsync(string email, string pass);
    void AltaRestaurant(Restaurant nuevoPapa, string pasword);
    Task AltaRestauranteAsync(Restaurant restaurante);
    Task <List<Restaurant>> buscarRestaurant (string restaurante);

    //platos
    Task <List<Plato>> buscarPlato(string nombre);
    Task <List<Plato>> TodosPlatosAsync();
    void AltaPlato(Plato plato, ushort idRestaurant);
    Task AltaPlatoAsync(Plato plato);
    void DetallePlato(Plato plato);
    Task DetallePlatoAsync(Plato plato);
}