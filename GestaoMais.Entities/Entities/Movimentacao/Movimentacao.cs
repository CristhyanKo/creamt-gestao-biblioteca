using System;

namespace GestaoMais.Entities.Entities.Movimentacao
{
    public class Movimentacao : Base
    {
        public Livro.Livro Livro { get; set; }
        public int LivroId { get; set; }
        public Pessoa.Pessoa Pessoa { get; set; }
        public int PessoaId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public bool EmprestimoLocal { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataLimiteDevolucao { get; set; }
        public DateTime DataDevolucao { get; set; }
        public MovimentacaoSituacao MovimentacaoSituacao { get; set; }
        public int MovimentacaoSituacaoId { get; set; }
    }
}
