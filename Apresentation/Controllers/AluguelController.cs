using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Apresentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AluguelController : ControllerBase
    {
        private readonly AlugarRepository _alugarRepository;

        public AluguelController()
        {
            _alugarRepository =  new AlugarRepository();
        }

        [HttpGet]
        public IActionResult GetAll(){
            return Ok(_alugarRepository.GetAll());
        }

        [HttpGet("{livroId}")]
        public IActionResult GetAluguelByLivroId(Guid livroId){
            return Ok(_alugarRepository.GetAluguelByLivroId(livroId));
        }

        [HttpGet("{livroId}")]
        public IActionResult GetAlugueisByLivroIdByPeriodo(Guid livroId, DateTime dataInicio, DateTime dataFim){
            return Ok(_alugarRepository.GetAlugueisByLivroIdByPeriodo(livroId, dataInicio, dataFim));
        }


        [HttpPost]
        public IActionResult GetAlugueisByPeriodo(DateTime dataInicio, DateTime dataFim){
            return Ok(_alugarRepository.GetAlugueisByPeriodo(dataInicio, dataFim));
        }
    }
}