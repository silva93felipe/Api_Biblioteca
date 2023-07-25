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
        public Biblioteca GetAll(){
            return BibliotecaContext.biblioteca;
        }

        public void Create(Biblioteca biblioteca){
            Biblioteca bibliotecaNew = new Biblioteca();
            bibliotecaNew.Descricao = biblioteca.Descricao;
            bibliotecaNew.Id =  biblioteca.Id;
            BibliotecaContext.biblioteca = bibliotecaNew;
            
        }
    }
}