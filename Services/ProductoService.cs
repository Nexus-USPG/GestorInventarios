using System;
using System.Collections.Generic;
using GestorInventarios.Models;
using System.Linq;

namespace GestorInventarios.Services
{
    public static class ProductoService
    {
        private static List<Producto> listaProductos = new List<Producto>();
        private static int nextId = 1;

        public static List<Producto> ObtenerProductos()
        {
            return listaProductos;
        }

        public static void CrearProducto(string nombre, Categoria categoria, decimal precio, int cantidad)
        {
            if (categoria == null) throw new Exception("El producto debe estar asociado obligatoriamente a una categoría.");
            if (precio <= 0) throw new Exception("El precio unitario debe ser mayor que cero.");
            if (cantidad < 0) throw new Exception("La cantidad inicial no puede ser negativa.");

            var nuevoProducto = new Producto { Id = nextId++, Nombre = nombre, Categoria = categoria, PrecioUnitario = precio, CantidadInicial = cantidad };
            listaProductos.Add(nuevoProducto);
        }

        public static void ActualizarProducto(int id, string nombre, Categoria categoria, decimal precio)
        {
            var producto = listaProductos.FirstOrDefault(p => p.Id == id);
            if (producto == null) throw new Exception("Producto no encontrado.");
            if (categoria == null) throw new Exception("Debe asociarse una categoría.");
            if (precio <= 0) throw new Exception("El precio debe ser mayor que cero.");

            producto.Nombre = nombre;
            producto.Categoria = categoria;
            producto.PrecioUnitario = precio;
        }

        public static void EliminarProducto(int id)
        {
            var producto = listaProductos.FirstOrDefault(p => p.Id == id);
            if (producto == null) throw new Exception("Producto no encontrado.");
            listaProductos.Remove(producto);
        }

        static ProductoService()
        {
            // Datos de inicialización
            Categoria electronica = CategoriaService.ObtenerCategorias().FirstOrDefault(c => c.Nombre == "Electrónica");
            Categoria alimentos = CategoriaService.ObtenerCategorias().FirstOrDefault(c => c.Nombre == "Alimentos");

            if (electronica != null) CrearProducto("Televisor QLED", electronica, 1200.50m, 5);
            if (alimentos != null) CrearProducto("Manzanas x Kg", alimentos, 1.99m, 150);
        }
    }
}