using LojaEsportesDominio.Entidades;
using LojaEsportesDominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using LojaEsportes.Dominio.Entidades;

namespace LojaEsportes.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private IRepositorio<Produto> _repositorio;
        // GET: Produto
        public ProdutoController()
        {
            _repositorio = new ProdutoRepositorio(new ProdutoContexto());
        }
        public ActionResult Catalogo(int? pag, int? cat)
        {
            if (cat == null)
            {
                return View(_repositorio.GetTodos().ToPagedList(pag ?? 1, 2));
            }
            else
            {
                return View(_repositorio.Get(cat).ToPagedList(pag ?? 1, 2));
            }
           
        }
    }
}