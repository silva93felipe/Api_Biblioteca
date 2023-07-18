using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_biblioteca.Models;
using api_biblioteca.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api_biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        public static string _environment;
        public LivroRepository livroRepository;
        public LivroController()
        {
            livroRepository = new LivroRepository();
        }

        [HttpGet]
        public IActionResult GetAllAvailable(){
            return Ok(livroRepository.GetAllLivros());
        }

        [HttpPost]
        public IActionResult Create(Livro livro){
            livroRepository.Create(livro);
            return NoContent();
        }


        [HttpPost("Alugar/{livroId}")]
        public IActionResult Alugar(int livroId){
            livroRepository.Alugar(livroId);
            return Ok();
        }

        [HttpPost("Devolver/{livroId}")]
        public IActionResult Devolver(int livroId){
            livroRepository.Devolver(livroId);
            return Ok();
        }

    }
}