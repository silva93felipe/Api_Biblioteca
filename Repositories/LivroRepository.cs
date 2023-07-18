using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_biblioteca.Context;
using api_biblioteca.Models;

namespace api_biblioteca.Repositories
{
    public class LivroRepository
    {
        public IEnumerable<Livro> GetAllLivros(){
            return BibliotecaContext.biblioteca.Livros.Where(l => !l.isAlugado);
        }

        public void Create(Livro livro){
            BibliotecaContext.biblioteca.Livros.Add(livro);
        }

        public void Alugar(int livroId){
            var livro = BibliotecaContext.biblioteca.Livros.Find(l => l.Id == livroId);
            if(livro != null){
                livro.isAlugado = true;
            }
        }

        public void Devolver(int livroId){
            var livro = BibliotecaContext.biblioteca.Livros.Find(l => l.Id == livroId);
            if(livro != null){
                livro.isAlugado = false;
            }
        }

    }
}