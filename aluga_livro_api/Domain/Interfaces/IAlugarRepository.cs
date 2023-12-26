using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAlugarRepository
    {
        public void Alugar(Guid livroId);
        public void Devolver(Guid livroId);
        public IEnumerable<Aluguel> GetAll();
        public Aluguel? GetAluguelByLivroId(Guid livroId);
        public IEnumerable<Aluguel> GetAlugueisByLivroIdByPeriodo(Guid livroId, DateTime dataInicial, DateTime dataFinal);
        public IEnumerable<Aluguel> GetAlugueisByPeriodo(DateTime dataInicial, DateTime dataFinal);
    }
}