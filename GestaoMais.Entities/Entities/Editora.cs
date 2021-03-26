namespace GestaoMais.Entities.Entities
{
    public class Editora : Base
    {
        public Pessoa.Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
    }
}
