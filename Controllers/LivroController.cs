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
        private readonly BibliotecaRepository _bibliotecaRepository;
        public LivroController()
        {
            _livroRepository = new LivroRepository();
            _bibliotecaRepository = new BibliotecaRepository();
        }

        [HttpGet]
        public IActionResult GetAllAvailable(){
            
            var haveBiblioteca = HaveBibliotecaCreate();

            if(!haveBiblioteca){
                return Unauthorized(new { Message = "Nenhuma biblioteca cadastrada."} );
            }

            return Ok(_livroRepository.GetAllLivros());
        }

        private bool HaveBibliotecaCreate(){
            var biblioteca = _bibliotecaRepository.GetAll();
            if(biblioteca != null){
                return true;
            }

            return false;
        }


        [HttpPost]
        public IActionResult Create(Livro livro){
            var haveBiblioteca = HaveBibliotecaCreate();

            if(!haveBiblioteca){
                return Unauthorized(new { Message = "Nenhuma biblioteca cadastrada."} );
            }

            _livroRepository.Create(livro);
            return NoContent();
        }


        [HttpPost("Alugar/{livroId}")]
        public IActionResult Alugar(int livroId){
            var haveBiblioteca = HaveBibliotecaCreate();

            if(!haveBiblioteca){
                return Unauthorized(new { Message = "Nenhuma biblioteca cadastrada."} );
            }

            _livroRepository.Alugar(livroId);
            return Ok();
        }

        [HttpPost("Devolver/{livroId}")]
        public IActionResult Devolver(int livroId){

            var haveBiblioteca = HaveBibliotecaCreate();

            if(!haveBiblioteca){
               return Unauthorized(new { Message = "Nenhuma biblioteca cadastrada."} );
            }
            
            _livroRepository.Devolver(livroId);
            return Ok();
        }

    }
}