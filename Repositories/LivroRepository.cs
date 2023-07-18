using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_biblioteca.Models;

namespace api_biblioteca.Repositories
{
    public class LivroRepository
    {
        private static List<Livro> ListaLivros = new List<Livro>();

        public IEnumerable<Livro> GetAllLivros(){
            return ListaLivros.Where(l => !l.isAlugado);
        }

        public void Create(Livro livro){
            ListaLivros.Add(livro);
        }

        public void Alugar(int livroId){
            var livro = ListaLivros.Find(l => l.Id == livroId);
            if(livro != null){
                livro.isAlugado = true;
            }
        }

        public void Devolver(int livroId){
            var livro = ListaLivros.Find(l => l.Id == livroId);
            if(livro != null){
                livro.isAlugado = false;
            }
        }

    }
}