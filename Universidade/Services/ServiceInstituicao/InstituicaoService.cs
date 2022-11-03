using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Universidade.Controllers;
using Universidade.Data;
using Universidade.Models;

namespace Universidade.Services.ServiceInstituicao
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly DataContext _context;
        public InstituicaoService(DataContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Instituicao>> ReceberInstituicaoPorID(int ID)
        {
            Instituicao instituicao = await _context.Instituicoes.AsNoTracking().FirstOrDefaultAsync(i => i.ID == ID);
            return instituicao;
        }

        public async Task<ActionResult<List<Instituicao>>> ReceberTodasInstituicao()
        {
            List<Instituicao> instituicao = await _context.Instituicoes.AsNoTracking().ToListAsync();
            return instituicao;
        }

        public async Task<ActionResult<List<Instituicao>>> ReceberInstituicaoPorEstado(string estado)
        {
            List<Instituicao> instituicao = await _context.Instituicoes.AsNoTracking().Where(i => i.Estado == estado.ToUpper()).ToListAsync();
            return instituicao;
        }

        public async Task<ActionResult<Instituicao>> AdicionarInstituicao(Instituicao instituicao)
        {
            instituicao.Estado = instituicao.Estado.ToUpper();
            await _context.Instituicoes.AddAsync(instituicao);
            await _context.SaveChangesAsync();

            var createdResourses = new { id = instituicao.ID };
            string uri = "$https://localhost:7049/instituicao/{createdResourses.id}";

            return new CreatedResult(uri, createdResourses);
        }

        public async Task<ActionResult<Instituicao>> DeletarInstituicao(int ID)
        {
            Instituicao instituicao = await _context.Instituicoes.FirstOrDefaultAsync(i => i.ID == ID);
            _context.Instituicoes.Remove(instituicao);

            return new NoContentResult();
        }

    }
}
