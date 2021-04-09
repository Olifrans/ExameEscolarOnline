using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.DataAccess.Data
{
    public class EscolarDbContext : DbContext
    {
        public EscolarDbContext(DbContextOptions<EscolarDbContext> options) : base(options)
        {

        }

        public DbSet<ExameResultado> ExameResultado { get; set; }

        public DbSet<Exame> Exame { get; set; }

        public DbSet<Groups> Groups { get; set; }

        public DbSet<QnAs> QnAs { get; set; }

        public DbSet<Estudante> Estudante { get; set; }

        public DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.UsuarioNome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Senha).IsRequired().HasMaxLength(50);
            });


            modelBuilder.Entity<Estudante>(entity =>
            {
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.UsuarioNome).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Senha).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Contato).HasMaxLength(50);
                entity.Property(e => e.CVNomeArquivo).HasMaxLength(350);
                entity.Property(e => e.ImagemNomeArquivo).HasMaxLength(450);
                entity.HasOne(e => e.Groups).WithMany(p => p.Estudante).HasForeignKey(d => d.GroupsId);
            });


            modelBuilder.Entity<QnAs>(entity =>
            {
                entity.Property(e => e.Pergunta).IsRequired();
                entity.Property(e => e.Opcao1).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Opcao2).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Opcao3).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Opcao4).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Responder).IsRequired();
                entity.HasOne(e => e.Exame).WithMany(p => p.QnAs).HasForeignKey(d => d.ExameId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Groups>(entity =>
            {
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Descricao).HasMaxLength(3550);
                entity.HasOne(e => e.Usuario).WithMany(p => p.Groups).HasForeignKey(d => d.UsuarioId).OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<Exame>(entity =>
            {
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Descricao).HasMaxLength(3550);
                entity.HasOne(e => e.Groups).WithMany(p => p.Exame).HasForeignKey(d => d.GroupsId).OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<ExameResultado>(entity =>
            {
                entity.HasOne(e => e.Exame).WithMany(p => p.ExameResultado).HasForeignKey(d => d.ExameId);
                entity.HasOne(e => e.QnAs).WithMany(p => p.ExameResultado).HasForeignKey(d => d.QnAsId).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Estudante).WithMany(p => p.ExameResultado).HasForeignKey(d => d.EstudanteId).OnDelete(DeleteBehavior.ClientSetNull);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
