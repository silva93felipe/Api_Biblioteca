namespace Domain.Models
{
    public abstract class Base<T>
    {
        public Guid Id { get; init; }
        public bool Ativo { get; private set; }
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; set; }

        public Base(){
            Id = Guid.NewGuid();
            Ativo = true;
            CreateAt = DateTime.Now;
            UpdateAt = DateTime.Now;
        }

        public virtual void Inativar(){
            Ativo = false;
            UpdateAt = DateTime.Now;
        }
    }
}