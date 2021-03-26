using GestaoMais.Entities.Entities.Sistema;
using System;

namespace GestaoMais.Entities.Entities.Pessoa
{
    public class Pessoa : Base
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public int CpfCnpj { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public int NacionalidadeId { get; set; }
        public Sexo Sexo { get; set; }
        public int SexoId { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public int TipoPessoaId { get; set; }
        public bool Ativo { get; set; }
    }
}
