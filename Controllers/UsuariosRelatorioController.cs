
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PrjBiblioteca.Dados;
using PrjBiblioteca.Models;

namespace PrjBiblioteca.Controllers
{
    public class UsuariosRelatorioController : Controller
    {

        private readonly BibliotecaDbContext _context;

        public UsuariosRelatorioController(BibliotecaDbContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = from u in _context.Usuario.Include(c => c.Categoria) select u;

            usuarios = usuarios.OrderByDescending(u => u.Categoria.Descricao);

            return View(await usuarios.ToListAsync());
        }
        
    }
}