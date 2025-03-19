using System;
using System.Collections.Generic;

namespace MVCCRUD.Models
{
    public partial class Articulo
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public int? Cantidad { get; set; }
        public DateTime? FechaIngreso { get; set; }
    }
}
