using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_biblioteca.Models;

namespace api_biblioteca.Context
{
    public class BibliotecaContext
    {
        public static List<Aluguel> Alugueis = new List<Aluguel>();
        public static List<Livro> Livros = new List<Livro>();
    }
}