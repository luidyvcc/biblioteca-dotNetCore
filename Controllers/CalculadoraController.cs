using System.Linq;
using System;
using PrjBiblioteca.Dados;
using PrjBiblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PrjBiblioteca.Controllers
{
    public class CalculadoraController : Controller
    {

        private readonly BibliotecaDbContext _context;

        public CalculadoraController(BibliotecaDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Somar(double n1, double n2)
        {
            ViewData["res"] = n1 + n2;
            return View();
        }

        public double Divisao(double n1, double n2)
        {
            return n1 / n2;
        }

        public double Raiz(double n1, double n2)
        {
            return Math.Pow(n1,1 / n2);
        }

        public double Potenciacao(double n1, double n2)
        {
            return Math.Pow(n1, n2);
        }

        public double Multiplicacao(double n1, double n2)
        {
            return n1 * n2;
        }

        public ActionResult LinqWhereExample()
        {
            int[] numeros = { 1, 2, 4, 5, 6, 8, 10, 44};

            var qry = from n in numeros
                        where n > 5
                        select n;

            string nums = string.Empty;

            foreach ( var item in qry ) {
                nums += item + " ";
            }

            ViewData["res"] = nums;
            return View("Somar");
        }

        public async Task<IActionResult> LinqProjectionExample()
        {
            //var qty = await _context.Livro.ToListAsync();

            // var qty = from l in await _context.Livro.ToListAsync()
            //             where l.Quantidade > 0
            //             select l;

            var qty = from l in _context.Livro.AsQueryable()
                        where l.Quantidade > 0
                        select l;
           
            string resultados = string.Empty;

            foreach ( var item in await qty.ToListAsync() ) {

                resultados += string.Format(

                    "Id: {0}, Titulo: {1}, Qtde: {2}",
                    item.LivroId,
                    item.Titulo,
                    item.Quantidade

                ) + "\n";

            }

            ViewData["res"] = resultados;
            return View("Somar");
        }

    }
}