using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Context;
using Domain.Models;

namespace Infra.Repositories
{
    public class LivroRepository
    {
        private readonly AlugarRepository _alugarRepository;

        public LivroRepository()
        {
            _alugarRepository = new AlugarRepository();
        }
        public IEnumerable<Livro> GetAllLivros(){
            return BibliotecaContext.Livros.Where (l => !l.IsAlugado).ToList();
        }

        public void Create(Livro livro){
            BibliotecaContext.Livros.Add(livro);
        }

        public void Alugar(Guid livroId){
            var livro = BibliotecaContext.Livros.Find(l => l.Id == livroId);

            if(livro != null){
                livro.Alugar();

                _alugarRepository.Alugar(livroId);
            }
        }

        public void Devolver(Guid livroId){
            var livro = BibliotecaContext.Livros.Find(l => l.Id == livroId);
            
            if(livro != null){
                var aluguel = _alugarRepository.GetAluguelByLivroId(livro.Id);
                
                aluguel?.Entregar();
                livro.Devolver();
            }
        }
    }
}