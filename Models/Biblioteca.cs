using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_biblioteca.Models
{
    public class Biblioteca : Base<int>
    {
        public string Descricao { get; set; }
        public List<Livro> Livros { get; set; }

        public Biblioteca()
        {
            Livros = new List<Livro>();
        }
    }
}