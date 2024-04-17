﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestTask.db;

#nullable disable

namespace TestTask_CRM_ASP.Net.Migrations
{
    [DbContext(typeof(ClientsContext))]
    [Migration("20240412132924_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TestTask.db.Client", b =>
                {
                    b.Property<Guid>("Uuid")
                        .HasColumnType("uuid")
                        .HasColumnName("uuid");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("account_number");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date")
                        .HasColumnName("birth_date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("inn");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<Guid>("Responsible")
                        .HasColumnType("uuid")
                        .HasColumnName("responsible");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("status")
                        .HasDefaultValueSql("'text'::text");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("sur_name");

                    b.HasKey("Uuid")
                        .HasName("clients_pkey");

                    b.ToTable("clients", (string)null);
                });

            modelBuilder.Entity("TestTask.db.User", b =>
                {
                    b.Property<Guid>("Uui")
                        .HasColumnType("uuid")
                        .HasColumnName("uui");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("fio");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Uui")
                        .HasName("users_pkey");

                    b.ToTable("users", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}