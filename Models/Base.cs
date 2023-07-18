using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api_biblioteca.Models
{
    public class Base<T>
    {
        public T Id { get; set; }
        public bool Ativo { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }

        public Base(){
            Ativo = true;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}