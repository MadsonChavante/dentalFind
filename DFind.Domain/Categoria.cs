namespace DFind.Domain
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Imagem { get; set; }


        public override string ToString()
        {
            return this.Titulo;
        }
    }
}
