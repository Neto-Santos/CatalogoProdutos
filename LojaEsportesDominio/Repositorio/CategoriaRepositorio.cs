using LojaEsportes.Dominio.Entidades;
using LojaEsportesDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEsportesDominio.Repositorio
{
    public class CategoriaRepositorio : IRepositorio<Categoria>
    {
        ProdutoContexto contexto;
        public CategoriaRepositorio(ProdutoContexto contexto)
        {
            this.contexto = contexto;
        }
        public IEnumerable<Categoria> Get(int? id)
        {
            return contexto.Categoria.Where(c => c.CategoriaId == id);
        }

        public IEnumerable<Categoria> GetTodos()
        {
            return contexto.Categoria.ToList().OrderBy(c => c.Nome);
        }
    }
}
