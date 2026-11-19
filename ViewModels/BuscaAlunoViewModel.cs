

using PrimeiroProjetoMVC.Models;

namespace PrimeiroProjetoMVC.ViewModels
{
    public class BuscaAlunoViewModel
    {
        public string? TermoBusca { get; set; }
        public List<Aluno> Resultados { get; set; } = new(); // Inicializa a lista de resultados para evitar null reference exceptions
    }
}