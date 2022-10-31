using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Universidade.Enums;
using Universidade.Models;
using Universidade.Services.ServiceInstituicao;

namespace Universidade.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InstituicaoController : ControllerBase
    {
        private readonly IInstituicaoService _service;

        public InstituicaoController(IInstituicaoService instituicaoService)
        {
            _service = instituicaoService;
        }

        [HttpGet]
        [Route("{ID}")]
        public async Task<ActionResult<Instituicao>> ReceberInstituicaoPorID([FromRoute] int ID)
        {
            return await _service.ReceberInstituicaoPorID(ID);
        }

        [HttpGet]
        [Route("todos")]
        public async Task<ActionResult<List<Instituicao>>> ReceberTodasInstituicao()
        {
            return await _service.ReceberTodasInstituicao();
        }

        [HttpGet]
        [Route("todos/{estado}")]
        public async Task<ActionResult<List<Instituicao>>> ReceberInstituicaoPorEstado([FromRoute] Estado estado)
        {
            return await _service.ReceberInstituicaoPorEstado(estado);
        }

        [HttpPost]
        public async Task<ActionResult<Instituicao>> AdicionarInstituicao([FromBody] Instituicao instituicao)
        {
            return await _service.AdicionarInstituicao(instituicao);
        }

        [HttpDelete]
        public async Task<ActionResult<Instituicao>> DeletarInstituicao([FromBody] int ID)
        {
            return await _service.DeletarInstituicao(ID);
        }
    }
}
