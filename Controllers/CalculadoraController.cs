using Microsoft.AspNetCore.Mvc;
using System;

namespace PrjBiblioteca.Controllers
{
    public class CalculadoraController : Controller
    {
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
    }
}