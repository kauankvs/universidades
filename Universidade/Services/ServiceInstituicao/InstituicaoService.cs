using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Universidade.Controllers;
using Universidade.Data;
using Universidade.Enums;
using Universidade.Models;

namespace Universidade.Services.ServiceInstituicao
{
    public class InstituicaoService : IInstituicaoService
    {
        private readonly DataContext _context;
        InstituicaoService(DataContext context)
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

        public async Task<ActionResult<List<Instituicao>>> ReceberInstituicaoPorEstado(Estado estado)
        {
            List<Instituicao> instituicao = await _context.Instituicoes.AsNoTracking().Where(i => i.Estado == estado).ToListAsync();
            return instituicao;
        }

        public async Task<ActionResult<Instituicao>> AdicionarInstituicao(Instituicao instituicao)
        {
            await _context.Instituicoes.AddAsync(instituicao);
            await _context.SaveChangesAsync();

            return new CreatedAtActionResult(nameof(ReceberInstituicaoPorID), nameof(InstituicaoController), new { id = instituicao.ID }, instituicao);
        }

        public async Task<ActionResult<Instituicao>> DeletarInstituicao(int ID)
        {
            Instituicao instituicao = await _context.Instituicoes.FirstOrDefaultAsync(i => i.ID == ID);
            _context.Instituicoes.Remove(instituicao);

            return new NoContentResult();
        }

    }
}
