using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Apresentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivroController : ControllerBase
    {
        // private readonly LivroRepository _livroRepository;
        // public LivroController()
        // {
        //     _livroRepository = new LivroRepository();
        // }

        [HttpGet]
        public IActionResult GetAllAvailable() => Ok();


        [HttpPost]
        public IActionResult Create(Livro livro){
            Console.WriteLine(livro.Autor);
            //_livroRepository.Create(livro);
            return Ok();
        }


        [HttpPost("Alugar")]
        public IActionResult Alugar(Guid livroId){

            //_livroRepository.Alugar(livroId);
            return NoContent();
        }

        [HttpPost("Devolver")]
        public IActionResult Devolver(Guid livroId){ 
            //_livroRepository.Devolver(livroId);
            return NoContent();
        }

    }
}