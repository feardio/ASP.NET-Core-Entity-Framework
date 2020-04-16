using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Course2.Models;
using Course2.Database;
using Microsoft.EntityFrameworkCore;

namespace Course2.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ApplicationDBContext database;

        public CategoriasController(ApplicationDBContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            var categorias = database.Categorias.ToList();
            return View(categorias);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            Categoria categorias = database.Categorias.First(registro => registro.Id == id);
            return View("Cadastrar", categorias);
        }

        public IActionResult Deletar(int id)
        {
            Categoria categorias = database.Categorias.First(registro => registro.Id == id);
            database.Categorias.Remove(categorias);
            database.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Salvar(Categoria categorias)
        {
            if (categorias.Id == 0)
            {
                //Salvar um novo funcionario
                database.Categorias.Add(categorias);//pega os campos que foram dados do form
            }
            else
            {
                //Atualizar um novo funcionario
                Categoria categoriaDoBanco = database.Categorias.First(registro => registro.Id == categorias.Id);

                categoriaDoBanco.Nome = categorias.Nome;
                


            }

            database.SaveChanges();//aqui salva os campos no bd
            return RedirectToAction("Index");
        }
    }
}