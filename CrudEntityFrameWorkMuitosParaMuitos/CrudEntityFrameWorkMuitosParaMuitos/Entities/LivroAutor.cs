namespace CrudEntityFrameWorkMuitosParaMuitos.Entities
{
    public class LivroAutor
    {
        public int AutorId { get; set; }
        public int LivroId { get; set; }
        public virtual Autor Autor { get; set; }
        public virtual Livro Livro { get; set; }
        public short Ano { get; set; }
    }
}
