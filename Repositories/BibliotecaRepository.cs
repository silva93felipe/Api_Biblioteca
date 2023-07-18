using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_biblioteca.Context;
using api_biblioteca.Models;

namespace api_biblioteca.Repositories
{
    public class BibliotecaRepository
    {
        private readonly BibliotecaContext _bibliotecaContext;

        public Biblioteca GetAll(){
            return BibliotecaContext.biblioteca;
        }

        public void Create(Biblioteca biblioteca){
            BibliotecaContext.biblioteca.Descricao = biblioteca.Descricao;
            BibliotecaContext.biblioteca.Id = biblioteca.Id;
            
        }
    }
}