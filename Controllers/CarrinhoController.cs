using PrjBiblioteca.Dados;
using PrjBiblioteca.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using PrjBiblioteca.Services;
using System.Threading.Tasks;
using System;

namespace PrjBiblioteca.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly BibliotecaDbContext _context;

        private IServicoLogin _servicoLogin;

        public CarrinhoController(BibliotecaDbContext context, IServicoLogin servicoLogin) {
            _context = context;
            _servicoLogin = servicoLogin;
        }

        // GET: Carrinho
        public ActionResult Index() {

            if (GetCarrinho() == null)
                SetCarrinho(new List<CarrinhoModel>());

            return View(GetCarrinho());
        }

        // GET: Carrinho
        public ActionResult Adicionar(int? id) {

            // PEga o carrinho atual da sessao
            var listaLivros = GetCarrinho();

            if (!listaLivros.Exists(x => x.LivroId == id)) {

                // Recupera o livro do banco
                var livro = _context.Livro.FirstOrDefault(x => x.LivroId == id);

                // Add o livro do banco ao carrinho
                //listaLivros.Add(livro);
                listaLivros.Add( new CarrinhoModel() { 
                    LivroId = livro.LivroId,
                    Titulo = livro.Titulo,
                    Quantidade = 1
                } );

                // atualiza a sessao
                SetCarrinho(listaLivros);

            }else{
                return AdicionarItem(id);
            }
            
            return View("Index", GetCarrinho());
        }

        public ActionResult AdicionarItem(int? id) {

            var carrinho = GetCarrinho();

            if (carrinho == null) return View("Index", GetCarrinho());

            var livro = carrinho.FirstOrDefault(x => x.LivroId == id);
            livro.Quantidade++;

            SetCarrinho(carrinho);

            return View("Index", GetCarrinho());
        }

        public ActionResult RemoverItem(int? id) {

            var carrinho = GetCarrinho();

            if (carrinho == null) return View("Index", GetCarrinho());

            var livro = carrinho.FirstOrDefault(x => x.LivroId == id);
            if ( livro.Quantidade > 1 ) livro.Quantidade--;

            SetCarrinho(carrinho);

            return View("Index", GetCarrinho());
        }

        public ActionResult Remover(int? id) {

            var carrinho = GetCarrinho();

            if (carrinho == null) return View("Index", GetCarrinho());

            var livro = carrinho.FirstOrDefault(n => n.LivroId == id);

            carrinho.Remove(livro);

            SetCarrinho(carrinho);
            
            return View("Index", GetCarrinho());
        }

        private List<CarrinhoModel> GetCarrinho() {
            string carrinhoStr = HttpContext.Session.GetString("Carrinho");

            if (carrinhoStr == null) return new List<CarrinhoModel>();

            return JsonConvert.DeserializeObject<List<CarrinhoModel>>(carrinhoStr);
        }

        private void SetCarrinho(List<CarrinhoModel> carrinho) {
            string carrinhoStr = JsonConvert.SerializeObject(carrinho);
            
            HttpContext.Session.SetString("Carrinho", carrinhoStr);
        }

        // POST: EmprestarLivros
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EmprestarLivros()
        {
            // Verificamos se o usuário está logado
            if (_servicoLogin.UsuarioLogado()) {

                // Pegar ID do Usuário (utilizando o serviço que criamos)
                var usuario = _servicoLogin.RecuperarUsuario();

                // Criar empréstimo
                Emprestimo emprestimo = new Emprestimo()
                {
                    DataInicio = DateTime.Now,
                    DataFim = DateTime.Now.AddDays(7),
                    DataDevolucao = null,
                    Usuario = usuario,
                    EmprestimoLivros = new List<LivroEmprestimo>()
                };

                // Resgatar lista de livros no carrinho
                List<CarrinhoModel> listaLivros = GetCarrinho();

                // Inserir a lista de livros na tabela LivroEmprestimo
                foreach (var item in listaLivros)
                {
                    LivroEmprestimo livroEmprestimo = new LivroEmprestimo();
                    livroEmprestimo.LivroID = item.LivroId;
                    livroEmprestimo.Emprestimos = emprestimo;
                    emprestimo.EmprestimoLivros.Add(livroEmprestimo);
                }

                // Inserir o novo empréstimo na tabela
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();

                // Alertas do site (utilizando TempData)
                TempData["MsgAlert"] = "Empréstimo realizado com sucesso!";
                TempData["MsgEstilo"] = "alert-success";
            } else {
                // Alerta do site (utilizando TempData)
                TempData["MsgAlert"] = "Faça Login de sua aplicação!";
                TempData["MsgEstilo"] = "alert-danger";
            }

            return View("Index", GetCarrinho());
        }
    }
}
