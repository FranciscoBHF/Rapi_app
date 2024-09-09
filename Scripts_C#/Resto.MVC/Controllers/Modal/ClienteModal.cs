namespace Resto.MVC.Controllers.Modal;
public class ClienteModal
{
    public string? Email { get; set; }
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public string? password { get; set; }
    public ClienteModal() {}
    public ClienteModal(string email, string nombre, string apellido)
    {
        Email = email;
        Nombre = nombre;
        Apellido = apellido;
    }
}
