namespace Biblioteca;
public interface IAdo
{
    Cliente? ClientePorPass(string email, string pass);
}