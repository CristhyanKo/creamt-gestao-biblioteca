namespace GestaoMais.Entities.Entities.Livro
{
    public class Livro : Base
    {
        public string ISBN { get; set; }
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public int AutorId { get; set; }
        public string Editora { get; set; }
        public string Edicao { get; set; }
        public int Ano { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
        public LivroSituacao LivroSituacao { get; set; }
        public int LivroSituacaoId { get; set; }
    }
}
