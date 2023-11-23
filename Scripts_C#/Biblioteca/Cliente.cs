namespace Biblioteca;
public class Cliente
{
    public uint id {get ; set ;}
    public string email {get ; set ;}
    public string cliente {get ; set ;}
    public string apellido {get ; set ;}
    public string pasword {get ; set ;}
    public Cliente(uint idCliente, string email, string cliente, string apellido, string pasword)
        {
            this.id = idCliente;
            this.email = email;
            this.cliente = cliente;
            this.apellido = apellido;
            this.pasword = pasword;
        }

    public Cliente(string email, string? cliente, string apellido)
    {
        this.email = email;
        this.cliente = cliente;
        this.apellido = apellido;
    }
}