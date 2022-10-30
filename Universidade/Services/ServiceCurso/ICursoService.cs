using Microsoft.AspNetCore.Mvc;
using Universidade.Models;

namespace Universidade.Services.ServiceCurso
{
    public interface ICursoService
    {
        public Task<ActionResult<Curso>> ReceberCursoPorID(int ID);
        public Task<ActionResult<List<Curso>>> ReceberTodosCursos();
        public Task<ActionResult<List<Curso>>> ReceberCursosPorInstituicao(Instituicao instituicao);
        public Task<ActionResult<Curso>> AdicionarCurso(Curso curso);
        public Task<ActionResult<Curso>> DeletarCurso(int ID);
    }
}
