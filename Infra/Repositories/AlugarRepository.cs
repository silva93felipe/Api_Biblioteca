using Infra.Context;
using Domain.Models;
using Domain.Interfaces;

namespace Infra.Repositories
{
    public class AlugarRepository //: IAlugarRepository
    {
        public void Alugar(Guid livroId){
            var aluguel = new Aluguel(livroId);
            BibliotecaContext.Alugueis.Add(aluguel);  
        }

        public void Devolver(Guid livroId){
            var aluguel = BibliotecaContext.Alugueis.Find(l => l.LivroId == livroId && l.Ativo);

            aluguel?.Entregar();
            
        }
        public IEnumerable<Aluguel> GetAll(){
            return BibliotecaContext.Alugueis.Where( a => a.DataEntrega == null && a.Ativo);
        }

        public Aluguel? GetAluguelByLivroId(Guid livroId){
            return BibliotecaContext.Alugueis.Find( a => a.LivroId == livroId && !a.DataEntrega.HasValue && a.Ativo);
        }

        public IEnumerable<Aluguel> GetAlugueisByLivroIdByPeriodo(Guid livroId, DateTime dataInicial, DateTime dataFinal){
            return BibliotecaContext.Alugueis.Where( a => a.LivroId == livroId && a.DataInicial.Date >= dataInicial.Date && a.DataInicial.Date <= dataFinal.Date);
        }


        public IEnumerable<Aluguel> GetAlugueisByPeriodo(DateTime dataInicial, DateTime dataFinal){
            return BibliotecaContext.Alugueis.Where( a => a.DataInicial.Date >= dataInicial.Date && a.DataInicial.Date <= dataFinal.Date);
        }
    }
}