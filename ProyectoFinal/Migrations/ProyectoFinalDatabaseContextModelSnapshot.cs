﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinal.Context;

#nullable disable

namespace ProyectoFinal.Migrations
{
    [DbContext(typeof(ProyectoFinalDatabaseContext))]
    partial class ProyectoFinalDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProyectoFinal.Models.Cuenta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Admin")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cuentas");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Mascota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CantDuenios")
                        .HasColumnType("int");

                    b.Property<int?>("CuentaId")
                        .HasColumnType("int");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("EstadoDeSalud")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Personalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.Property<int>("SuRefugioId")
                        .HasColumnType("int");

                    b.Property<bool>("Vacunado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.HasIndex("SuRefugioId");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Refugio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CuentaId")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Horario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CuentaId");

                    b.ToTable("Refugios");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Mascota", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Cuenta", null)
                        .WithMany("Mascotas")
                        .HasForeignKey("CuentaId");

                    b.HasOne("ProyectoFinal.Models.Refugio", "SuRefugio")
                        .WithMany("Mascotas")
                        .HasForeignKey("SuRefugioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SuRefugio");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Refugio", b =>
                {
                    b.HasOne("ProyectoFinal.Models.Cuenta", null)
                        .WithMany("Refugios")
                        .HasForeignKey("CuentaId");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Cuenta", b =>
                {
                    b.Navigation("Mascotas");

                    b.Navigation("Refugios");
                });

            modelBuilder.Entity("ProyectoFinal.Models.Refugio", b =>
                {
                    b.Navigation("Mascotas");
                });
#pragma warning restore 612, 618
        }
    }
}