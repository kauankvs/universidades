using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidade.Models;
using Universidade.Services.ServiceCurso;

namespace Universidade.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoService _service;
        public CursoController(ICursoService cursoService)
        {
            _service = cursoService;
        }

        [HttpGet]
        public async Task<ActionResult<Curso>> ReceberCursoPorID([FromBody] int ID)
        {
            return await _service.ReceberCursoPorID(ID);
        }

        [HttpGet]
        [Route("todos")]
        public async Task<ActionResult<List<Curso>>> ReceberTodosCursos()
        {
            return await _service.ReceberTodosCursos();
        }

        [HttpGet]
        [Route("todos/{ID}")]
        public async Task<ActionResult<List<Curso>>> ReceberCursosPorInstituicao([FromRoute] int ID)
        {
            return await _service.ReceberCursosPorInstituicao(ID);
        }

        [HttpPost]
        public async Task<ActionResult<Curso>> AdicionarCurso([FromBody] Curso curso) 
        {
            return await _service.AdicionarCurso(curso); 
        }

        [HttpDelete]
        public async Task<ActionResult<Curso>> DeletarCurso([FromBody] int ID) 
        {
            return await _service.DeletarCurso(ID);
        }

    }
}
