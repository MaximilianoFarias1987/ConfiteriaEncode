namespace Entidades
{
    public class Usuario : Persona
    {
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public int IdRol { get; set; }
    }
}
