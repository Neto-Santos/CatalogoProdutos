using LojaEsportes.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEsportesDominio.Entidades
{
    public class ProdutoContexto: DbContext
    {
        public ProdutoContexto()
          : base("name=ConexaoEsportes")
        { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProdutoContexto>(new CreateDatabaseIfNotExists<ProdutoContexto>());
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
    }
}
