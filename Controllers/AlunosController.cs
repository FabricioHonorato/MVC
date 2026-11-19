using Microsoft.AspNetCore.Mvc;
using PrimeiroProjetoMVC.Models;
using PrimeiroProjetoMVC.ViewModels;

namespace PrimeiroProjetoMVC.Controllers
{
    public class AlunosController : Controller
    {
        private static List<Aluno> _alunos = new()
        {
            new Aluno { Id = 1, Nome = "Ronaldo", Email = "fenomeno@gmail.com", Idade = 50 },  
            new Aluno { Id = 2, Nome = "Cafu", Email = "cafu@hotmail.com", Idade = 56 }
        };

        // GET /Alunos - lista todos os alunos
        public IActionResult Index()
        {
            return View(_alunos);
        }

        // GET /Alunos/Detalhes/1 - exibe detalhes de um aluno específico
        public IActionResult Detalhes(int id)
        {
            var aluno = _alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null)
            {
                return NotFound(); // Retorna 404 se o aluno não for encontrado
            }
            return View(aluno);
        }

        // GET /Alunos/Criar - exibe o formulário para criar um novo aluno
        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        // POST /Alunos/Criar - processa o formulário de criação de um novo aluno
        [HttpPost]
        public IActionResult Criar(Aluno aluno)
        {
            if (!ModelState.IsValid)
            {
                return View(aluno); // Retorna para a view de cadastro com os erros de validação
            }

            // if (_alunos.Any())
            // {
            //     aluno.Id =_alunos.Max(a => a.Id) + 1;
            // }
            // else
            // {
            //     aluno.Id = 1;
            // } //! esse bloco de código pode ser substituído pela linha abaixo, que faz a mesma coisa de forma mais concisa

            aluno.Id = _alunos.Any() ? _alunos.Max(a => a.Id) + 1 : 1; // Gera um novo Id

            _alunos.Add(aluno); // Adiciona o novo aluno à lista

            return RedirectToAction("index"); // Redireciona para a lista de alunos
        }

        // GET /Alunos/Buscar - exibe o formulário de busca de alunos
        [HttpGet]
        public IActionResult Buscar()
        {
            return View(new BuscaAlunoViewModel());
        }

        // POST /Alunos/Buscar - processa o formulário de busca de alunos
        [HttpPost]
        public IActionResult Buscar(BuscaAlunoViewModel vm)
        {
            if (!string.IsNullOrEmpty(vm.TermoBusca)) 
            {
            vm.Resultados = _alunos
                .Where(a => a.Nome.Contains(vm.TermoBusca, StringComparison.OrdinalIgnoreCase)).ToList(); // Filtra os alunos pelo termo de busca, ignorando maiúsculas e minúsculas
            }

            return View(vm);
        }
    }
}