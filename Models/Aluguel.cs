using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_biblioteca.Models
{
    public class Aluguel : Base<int>
    {
        public int LivroId { get; set; }
        public DateTime DataAluguel {get; set;}
        public DateTime? DataEntrega { get; set; }
        public Aluguel()
        {
        }
    }
}