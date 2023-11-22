namespace Biblioteca;
public interface IAdo
{
    Cliente? ClientePorPass(string email, string pass);
    void AltaCliente (Cliente cliente);
    List<Cliente> ObtenerCliente();
    Restaurant? RestaurantPorPass(string email, string pass);
}