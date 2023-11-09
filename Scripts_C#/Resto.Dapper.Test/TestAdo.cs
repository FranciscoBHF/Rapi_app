using Resto.Dapper;
using Biblioteca;

namespace Super.Test;
public class TestAdo
{
    protected readonly IAdo Ado;
    private const string _cadena = "Server=localhost;Database=Supermercado;Uid=gerenteSuper;pwd=passGerente;Allow User Variables=True";
    public TestAdo() => Ado = new AdoDapper(_cadena);
    public TestAdo(string cadena) => Ado = new AdoDapper(cadena);
}
