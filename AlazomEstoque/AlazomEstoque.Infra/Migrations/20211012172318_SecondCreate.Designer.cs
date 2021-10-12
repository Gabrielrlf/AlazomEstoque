﻿// <auto-generated />
using System;
using AlazomEstoque.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlazomEstoque.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20211012172318_SecondCreate")]
    partial class SecondCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("AlazomEstoque.Core.Domain.Model.CadastroFornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HorarioEntrada")
                        .HasColumnType("TEXT");

                    b.Property<string>("Placa")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CadFornecedor");
                });

            modelBuilder.Entity("AlazomEstoque.Core.Domain.Model.EstoqueAbertura", b =>
                {
                    b.Property<int>("IdAbertura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("HorarioAbertura")
                        .HasColumnType("TEXT");

                    b.Property<int>("QtdDia")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdAbertura");

                    b.ToTable("EstoqueAbertura");
                });

            modelBuilder.Entity("AlazomEstoque.Core.Domain.Model.EstoqueVagas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("QtdAtual")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UltimaData")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("EstoqueVaga");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QtdAtual = 0,
                            UltimaData = new DateTime(2021, 10, 12, 14, 23, 18, 398, DateTimeKind.Local).AddTicks(7783)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}