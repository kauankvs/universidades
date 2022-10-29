using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Universidade.Controllers;
using Universidade.Data;
using Universidade.Models;

namespace Universidade.Services
{
    public class CursoService : ICursoService
    {
        private readonly DataContext _context;

        CursoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Curso>> receberCursoPorID(int ID)
        {
            var curso = await _context.Cursos.FindAsync(ID);
            return curso;
        }

        public async Task<ActionResult<List<Curso>>> receberCursosPorInstituicao(Instituicao instituicao)
        {
            var cursos = await _context.Cursos.Where(c => c.CursoID == instituicao.ID).ToListAsync();
            return cursos;
        }

        public async Task<ActionResult<Curso>> adicionarCurso(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
            await _context.SaveChangesAsync();

            return curso;
        }

        public async Task<ActionResult<Curso>> deletarCurso(int ID)
        {
            var curso = await _context.Cursos.FindAsync(ID);

            if(curso == null) return new NotFoundResult();
            
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return new NoContentResult();
            
        }

    }
}
