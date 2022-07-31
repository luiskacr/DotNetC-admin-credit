﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.Entities
{
    public partial class proyectoCreditosContext : DbContext
    {
        public proyectoCreditosContext()
        {
        }

        public proyectoCreditosContext(DbContextOptions<proyectoCreditosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Currency> Currencies { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Loan> Loans { get; set; } = null!;
        public virtual DbSet<LoansHistory> LoansHistories { get; set; } = null!;
        public virtual DbSet<LoansState> LoansStates { get; set; } = null!;
        public virtual DbSet<LoansType> LoansTypes { get; set; } = null!;
        public virtual DbSet<PaymentType> PaymentTypes { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=proyectoCreditos;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry)
                    .HasName("PK__countrie__8536480902BD26E8");

                entity.ToTable("countries");

                entity.Property(e => e.IdCountry).HasColumnName("idCountry");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("countryName");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.HasKey(e => e.IdCurrencies)
                    .HasName("PK__currenci__937C33358DCE9719");

                entity.ToTable("currencies");

                entity.Property(e => e.IdCurrencies).HasColumnName("idCurrencies");

                entity.Property(e => e.CurrencyIso)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("currencyISO");

                entity.Property(e => e.CurrencyName)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("currencyName");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomers)
                    .HasName("PK__customer__D2815072D9FD6DA8");

                entity.ToTable("customers");

                entity.HasIndex(e => e.DocumentId, "UQ__customer__EFAAAD846B292DF3")
                    .IsUnique();

                entity.Property(e => e.IdCustomers).HasColumnName("idCustomers");

                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("birthDate");

                entity.Property(e => e.DocumentId)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("documentId");

                entity.Property(e => e.Email)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("firstName");

                entity.Property(e => e.IdState).HasColumnName("idState");

                entity.Property(e => e.LastName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("lastName");

                entity.Property(e => e.Telephone)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("telephone");

                entity.Property(e => e.UserAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("userAddress");

                entity.HasOne(d => d.IdStateNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.IdState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__customers__idSta__2A4B4B5E");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.IdLoan)
                    .HasName("PK__loans__1B9464CDA0FE3C6E");

                entity.ToTable("loans");

                entity.Property(e => e.IdLoan).HasColumnName("idLoan");

                entity.Property(e => e.BankFees)
                    .HasColumnType("money")
                    .HasColumnName("bankFees");

                entity.Property(e => e.CurrentAmount)
                    .HasColumnType("money")
                    .HasColumnName("currentAmount")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("endDate");

                entity.Property(e => e.IdCurrencies).HasColumnName("idCurrencies");

                entity.Property(e => e.IdLoansState).HasColumnName("idLoansState");

                entity.Property(e => e.Idcustomers).HasColumnName("idcustomers");

                entity.Property(e => e.IdloansType).HasColumnName("idloansType");

                entity.Property(e => e.InteresRate)
                    .HasColumnType("decimal(9, 6)")
                    .HasColumnName("interesRate");

                entity.Property(e => e.LoanAmount)
                    .HasColumnType("money")
                    .HasColumnName("loanAmount");

                entity.Property(e => e.LoansDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("loansDescription");

                entity.Property(e => e.MonthlyAmount)
                    .HasColumnType("money")
                    .HasColumnName("monthlyAmount");

                entity.Property(e => e.NextDueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("nextDueDate");

                entity.Property(e => e.StarDate)
                    .HasColumnType("datetime")
                    .HasColumnName("starDate");

                entity.HasOne(d => d.IdCurrenciesNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.IdCurrencies)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__loans__idCurrenc__3B75D760");

                entity.HasOne(d => d.IdLoansStateNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.IdLoansState)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__loans__idLoansSt__3C69FB99");

                entity.HasOne(d => d.IdcustomersNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.Idcustomers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__loans__idcustome__38996AB5");

                entity.HasOne(d => d.IdloansTypeNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.IdloansType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__loans__idloansTy__3A81B327");
            });

            modelBuilder.Entity<LoansHistory>(entity =>
            {
                entity.HasKey(e => e.IdLoansHistory)
                    .HasName("PK__loansHis__1CA1D5C4536F1AE0");

                entity.ToTable("loansHistories");

                entity.Property(e => e.IdLoansHistory).HasColumnName("idLoansHistory");

                entity.Property(e => e.LoadId).HasColumnName("loadId");

                entity.Property(e => e.PayDate)
                    .HasColumnType("datetime")
                    .HasColumnName("payDate");

                entity.Property(e => e.PaymentAmount)
                    .HasColumnType("money")
                    .HasColumnName("paymentAmount");

                entity.Property(e => e.PaymentType).HasColumnName("paymentType");

                entity.HasOne(d => d.Load)
                    .WithMany(p => p.LoansHistories)
                    .HasForeignKey(d => d.LoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__loansHist__loadI__412EB0B6");

                entity.HasOne(d => d.PaymentTypeNavigation)
                    .WithMany(p => p.LoansHistories)
                    .HasForeignKey(d => d.PaymentType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__loansHist__payme__4222D4EF");
            });

            modelBuilder.Entity<LoansState>(entity =>
            {
                entity.HasKey(e => e.LoansStatesId)
                    .HasName("PK__loansSta__14BED58B42694273");

                entity.ToTable("loansStates");

                entity.Property(e => e.LoansStatesId).HasColumnName("loansStatesId");

                entity.Property(e => e.LoansStateName)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("loansStateName");
            });

            modelBuilder.Entity<LoansType>(entity =>
            {
                entity.HasKey(e => e.IdloansType)
                    .HasName("PK__loansTyp__BC3185C6EFEBC25A");

                entity.ToTable("loansType");

                entity.Property(e => e.IdloansType).HasColumnName("idloansType");

                entity.Property(e => e.LoansTypeName)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("loansTypeName");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.HasKey(e => e.IdPaymentType)
                    .HasName("PK__paymentT__EC3BF50C999C8771");

                entity.ToTable("paymentType");

                entity.Property(e => e.IdPaymentType).HasColumnName("idPaymentType");

                entity.Property(e => e.PaymentTypeName)
                    .HasMaxLength(75)
                    .IsUnicode(false)
                    .HasColumnName("paymentTypeName");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.HasKey(e => e.IdState)
                    .HasName("PK__states__98CB37231FE181DF");

                entity.ToTable("states");

                entity.Property(e => e.IdState).HasColumnName("idState");

                entity.Property(e => e.IdCountry).HasColumnName("idCountry");

                entity.Property(e => e.StateName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("stateName");

                entity.HasOne(d => d.IdCountryNavigation)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.IdCountry)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__states__idCountr__267ABA7A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__users__3717C982AE73CA82");

                entity.ToTable("users");

                entity.Property(e => e.IdUser).HasColumnName("idUser");

                entity.Property(e => e.IdCustomers).HasColumnName("idCustomers");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("userName");

                entity.Property(e => e.UserPassword)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("userPassword");

                entity.Property(e => e.UserRole).HasColumnName("userRole");

                entity.HasOne(d => d.IdCustomersNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdCustomers)
                    .HasConstraintName("FK__users__idCustome__300424B4");

                entity.HasOne(d => d.UserRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__users__userRole__2F10007B");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.IdUserRole)
                    .HasName("PK__userRole__2E1B15A5B7978D5A");

                entity.ToTable("userRoles");

                entity.Property(e => e.IdUserRole).HasColumnName("idUserRole");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("roleName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
