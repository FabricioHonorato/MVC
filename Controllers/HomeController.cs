using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimeiroProjetoMVC.Models;

namespace PrimeiroProjetoMVC.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // a view index lê essa chave para exibir o valor da mensagem
        ViewData["Mensagem"] = "Bem-vindo ao sistema!";
        return View();
    }

    // Action que recebe parametro pela rota, ex: /Home/Sobre/5
    public IActionResult Sobre(int? id)
    {
        // id pode ser nulo porque o trecho final da rota é opcional
        ViewBag.Versao = "1.0";
        ViewBag.ParametroId = id;
        return View();
    }


    public IActionResult Saudacao(string nome)
    {
        // Action que recebe parametros pela query string, ex: /Home/Saudacao?nome=Jéssica
        ViewData["Nome"] = nome ?? "Visitante";
        return View();
    }

 


}
