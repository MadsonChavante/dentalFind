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
            
            HasRequired(x => x.Categoria);
            Property(x => x.Economia).IsOptional();
            Property(x => x.MelhorConsulta).IsOptional();
            Property(x => x.PiorConsulta).IsOptional();
        }
    }
}
