namespace Biblioteca;
public interface IAdo
{
    //cliente
    void AltaCliente(Cliente cliente, string pasword);
    void DetalleCliente(int idCliente);

    // Métodos asíncronos
    Task AltaClienteAsync(Cliente cliente);
    Task<List<Cliente>>TodosClientes();
    Task<List<Cliente>> ObtenerClientesAsync();
    Task <List<Cliente>> buscarCliente(string cliente);
    Task<Cliente>DetalleClienteAsync(int idCliente);
    //platos
    void AltaPlato(Plato plato, ushort idRestaurant);
    void DetallePlato(int idPlato);

    // Métodos asíncronos
    Task AltaPlatoAsync(Plato plato);
    Task <List<Plato>> TodosPlatosAsync();
    Task <List<Plato>> buscarPlato(string nombre);
    Task <Plato> DetallePlatoAsync(int idPlato);

    //Restaurante
    void AltaRestaurant(Restaurant nuevoPapa, string pasword);
    void Restaurante(Restaurant restaurant);
    Restaurant? RestaurantPorPass(string email, string pass);
    Cliente? ClientePorPass (string email, string pass);
    void DetalleRestaurant(int idRestaurant);

    // Métodos asíncronos
    Task AltaRestauranteAsync(Restaurant restaurante);
    Task <List<Restaurant>> TodosRestaurants();
    Task <List<Restaurant>> buscarRestaurant (string restaurante);
    Task<Restaurant?> RestaurantPorPassAsync(string email, string pass);
    Task<Restaurant?> DetalleRestaurantAsync (int idRestaurant);
}