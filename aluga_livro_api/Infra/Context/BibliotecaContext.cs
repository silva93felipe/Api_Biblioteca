using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Infra.Context
{
    public class BibliotecaContext
    {
        public static List<Aluguel> Alugueis = new List<Aluguel>();
        public static List<Livro> Livros = new List<Livro>();
    }
}