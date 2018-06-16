using LojaEsportes.Dominio.Entidades;
using LojaEsportesDominio.Entidades;
using LojaEsportesDominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaEsportes.Web.Controllers
{
    public class NavegaController : Controller
    {
        // GET: Navega
        private IRepositorio<Categoria> categoriaRepositorio;
        public NavegaController()
        {
            categoriaRepositorio = new CategoriaRepositorio(new ProdutoContexto());
        }

        public ActionResult Menu()
        {
            var categorias = categoriaRepositorio.GetTodos();
            return PartialView(categorias);
        }

    }
}