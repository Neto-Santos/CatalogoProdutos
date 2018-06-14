using LojaEsportes.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaEsportesDominio.Entidades
{
    public class Carrinho
    {
        private List<CarrinhoItem> _itensCarrinho = new List<CarrinhoItem>();
        public void AdcionarItem (Produto produto, int quantidade)
        {
            CarrinhoItem _item = _itensCarrinho.Where(p => p.Produto.ProdutoId == produto.ProdutoId).FirstOrDefault();
            if (_item == null)
            {
                _itensCarrinho.Add(new CarrinhoItem()
                {
                    Produto = produto,
                    Quantidade = quantidade
                });
            }
            else
            {
                _item.Quantidade += quantidade;
            }
        }
        public void RemoverItem(Produto produto)
        {
            _itensCarrinho.RemoveAll(item => item.Produto.ProdutoId == produto.ProdutoId);
        }
        public decimal CalcularValorTotal()
        {
            return _itensCarrinho.Sum(p=>p.Produto.Preco * p.Quantidade);
        }
        public void LimparCarrinho()
        {
            _itensCarrinho.Clear();
        }
        public IEnumerable<CarrinhoItem> Itens
        {
            get { return _itensCarrinho; }
        }
    }
    public class CarrinhoItem
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
