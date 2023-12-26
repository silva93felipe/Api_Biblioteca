namespace Domain.Models
{
    public class Aluguel : Base<int>
    {
        public Guid LivroId { get; private set; }
        public DateTime DataInicial {get; private set;}
        public DateTime? DataEntrega { get; private  set; }
        public Aluguel(Guid livroId)
        {
            LivroId = livroId;
            DataInicial = DateTime.Now;
        }

        public void Entregar(){
            Inativar();
            DataEntrega = DateTime.Now;
            UpdateAt = DateTime.Now;
        }
    }
}