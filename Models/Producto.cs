using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorInventarios.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Categoria Categoria { get; set; }


        public string NombreCategoria => Categoria?.Nombre;

        public decimal PrecioUnitario { get; set; }
        public int CantidadInicial { get; set; }
        public int StockActual => CantidadInicial;
    }
}
