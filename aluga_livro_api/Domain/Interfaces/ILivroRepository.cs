using Domain.Models;

namespace Domain.Interfaces
{
    public interface ILivroRepository
    {
        public IEnumerable<Livro> GetAllLivros();
        public void Create(Livro livro);
        public void Alugar(Guid livroId);
        public void Devolver(Guid livroId);
    }
}