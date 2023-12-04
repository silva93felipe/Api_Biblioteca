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
        private readonly LivroRepository _livroRepository;
        public LivroController()
        {
            _livroRepository = new LivroRepository();
        }

        [HttpGet]
        public IActionResult GetAllAvailable() => Ok(_livroRepository.GetAllLivros());


        [HttpPost]
        public IActionResult Create(Livro livro){
            _livroRepository.Create(livro);
            return NoContent();
        }


        [HttpPost("Alugar")]
        public IActionResult Alugar(Guid livroId){

            _livroRepository.Alugar(livroId);
            return NoContent();
        }

        [HttpPost("Devolver")]
        public IActionResult Devolver(Guid livroId){ 
            _livroRepository.Devolver(livroId);
            return NoContent();
        }

    }
}