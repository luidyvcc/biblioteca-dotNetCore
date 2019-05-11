using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PrjBiblioteca.Models;

namespace PrjBiblioteca.Dados
{
    public partial class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext()
        {
        }

        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite("Data Source=biblioteca.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            #region Sistema Usuario
            modelBuilder.Entity<SistemaUsuario>()
                .HasKey(bc => new { bc.SistemaID, bc.UsuarioID });

            modelBuilder.Entity<SistemaUsuario>()
                .HasOne(bc => bc.Sistemas)
                .WithMany(b => b.SistUsuarios)
                .HasForeignKey(bc => bc.SistemaID);

            modelBuilder.Entity<SistemaUsuario>()
                .HasOne(bc => bc.Usuarios)
                .WithMany(c => c.SistUsuarios)
                .HasForeignKey(bc => bc.UsuarioID);
            #endregion

            #region Livro Emprestimo
            modelBuilder.Entity<LivroEmprestimo>()
                .HasKey(bc => new { bc.LivroID, bc.EmprestimoID });

            modelBuilder.Entity<LivroEmprestimo>()
                .HasOne(bc => bc.Livros)
                .WithMany(c => c.LivroEmprestimos)
                .HasForeignKey(bc => bc.LivroID);

            modelBuilder.Entity<LivroEmprestimo>()
                .HasOne(bc => bc.Emprestimos)
                .WithMany(b => b.EmprestimoLivros)
                .HasForeignKey(bc => bc.EmprestimoID);
            #endregion

            #region Livro Autor
            modelBuilder.Entity<LivroAutor>()
                .HasKey(bc => new { bc.LivroID, bc.AutorID });

            modelBuilder.Entity<LivroAutor>()
                .HasOne(bc => bc.Livros)
                .WithMany(c => c.LivroAutores)
                .HasForeignKey(bc => bc.LivroID);

            modelBuilder.Entity<LivroAutor>()
                .HasOne(bc => bc.Autores)
                .WithMany(b => b.AutorLivros)
                .HasForeignKey(bc => bc.AutorID);
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<PrjBiblioteca.Models.Livro> Livro { get; set; }
        public DbSet<PrjBiblioteca.Models.Usuario> Usuario { get; set; }
        public DbSet<PrjBiblioteca.Models.Sistema> Sistema { get; set; }
        public DbSet<PrjBiblioteca.Models.SistemaUsuario> SistemaUsuario { get; set; }
        public DbSet<PrjBiblioteca.Models.Autor> Autor { get; set; }
        public DbSet<PrjBiblioteca.Models.LivroAutor> LivroAutor { get; set; }
        public DbSet<PrjBiblioteca.Models.Emprestimo> Emprestimo { get; set; }
        public DbSet<PrjBiblioteca.Models.LivroEmprestimo> LivroEmprestimo { get; set; }
    }
}
