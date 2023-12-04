namespace api_biblioteca.Models
{
    public class Livro : Base<Guid>
    {
        public string Titulo { get; private set; }
        public string Autor { get; private set; }
        public string AnoLancamento { get; private set; }
        public string Resumo {get; private set;}
        public bool IsAlugado {get; private set;}

        public Livro(string titulo, string autor, string anoLancamento, string resumo)
        {
            Titulo = titulo;
            Autor = autor;
            AnoLancamento = anoLancamento;
            IsAlugado = false;
            Resumo = resumo;
        }

        public void Alugar(){
            IsAlugado = true;
            UpdateAt = DateTime.Now;
        }

        public void Devolver(){
            IsAlugado = false;
            UpdateAt = DateTime.Now;
        }
    }
}