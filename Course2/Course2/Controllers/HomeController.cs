using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Course2.Models;
using Course2.Database;
using Microsoft.EntityFrameworkCore;

namespace Course2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext database;

        public HomeController(ApplicationDBContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teste()
        {
            /* Categoria c1 = new Categoria();
             c1.Nome = "Vinicius";
             Categoria c2 = new Categoria();
             c2.Nome = "Vinicius";
             Categoria c3 = new Categoria();
             c3.Nome = "Amanda";
             Categoria c4 = new Categoria();
             c4.Nome = "Leonardo";

             List<Categoria> catlist = new List<Categoria>();
             catlist.Add(c1);
             catlist.Add(c2);
             catlist.Add(c3);
             catlist.Add(c4);

             database.AddRange(catlist);

             database.SaveChanges();
             */

            var listaDeCategorias = database.Categorias.Where(cat => cat.Nome.Equals("Vinicius")).ToList();

            Console.WriteLine("============= Categorias =============");

            listaDeCategorias.ForEach(categoria =>
            {
                Console.WriteLine(categoria.ToString());
                
            });

            Console.WriteLine("==================================");

            return Content("Dados Salvos");
        }

        public IActionResult Relacionamento()
        {
            /*
            Produto p = new Produto();
            p.Nome = "Mouse";
            p.Categoria = database.Categorias.First(c => c.Id == 1);

            Produto p2 = new Produto();
            p2.Nome = "Computador";
            p2.Categoria = database.Categorias.First(c => c.Id == 1);

            Produto p3 = new Produto();
            p3.Nome = "Notebook";
            p3.Categoria = database.Categorias.First(c => c.Id == 2);

            database.Add(p);
            database.Add(p2);
            database.Add(p3);

            database.SaveChanges();
            */
            /*
            var listaDeProdutos = database.Produtos.Include(p => p.Categoria).ToList();

            listaDeProdutos.ForEach(produto =>
            {
                Console.WriteLine(produto.ToString());
            });
            */

            var listaDeProdutosDeUmaCategoria = database.Produtos.Where(p => p.Categoria.Id == 1).ToList();//LAZY LOADING PODE DEIXAR SEU SISTEMA MUITO LENTO

            listaDeProdutosDeUmaCategoria.ForEach(produto =>
            {
                Console.WriteLine(produto.ToString());
            });

            return Content("Relacionamento");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
