using System;
using System.Collections.Generic;
using GestorInventarios.Models;
using System.Linq;

namespace GestorInventarios.Services
{
    public static class CategoriaService
    {
        private static List<Categoria> listaCategorias = new List<Categoria>();
        private static int nextId = 1;

        public static List<Categoria> ObtenerCategorias()
        {
            return listaCategorias;
        }

        public static void CrearCategoria(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new Exception("El nombre no puede estar vacío.");
            var nuevaCategoria = new Categoria { Id = nextId++, Nombre = nombre };
            listaCategorias.Add(nuevaCategoria);
        }

        static CategoriaService()
        {
            CrearCategoria("Electrónica");
            CrearCategoria("Alimentos");
            CrearCategoria("Muebles");
        }
    }
}