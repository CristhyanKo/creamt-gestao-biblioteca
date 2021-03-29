using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoMais.Entities.Entities
{
    public class Autor : Base
    {
        public Pessoa.Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
    }
}
