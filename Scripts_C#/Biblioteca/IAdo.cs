namespace Biblioteca;
public interface IAdo
{
    Cliente? ClientePorPass(string email, string pass);
    Restaurant? RestaurantPorPass(string email, string pass);
}