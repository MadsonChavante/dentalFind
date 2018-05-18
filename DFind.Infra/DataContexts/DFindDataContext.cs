using DFind.Domain;
using DFind.Infra.mappings;
using System.Data.Entity;

namespace DFind.Infra.DataContexts
{
    public class DFindDataContext : DbContext
    {
        public DFindDataContext()
            : base("DFindConnectionString")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Consulta> Consulta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            modelBuilder.Configurations.Add(new consultaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

