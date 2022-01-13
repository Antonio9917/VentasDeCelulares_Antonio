﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VentasDeCelulares_Antonio.api.Modelos;

namespace VentasDeCelulares_Antonio.api.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VentasDeCelulares_Antonio.api.Modelos.Caracterisiticas", b =>
                {
                    b.Property<int>("IdCaracteristicas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Color")
                        .HasMaxLength(120)
                        .HasColumnType("nvarchar(120)");

                    b.Property<string>("EspacioInterno")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("IdCompania")
                        .HasColumnType("int");

                    b.Property<string>("Procesador")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Ram")
                        .IsRequired()
                        .HasMaxLength(90)
                        .HasColumnType("nvarchar(90)");

                    b.HasKey("IdCaracteristicas");

                    b.HasIndex("IdCompania");

                    b.ToTable("Caracterisitcas");
                });

            modelBuilder.Entity("VentasDeCelulares_Antonio.api.Modelos.Compania", b =>
                {
                    b.Property<int>("IdCompania")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("IdCompania");

                    b.ToTable("Compania");
                });

            modelBuilder.Entity("VentasDeCelulares_Antonio.api.Modelos.Marca", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("IdModelo")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategoria");

                    b.HasIndex("IdModelo");

                    b.ToTable("Marca");
                });

            modelBuilder.Entity("VentasDeCelulares_Antonio.api.Modelos.Model", b =>
                {
                    b.Property<int>("IdModel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Activo")
                        .HasMaxLength(120)
                        .HasColumnType("bit");

                    b.Property<int>("IdCaracteristicas")
                        .HasColumnType("int");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("IdModel");

                    b.HasIndex("IdCaracteristicas");

                    b.ToTable("Model");
                });

            modelBuilder.Entity("VentasDeCelulares_Antonio.api.Modelos.Caracterisiticas", b =>
                {
                    b.HasOne("VentasDeCelulares_Antonio.api.Modelos.Compania", "Compania")
                        .WithMany("Caracterisiticas")
                        .HasForeignKey("IdCompania")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compania");
                });

            modelBuilder.Entity("VentasDeCelulares_Antonio.api.Modelos.Marca", b =>
                {
                    b.HasOne("VentasDeCelulares_Antonio.api.Modelos.Model", "Modelo")
                        .WithMany()
                        .HasForeignKey("IdModelo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("VentasDeCelulares_Antonio.api.Modelos.Model", b =>
                {
                    b.HasOne("VentasDeCelulares_Antonio.api.Modelos.Caracterisiticas", "Caracteristicas")
                        .WithMany("Modelo")
                        .HasForeignKey("IdCaracteristicas")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caracteristicas");
                });

            modelBuilder.Entity("VentasDeCelulares_Antonio.api.Modelos.Caracterisiticas", b =>
                {
                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("VentasDeCelulares_Antonio.api.Modelos.Compania", b =>
                {
                    b.Navigation("Caracterisiticas");
                });
#pragma warning restore 612, 618
        }
    }
}
