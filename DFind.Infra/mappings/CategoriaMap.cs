using DFind.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DFind.Infra.mappings
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");

            HasKey(x => x.Id);
            Property(x => x.Titulo).HasMaxLength(60).IsRequired();
        }
    }
}
