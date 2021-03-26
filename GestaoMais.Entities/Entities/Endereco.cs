namespace GestaoMais.Entities.Entities
{
    public class Endereco : Base
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Municipio { get; set; }
        public int Cep { get; set; }
        public int Numero { get; set; }

    }
}
