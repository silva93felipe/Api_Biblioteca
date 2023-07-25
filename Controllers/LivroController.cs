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


        [HttpPost("Alugar")]
        public IActionResult Alugar(int livroId, DateTime dataAluguel){
            var haveBiblioteca = HaveBibliotecaCreate();

            if(!haveBiblioteca){
                return Unauthorized(new { Message = "Nenhuma biblioteca cadastrada."} );
            }

            _livroRepository.Alugar(livroId, dataAluguel);
            return Ok();
        }

        [HttpPost("Devolver")]
        public IActionResult Devolver(int livroId, DateTime dataEntrega){

            var haveBiblioteca = HaveBibliotecaCreate();

            if(!haveBiblioteca){
               return Unauthorized(new { Message = "Nenhuma biblioteca cadastrada."} );
            }
            
            _livroRepository.Devolver(livroId, dataEntrega);
            return Ok();
        }

    }
}