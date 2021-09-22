namespace Entidades
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdTipoDoc { get; set; }
        public string NumeroDoc { get; set; }
    }
}
