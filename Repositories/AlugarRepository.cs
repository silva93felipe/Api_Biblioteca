using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_biblioteca.Context;
using api_biblioteca.Models;

namespace api_biblioteca.Repositories
{
    public class AlugarRepository
    {
         public void Alugar(Aluguel aluguel){
            BibliotecaContext.Alugueis.Add(aluguel);  
        }
        public void Devolver(int livroId, DateTime dataEntrega){
            var livro = BibliotecaContext.Alugueis.Find(l => l.LivroId == livroId && l.Ativo);
            if(livro != null){
                livro.Ativo = false;
                livro.DataEntrega = dataEntrega;
            }
        }
        public IEnumerable<Aluguel> GetAll(){
            return BibliotecaContext.Alugueis.Where( a => a.DataEntrega == null && !a.Ativo);
        }

        public IEnumerable<Aluguel> GetAlugueisByLivroId(int livroId){
            return BibliotecaContext.Alugueis.Where( a => a.LivroId == livroId);
        }
    }
}