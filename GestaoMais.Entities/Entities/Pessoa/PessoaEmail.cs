namespace GestaoMais.Entities.Entities.Pessoa
{
    public class PessoaEmail : Base
    {
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public string Email { get; set; }
        public bool Principal { get; set; }
    }
}
