using LojaEsportes.Dominio.Entidades;
using LojaEsportes.Web.Models;
using LojaEsportesDominio.Entidades;
using LojaEsportesDominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaEsportes.Web.Controllers
{
    [HandleError(ExceptionType =typeof(Exception), View ="_Erro")]
    public class CarrinhoController : Controller
    {
        // GET: Carrinho
        private IProcessarPedido _processarPedido;
        private IRepositorio<Produto> _produtoRepositorio;

        public CarrinhoController()
        {
            _produtoRepositorio = new ProdutoRepositorio(new ProdutoContexto());
            _processarPedido = new EnviarEmailPedido();
        }
        public ActionResult Index(string ReturnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = GetCarrinho(),
                ReturnUrl = ReturnUrl
            }
            );
        }
         public ActionResult ResumoCarrinho(Carrinho _carrinho)
        {
            _carrinho = GetCarrinho();
            return PartialView(_carrinho);
        }
        public ViewResult Checkout()
        {
            return View(new Despacho { Carrinho = GetCarrinho() });
        }
        [HttpPost]
        public ViewResult Checkout(Carrinho carrinho, Despacho despacho)
        {
            carrinho = GetCarrinho();
            if (carrinho.Itens.Count() == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _processarPedido.ProcessarPedido(carrinho, despacho);
                    carrinho.LimparCarrinho();
                    return View("PedidoConcluido");
                }
                catch (Exception ex)
                {

                    return View("_Erro", new HandleErrorInfo(ex, "Checkout", "Carrinho"));
                }
            }
            else
            {
                return View(despacho);
            }
        }

        public RedirectToRouteResult AdicionarItemAoCarrinho(int ProdutoId, string ReturnUrl)
        {
            Produto _produto = _produtoRepositorio.GetTodos().FirstOrDefault(p => p.ProdutoId == ProdutoId);
            if (_produto != null)
            {
                GetCarrinho().AdcionarItem(_produto, 1);
            }

            return RedirectToAction("Index", new { ReturnUrl });

        }
        public RedirectToRouteResult RemoverItensDoCarrinho(int ProdutoId, string ReturnUrl)
        {
            Produto _produto = _produtoRepositorio.GetTodos().FirstOrDefault(p => p.ProdutoId == ProdutoId);
            if (_produto != null)
            {
                GetCarrinho().RemoverItem(_produto);
            }
            return RedirectToAction("Index", new { ReturnUrl });
        }

        private Carrinho GetCarrinho()
        {
            Carrinho _carrinho = (Carrinho)Session["Carrinho"];
            if (_carrinho == null)
            {
                _carrinho = new Carrinho();
                Session["Carrinho"] = _carrinho;
            }
            return _carrinho;
        }
    }
}