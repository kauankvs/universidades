using Microsoft.EntityFrameworkCore;
using Universidade.Models;

namespace Universidade.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
        }

        public DbSet<Instituicao> Instituicaos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
    }
}
