using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Universidade.Controllers;
using Universidade.Data;
using Universidade.Models;

namespace Universidade.Services.ServiceCurso
{
    public class CursoService : ICursoService
    {
        private readonly DataContext _context;
        CursoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Curso>> ReceberCursoPorID(int ID)
        {
            Curso curso = await _context.Cursos.AsNoTracking().FirstOrDefaultAsync(c => c.CursoID == ID);
            return curso;
        }

        public async Task<ActionResult<List<Curso>>> ReceberTodosCursos()
        {
            List<Curso> cursos = await _context.Cursos.AsNoTracking().ToListAsync();
            return cursos;
        }

        public async Task<ActionResult<List<Curso>>> ReceberCursosPorInstituicao(Instituicao instituicao)
        {
            List<Curso> cursos = await _context.Cursos.Where(c => c.CursoID == instituicao.ID).AsNoTracking().ToListAsync();
            return cursos;
        }

        public async Task<ActionResult<Curso>> AdicionarCurso(Curso curso)
        {

            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(ReceberCursoPorID), nameof(CursoController), new { id = curso.CursoID }, curso);
        }

        public async Task<ActionResult<Curso>> DeletarCurso(int ID)
        {
            Curso curso = await _context.Cursos.FindAsync(ID);

            if (curso == null) return new NotFoundResult();

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return new NoContentResult();

        }

    }
}
