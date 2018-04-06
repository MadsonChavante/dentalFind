using DFind.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DFind.Infra.mappings
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");
            HasKey(x => x.Id);

            Property(x => x.Titulo).HasMaxLength(160).IsRequired();
            //Property(x => x.Preco).IsRequired();

            HasRequired(x => x.Categoria);
            //caso a categoria ser opcional 
            //HasOptional
            //caso seja muitas categorias
            //HasMany

        }
    }
}
