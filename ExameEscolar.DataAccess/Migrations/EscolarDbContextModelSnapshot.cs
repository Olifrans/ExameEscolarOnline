// <auto-generated />
using System;
using ExameEscolar.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ExameEscolar.DataAccess.Migrations
{
    [DbContext(typeof(EscolarDbContext))]
    partial class EscolarDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExameEscolar.DataAccess.Estudante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CVNomeArquivo")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Contato")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("GroupsId")
                        .HasColumnType("int");

                    b.Property<string>("ImagemNomeArquivo")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UsuarioNome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("GroupsId");

                    b.ToTable("Estudante");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.Exame", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasMaxLength(3550)
                        .HasColumnType("nvarchar(3550)");

                    b.Property<int>("GroupsId")
                        .HasColumnType("int");

                    b.Property<int>("Hora")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("GroupsId");

                    b.ToTable("Exame");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.ExameResultado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EstudanteId")
                        .HasColumnType("int");

                    b.Property<int?>("ExameId")
                        .HasColumnType("int");

                    b.Property<int>("QnAsId")
                        .HasColumnType("int");

                    b.Property<int>("Responder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstudanteId");

                    b.HasIndex("ExameId");

                    b.HasIndex("QnAsId");

                    b.ToTable("ExameResultado");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.Groups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasMaxLength(3550)
                        .HasColumnType("nvarchar(3550)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.QnAs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ExameId")
                        .HasColumnType("int");

                    b.Property<string>("Opcao1")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Opcao2")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Opcao3")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Opcao4")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Pergunta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Responder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExameId");

                    b.ToTable("QnAs");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Funcao")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UsuarioNome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.Estudante", b =>
                {
                    b.HasOne("ExameEscolar.DataAccess.Groups", "Groups")
                        .WithMany("Estudante")
                        .HasForeignKey("GroupsId");

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.Exame", b =>
                {
                    b.HasOne("ExameEscolar.DataAccess.Groups", "Groups")
                        .WithMany("Exame")
                        .HasForeignKey("GroupsId")
                        .IsRequired();

                    b.Navigation("Groups");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.ExameResultado", b =>
                {
                    b.HasOne("ExameEscolar.DataAccess.Estudante", "Estudante")
                        .WithMany("ExameResultado")
                        .HasForeignKey("EstudanteId")
                        .IsRequired();

                    b.HasOne("ExameEscolar.DataAccess.Exame", "Exame")
                        .WithMany("ExameResultado")
                        .HasForeignKey("ExameId");

                    b.HasOne("ExameEscolar.DataAccess.QnAs", "QnAs")
                        .WithMany("ExameResultado")
                        .HasForeignKey("QnAsId")
                        .IsRequired();

                    b.Navigation("Estudante");

                    b.Navigation("Exame");

                    b.Navigation("QnAs");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.Groups", b =>
                {
                    b.HasOne("ExameEscolar.DataAccess.Usuario", "Usuario")
                        .WithMany("Groups")
                        .HasForeignKey("UsuarioId")
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.QnAs", b =>
                {
                    b.HasOne("ExameEscolar.DataAccess.Exame", "Exame")
                        .WithMany("QnAs")
                        .HasForeignKey("ExameId")
                        .IsRequired();

                    b.Navigation("Exame");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.Estudante", b =>
                {
                    b.Navigation("ExameResultado");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.Exame", b =>
                {
                    b.Navigation("ExameResultado");

                    b.Navigation("QnAs");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.Groups", b =>
                {
                    b.Navigation("Estudante");

                    b.Navigation("Exame");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.QnAs", b =>
                {
                    b.Navigation("ExameResultado");
                });

            modelBuilder.Entity("ExameEscolar.DataAccess.Usuario", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
