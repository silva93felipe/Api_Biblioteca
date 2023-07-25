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
    public class BibliotecaController : ControllerBase
    {
        private readonly BibliotecaRepository _bibliotecaRepository;
        public BibliotecaController()
        {
            _bibliotecaRepository = new BibliotecaRepository();
        }

        [HttpGet]
        public IActionResult GetAll(){
            var biblioteca = _bibliotecaRepository.GetAll();

            if(biblioteca is null){
                return NotFound(new {message = "Nenhuma biblioteca cadastrada."});
            }
            return Ok(biblioteca);
        }

        [HttpPost]
        public IActionResult Create(Biblioteca biblioteca){
            _bibliotecaRepository.Create(biblioteca);
            return NoContent();
        }
    }
}