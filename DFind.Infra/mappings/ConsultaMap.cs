using DFind.Domain;
using System.Data.Entity.ModelConfiguration;

namespace DFind.Infra.mappings
{
    class consultaMap : EntityTypeConfiguration<Consulta>
    {
        public consultaMap()
        {
            ToTable("Consulta");

            HasKey(x => x.Id);
            HasRequired(x => x.Produto);
            
            Property(x => x.Titulo).HasMaxLength(60).IsRequired();
            
        }
    }
}
