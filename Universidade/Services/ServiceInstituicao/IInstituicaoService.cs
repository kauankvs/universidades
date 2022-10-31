using Microsoft.AspNetCore.Mvc;
using Universidade.Data;
using Universidade.Enums;
using Universidade.Models;

namespace Universidade.Services.ServiceInstituicao
{
    public interface IInstituicaoService
    {
        public Task<ActionResult<Instituicao>> ReceberInstituicaoPorID(int ID);
        public Task<ActionResult<List<Instituicao>>> ReceberTodasInstituicao();
        public Task<ActionResult<List<Instituicao>>> ReceberInstituicaoPorEstado(Estado estado);
        public Task<ActionResult<Instituicao>> AdicionarInstituicao(Instituicao instituicao);
        public Task<ActionResult<Instituicao>> DeletarInstituicao(int ID);
    }
}
