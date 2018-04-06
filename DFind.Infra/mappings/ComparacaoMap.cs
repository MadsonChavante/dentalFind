using DFind.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DFind.Infra.mappings
{
    class ComparacaoMap : EntityTypeConfiguration<Consulta>
    {
        public ComparacaoMap()
        {
            ToTable("Consulta");

            HasKey(x => x.Id);
            Property(x => x.Titulo).HasMaxLength(60).IsRequired();

            HasRequired(x => x.Produto);
        }
    }
}
