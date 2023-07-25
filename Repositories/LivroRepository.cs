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
            return BibliotecaContext.biblioteca.Livros.Where(l => !l.IsAlugado);
        }

        public void Create(Livro livro){
            BibliotecaContext.biblioteca.Livros.Add(livro);
        }

        public void Alugar(int livroId, DateTime dataAluguel){
            var livro = BibliotecaContext.biblioteca.Livros.Find(l => l.Id == livroId);

            if(livro != null){
                livro.IsAlugado = true;
                var aluguel = new Aluguel();
                aluguel.LivroId = livro.Id;
                aluguel.DataAluguel = dataAluguel;
                BibliotecaContext.Alugueis.Add(aluguel);
            }
        }

        public void Devolver(int livroId, DateTime dataEntrega){
            var livro = BibliotecaContext.biblioteca.Livros.Find(l => l.Id == livroId);
            
            if(livro != null){
                var aluguel = BibliotecaContext.Alugueis.Find( l => l.Id == livro.Id && l.Ativo);
                
                if(aluguel != null){
                    aluguel.Ativo = false;
                    aluguel.DataEntrega = dataEntrega;

                }

                livro.IsAlugado = false;
            }
        }

    }
}