namespace Resto.MVC.Controllers.Modal;
public class ClienteModal
{
    public string? Email { get; set; }
    public string? Cliente { get; set; }
    public string? Apellido { get; set; }
    public string? password { get; set; }
    public ClienteModal() {}
    public ClienteModal(string email, string cliente, string apellido)
    {
        Email = email;
        Cliente = cliente;
        Apellido = apellido;
    }
}
