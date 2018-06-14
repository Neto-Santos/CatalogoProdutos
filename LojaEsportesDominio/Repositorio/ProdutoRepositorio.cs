using LojaEsportes.Dominio.Entidades;
using LojaEsportesDominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEsportesDominio.Repositorio
{
    public class ProdutoRepositorio : IRepositorio<Produto>
    {
        private ProdutoContexto contexto;
        public ProdutoRepositorio(ProdutoContexto produtoContexto)
        {
            this.contexto = produtoContexto;
        }

        //retorna todos os produtos, de uma determinada categoria
        public IEnumerable<Produto> Get(int? id)
        {
            return contexto.Produtos.Where(c => c.CategoriaId == id).OrderBy(p => p.Nome);
        }

        //retorna todos os produtos
        public IEnumerable<Produto> GetTodos()
        {
            return contexto.Produtos.ToList().OrderBy(p=>p.Nome);
        }
    }
}
