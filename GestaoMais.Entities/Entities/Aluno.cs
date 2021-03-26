namespace GestaoMais.Entities.Entities
{
    public class Aluno : Base
    {
        public int Matricula { get; set; }
        public Pessoa.Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
    }
}
