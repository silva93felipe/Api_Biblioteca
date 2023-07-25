using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_biblioteca.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace api_biblioteca.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {

        private readonly AlugarRepository _alugarRepository;

        public AluguelController(AlugarRepository alugarRepository)
        {
            _alugarRepository = alugarRepository;
        }

        [HttpGet]
        public IActionResult GetAll(){
            return Ok(_alugarRepository.GetAll());
        }

        [HttpGet("{livroId}")]
        public IActionResult GetAlugueisByLivroId(int livroId, DateTime? dataInicio, DateTime dataFim){
            return Ok(_alugarRepository.GetAlugueisByLivroId(livroId));
        }
    }
}