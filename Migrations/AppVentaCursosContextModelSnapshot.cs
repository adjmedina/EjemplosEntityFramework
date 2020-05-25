﻿// <auto-generated />
using System;
using LeerData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeerData.Migrations
{
    [DbContext(typeof(AppVentaCursosContext))]
    partial class AppVentaCursosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("LeerData.Models.Comentario", b =>
                {
                    b.Property<int>("ComentarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alumno")
                        .HasColumnType("text");

                    b.Property<string>("ComentarioTexto")
                        .HasColumnType("text");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<int>("Puntaje")
                        .HasColumnType("int");

                    b.HasKey("ComentarioId");

                    b.HasIndex("CursoId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("LeerData.Models.Curso", b =>
                {
                    b.Property<int>("CursoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaPublicacion")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("FotoPortada")
                        .HasColumnType("varbinary(4000)");

                    b.Property<string>("Titulo")
                        .HasColumnType("text");

                    b.HasKey("CursoId");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("LeerData.Models.CursoInstructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.HasKey("InstructorId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("CursoInstructor");
                });

            modelBuilder.Entity("LeerData.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .HasColumnType("text");

                    b.Property<byte[]>("FotoPerfil")
                        .HasColumnType("varbinary(4000)");

                    b.Property<string>("Grado")
                        .HasColumnType("text");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("LeerData.Models.Precio", b =>
                {
                    b.Property<int>("PrecioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CursoId")
                        .HasColumnType("int");

                    b.Property<decimal>("PrecioActual")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<decimal>("Promocion")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("PrecioId");

                    b.HasIndex("CursoId")
                        .IsUnique();

                    b.ToTable("Precio");
                });

            modelBuilder.Entity("LeerData.Models.Comentario", b =>
                {
                    b.HasOne("LeerData.Models.Curso", "Curso")
                        .WithMany("ComentarioLista")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeerData.Models.CursoInstructor", b =>
                {
                    b.HasOne("LeerData.Models.Curso", "Curso")
                        .WithMany("InstructorLink")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LeerData.Models.Instructor", "Instructor")
                        .WithMany("CursoLink")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeerData.Models.Precio", b =>
                {
                    b.HasOne("LeerData.Models.Curso", "Curso")
                        .WithOne("PrecioPromocion")
                        .HasForeignKey("LeerData.Models.Precio", "CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
