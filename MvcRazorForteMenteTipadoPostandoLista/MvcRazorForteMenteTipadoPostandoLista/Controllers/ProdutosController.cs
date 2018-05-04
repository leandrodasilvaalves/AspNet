using MvcRazorForteMenteTipadoPostandoLista.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcRazorForteMenteTipadoPostandoLista.Controllers
{
    public class ProdutosController : Controller
    {
        private IEnumerable<Produto> _produtos;

        public ProdutosController()
        {
            _produtos = new List<Produto>
            {
                new Produto{ Id =1, Nome ="Arroz", Preco=10.75M, Ativo = true},
                new Produto{ Id =2, Nome ="Feijão", Preco=3.35M, Ativo = true},
                new Produto{ Id =3, Nome ="Açúcar", Preco=8.63M, Ativo = true},
                new Produto{ Id =4, Nome ="Desodorante", Preco=12.15M, Ativo = true},
                new Produto{ Id =5, Nome ="Sabonete", Preco=0.75M, Ativo = true},
                new Produto{ Id =6, Nome ="Suco", Preco=0.69M, Ativo = true},
                new Produto{ Id =7, Nome ="Leite", Preco=3.75M, Ativo = true}
            };
        }
        // GET: Produtos
        public ActionResult Index()
        {
            return View(_produtos);
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<Produto> model)
        {
            _produtos = model;
            return View(_produtos);
        }

       
    }
}