using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_biblioteca.Models
{
    public class Livro : Base<int>
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string AnoLancamento { get; set; }
        public string UrlImage { get; set; }
        public bool IsAlugado {get; set;}

        public Livro()
        {
            IsAlugado = false;
        }
    }
}