using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Course2.Models;
using Course2.Database;


namespace Course2.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly ApplicationDBContext database;

        public ProdutosController(ApplicationDBContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            var produtos = database.Produtos.ToList();
            return View(produtos);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Produto produto = database.Produtos.First(registro => registro.Id == id);
            return View("Cadastrar", produto);
        }   

        public IActionResult Deletar(int id)
        {
            Produto produto = database.Produtos.First(registro => registro.Id == id);
            database.Produtos.Remove(produto);
            database.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Salvar(Produto produto)
        {
            if (produto.Id == 0)
            {
                //Salvar um novo funcionario
                database.Produtos.Add(produto);//pega os campos que foram dados do form
            }
            else
            {
                //Atualizar um novo funcionario
                Produto produtoDoBanco = database.Produtos.First(registro => registro.Id == produto.Id);

                produtoDoBanco.Nome = produto.Nome;
                produtoDoBanco.Categoria = produto.Categoria;
                

            }

            database.SaveChanges();//aqui salva os campos no bd
            return RedirectToAction("Index");
        }
        
    }
}