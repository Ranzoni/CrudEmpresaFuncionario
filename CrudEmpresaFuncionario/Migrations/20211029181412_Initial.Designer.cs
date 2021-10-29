﻿// <auto-generated />
using CrudEmpresaFuncionario.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CrudEmpresaFuncionario.Migrations
{
    [DbContext(typeof(CrudContext))]
    [Migration("20211029181412_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("CrudEmpresaFuncionario.Domain.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address2")
                        .HasColumnType("longtext");

                    b.Property<string>("City")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Neighborhood")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Number")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("State")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Street")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("CrudEmpresaFuncionario.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdAddress")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdAddress");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("CrudEmpresaFuncionario.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("IdCompany")
                        .HasColumnType("int");

                    b.Property<int>("IdPosition")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<double>("Salary")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.HasIndex("IdPosition");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("CrudEmpresaFuncionario.Domain.Entities.Position", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("CrudEmpresaFuncionario.Domain.Entities.Company", b =>
                {
                    b.HasOne("CrudEmpresaFuncionario.Domain.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("IdAddress")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("CrudEmpresaFuncionario.Domain.Entities.Employee", b =>
                {
                    b.HasOne("CrudEmpresaFuncionario.Domain.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrudEmpresaFuncionario.Domain.Entities.Position", "Position")
                        .WithMany()
                        .HasForeignKey("IdPosition")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Position");
                });
#pragma warning restore 612, 618
        }
    }
}