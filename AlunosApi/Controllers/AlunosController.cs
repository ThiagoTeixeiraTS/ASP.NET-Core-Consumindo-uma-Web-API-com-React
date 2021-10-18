using AlunosApi.Models;
using AlunosApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlunosApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private IAlunoService _alunoService;

        public AlunosController(IAlunoService alunoService)
        {
            _alunoService = alunoService;
        }


        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunos()
        {
            try
            {
                var alunos = await _alunoService.GetAlunos();
                return Ok(alunos);
            }
            catch
            {

                return BadRequest("Request Invalido");
            }
        }

        [HttpGet]
        [Route("AlunoPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Aluno>>> GetAlunosByName([FromQuery] string nome)
        {
            try
            {
                var alunos = await _alunoService.GetAlunosByNome(nome);
                if (alunos == null)
                    return NotFound($"Não  existe alunos com o criterio {nome}");

                return Ok(alunos);
            }
            catch
            {

                return BadRequest("Request Invalido");
            }
        }


        [HttpGet ("{id:int}", Name ="GetAluno")]
        public async Task<ActionResult<Aluno>> GetAluno(int id)
        {
            try
            {
                var aluno = await  _alunoService.GetAluno(id);
                if (aluno == null)
                    return NotFound($"Não  existe aluno com a Id {id}");

                return Ok(aluno);
            }
            catch
            {

                return BadRequest("Request Invalido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(Aluno aluno)
        {
            try
            {
                await _alunoService.CreateAluno(aluno);
                return CreatedAtRoute(nameof (GetAluno), new {id = aluno.Id}, aluno);
            }
            catch
            {

                return BadRequest("Request Invalido");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, [FromBody] Aluno aluno)
        {
            try
            {
                if(aluno.Id == id)
                {
                    await _alunoService.UpdateAluno(aluno);
                    return Ok($"Aluno {id} foi alterado");
                }
                else
                {
                    return BadRequest("Request Invalido");
                }

            }
            catch
            {

                return BadRequest("Request Invalido");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Aluno>> Delete(int id)
        {
            try
            {
                var aluno = await _alunoService.GetAluno(id);
                if (aluno != null)
                {
                    await _alunoService.DeleteAluno(aluno);
                    return Ok($"Aluno com ID{id} deletado com sucesso!");
                }
                else
                {
                    return NotFound($"Não  existe aluno com a Id {id}");
                }
            }
            catch
            {
                return BadRequest("Request Invalido");
            }
        }

    }
}
