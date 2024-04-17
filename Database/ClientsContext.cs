using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestTask.db;

public partial class ClientsContext : DbContext
{
    public ClientsContext()
    {
    }

    public ClientsContext(DbContextOptions<ClientsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=clients;Username=postgres;Password=postgres;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Fio).HasName("users_pkey");

            entity.ToTable("users");

            entity.Property(e => e.Fio).HasColumnName("fio");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Uuid).HasName("clients_pkey");

            entity.ToTable("clients");

            entity.Property(e => e.Uuid)
                .ValueGeneratedNever()
                .HasColumnName("uuid");
            entity.Property(e => e.AccountNumber).HasColumnName("account_number");
            entity.Property(e => e.BirthDate).HasColumnName("birth_date");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.Inn).HasColumnName("inn");
            entity.Property(e => e.LastName).HasColumnName("last_name");
            entity.Property(e => e.Responsible).HasColumnName("responsible");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'Не в работе'::text")
                .HasColumnName("status");
            entity.Property(e => e.SurName).HasColumnName("sur_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
