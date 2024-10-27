namespace PessoaAPI.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string UF { get; set; }
        public string Cidade { get; set; }
    }
}
