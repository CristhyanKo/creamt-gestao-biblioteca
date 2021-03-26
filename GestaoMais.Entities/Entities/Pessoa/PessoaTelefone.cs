using GestaoMais.Entities.Entities.Sistema;

namespace GestaoMais.Entities.Entities.Pessoa
{
    public class PessoaTelefone: Base
    {
        public Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public TipoTelefone TipoTelefone { get; set; }
        public int TipoTelefoneId { get; set; }
        public int Ddd { get; set; }
        public string Numero { get; set; }
        public bool Principal { get; set; }
    }
}
