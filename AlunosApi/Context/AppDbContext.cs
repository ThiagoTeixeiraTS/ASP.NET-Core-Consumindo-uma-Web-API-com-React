using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                    new Aluno
                    {
                        Id = 1,
                        Nome = "Thiago Teixeira",
                        Email = "contato@thiagoteixeira.net",
                        Idade = 33
                    }, new Aluno
                    {
                        Id = 2,
                        Nome = "Augusto Teixeira",
                        Email = "Filho@Filhoteixeira.net",
                        Idade = 2
                    }, new Aluno
                    {
                        Id = 3,
                        Nome = "Renato Teixeira",
                        Email = "Filho@Filhoteixeira.net",
                        Idade = 10
                    }

                );
        }
    }
}
