using GestaoMais.Entities.Entities.Sistema;
using System;

namespace GestaoMais.Entities.Entities.Pessoa
{
    public class Pessoa : Base
    {
        public string Nome { get; set; }
        public string CpfCnpj { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public Nacionalidade Nacionalidade { get; set; }
        public int NacionalidadeId { get; set; }
        public Sexo Sexo { get; set; }
        public int SexoId { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public int TipoPessoaId { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public string Cep { get; set; }
        public int Numero { get; set; }
        public bool Ativo { get; set; }
    }
}
