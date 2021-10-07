using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.DTOs
{
    public class UsuariosDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDoc { get; set; }
        public string Documento { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }
    }
}
