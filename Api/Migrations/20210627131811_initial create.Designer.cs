﻿// <auto-generated />
using System;
using Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Api.Migrations
{
    [DbContext(typeof(DisneyDBContext))]
    [Migration("20210627131811_initial create")]
    partial class initialcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Api.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Personaje Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Edad")
                        .HasColumnType("int")
                        .HasColumnName("Edad");

                    b.Property<string>("Historia")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Historia");

                    b.Property<string>("Imangen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Imagen");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Nombre");

                    b.Property<int?>("Pelicula Id")
                        .HasColumnType("int");

                    b.Property<int>("Peso")
                        .HasColumnType("int")
                        .HasColumnName("Peso");

                    b.HasKey("Id");

                    b.HasIndex("Pelicula Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Api.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Genero Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Imagen");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nombre");

                    b.Property<int?>("Pelicula Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Pelicula Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Api.Entities.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Pelicula Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Calficacion")
                        .HasColumnType("int")
                        .HasColumnName("Caificacion");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("datetime2")
                        .HasColumnName("Fecha de Estreno");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Imagen");

                    b.Property<int?>("Personaje Id")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("Personaje Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Api.Entities.Character", b =>
                {
                    b.HasOne("Api.Entities.Movie", "PeliculasAsociadas")
                        .WithMany()
                        .HasForeignKey("Pelicula Id");

                    b.Navigation("PeliculasAsociadas");
                });

            modelBuilder.Entity("Api.Entities.Genre", b =>
                {
                    b.HasOne("Api.Entities.Movie", "PeliculasAsociadas")
                        .WithMany()
                        .HasForeignKey("Pelicula Id");

                    b.Navigation("PeliculasAsociadas");
                });

            modelBuilder.Entity("Api.Entities.Movie", b =>
                {
                    b.HasOne("Api.Entities.Character", "PersonajesAsociados")
                        .WithMany()
                        .HasForeignKey("Personaje Id");

                    b.Navigation("PersonajesAsociados");
                });
#pragma warning restore 612, 618
        }
    }
}
