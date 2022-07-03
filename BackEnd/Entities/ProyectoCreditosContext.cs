using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEnd.Entities
{
    public partial class ProyectoCreditosContext : DbContext
    {
        public ProyectoCreditosContext()
        {
        }

        public ProyectoCreditosContext(DbContextOptions<ProyectoCreditosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Corrency> Correncys { get; set; } = null!;
        public virtual DbSet<CustomOrderList> CustomOrderLists { get; set; } = null!;
        public virtual DbSet<DebtSnowball> DebtSnowballs { get; set; } = null!;
        public virtual DbSet<Loan> Loans { get; set; } = null!;
        public virtual DbSet<LoansState> LoansStates { get; set; } = null!;
        public virtual DbSet<PayOffStragedy> PayOffStragedies { get; set; } = null!;
        public virtual DbSet<PaymentHistory> PaymentHistories { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-IAUA4D6\\SQLEXPRESS;Database=ProyectoCreditos;Integrated Security=True;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Corrency>(entity =>
            {
                entity.Property(e => e.CorrencyId)
                    .ValueGeneratedNever()
                    .HasColumnName("CorrencyID");

                entity.Property(e => e.CorrencyName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomOrderList>(entity =>
            {
                entity.ToTable("CustomOrderList");

                entity.Property(e => e.CustomOrderListId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomOrderListID");

                entity.Property(e => e._01customOrderPosition).HasColumnName("01CustomOrderPosition");

                entity.Property(e => e._02customOrderPosition).HasColumnName("02CustomOrderPosition");

                entity.Property(e => e._03customOrderPosition).HasColumnName("03CustomOrderPosition");

                entity.Property(e => e._04customOrderPosition).HasColumnName("04CustomOrderPosition");

                entity.Property(e => e._05customOrderPosition).HasColumnName("05CustomOrderPosition");

                entity.Property(e => e._06customOrderPosition).HasColumnName("06CustomOrderPosition");

                entity.Property(e => e._07customOrderPosition).HasColumnName("07CustomOrderPosition");

                entity.Property(e => e._08customOrderPosition).HasColumnName("08CustomOrderPosition");

                entity.Property(e => e._09customOrderPosition).HasColumnName("09CustomOrderPosition");

                entity.Property(e => e._10customOrderPosition).HasColumnName("10CustomOrderPosition");

                entity.HasOne(d => d._01customOrderPositionNavigation)
                    .WithMany(p => p.CustomOrderList_01customOrderPositionNavigations)
                    .HasForeignKey(d => d._01customOrderPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrderList_01CustomOrderPosition");

                entity.HasOne(d => d._02customOrderPositionNavigation)
                    .WithMany(p => p.CustomOrderList_02customOrderPositionNavigations)
                    .HasForeignKey(d => d._02customOrderPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrderList_02CustomOrderPosition");

                entity.HasOne(d => d._03customOrderPositionNavigation)
                    .WithMany(p => p.CustomOrderList_03customOrderPositionNavigations)
                    .HasForeignKey(d => d._03customOrderPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrderList_03CustomOrderPosition");

                entity.HasOne(d => d._04customOrderPositionNavigation)
                    .WithMany(p => p.CustomOrderList_04customOrderPositionNavigations)
                    .HasForeignKey(d => d._04customOrderPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrderList_04CustomOrderPosition");

                entity.HasOne(d => d._05customOrderPositionNavigation)
                    .WithMany(p => p.CustomOrderList_05customOrderPositionNavigations)
                    .HasForeignKey(d => d._05customOrderPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrderList_05CustomOrderPosition");

                entity.HasOne(d => d._06customOrderPositionNavigation)
                    .WithMany(p => p.CustomOrderList_06customOrderPositionNavigations)
                    .HasForeignKey(d => d._06customOrderPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrderList_06CustomOrderPosition");

                entity.HasOne(d => d._07customOrderPositionNavigation)
                    .WithMany(p => p.CustomOrderList_07customOrderPositionNavigations)
                    .HasForeignKey(d => d._07customOrderPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrderList_07CustomOrderPosition");

                entity.HasOne(d => d._08customOrderPositionNavigation)
                    .WithMany(p => p.CustomOrderList_08customOrderPositionNavigations)
                    .HasForeignKey(d => d._08customOrderPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrderList_08CustomOrderPosition");

                entity.HasOne(d => d._09customOrderPositionNavigation)
                    .WithMany(p => p.CustomOrderList_09customOrderPositionNavigations)
                    .HasForeignKey(d => d._09customOrderPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrderList_09CustomOrderPosition");

                entity.HasOne(d => d._10customOrderPositionNavigation)
                    .WithMany(p => p.CustomOrderList_10customOrderPositionNavigations)
                    .HasForeignKey(d => d._10customOrderPosition)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustomOrderList_10CustomOrderPosition");
            });

            modelBuilder.Entity<DebtSnowball>(entity =>
            {
                entity.ToTable("DebtSnowball");

                entity.Property(e => e.DebtSnowballId)
                    .ValueGeneratedNever()
                    .HasColumnName("DebtSnowballID");

                entity.Property(e => e.CustomOrderListId).HasColumnName("CustomOrderListID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.CustomOrderList)
                    .WithMany(p => p.DebtSnowballs)
                    .HasForeignKey(d => d.CustomOrderListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebtSnowball_CustomOrderListID");

                entity.HasOne(d => d.PayOffOrderNavigation)
                    .WithMany(p => p.DebtSnowballs)
                    .HasForeignKey(d => d.PayOffOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebtSnowball_PayOffOrder");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DebtSnowballs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DebtSnowball_UserID");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.HasKey(e => e.LoansId);

                entity.ToTable("loans");

                entity.Property(e => e.LoansId)
                    .ValueGeneratedNever()
                    .HasColumnName("LoansID");

                entity.Property(e => e.BankFees).HasColumnType("money");

                entity.Property(e => e.CorrencyId).HasColumnName("CorrencyID");

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.LoanAmount)
                    .HasColumnType("money")
                    .HasColumnName("loanAmount");

                entity.Property(e => e.MontlyPayment).HasColumnType("money");

                entity.Property(e => e.NextDueDate)
                    .HasColumnType("datetime")
                    .HasColumnName("nextDueDate");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Corrency)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.CorrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_loans_CorrencyID");

                entity.HasOne(d => d.LoansStates)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.LoansStatesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_loans_LoansStatesId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_loans_UserID");
            });

            modelBuilder.Entity<LoansState>(entity =>
            {
                entity.HasKey(e => e.LoansStatesId);

                entity.Property(e => e.LoansStatesId).ValueGeneratedNever();

                entity.Property(e => e.LoansStateName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("loansStateName");
            });

            modelBuilder.Entity<PayOffStragedy>(entity =>
            {
                entity.HasKey(e => e.PayOffOrderId);

                entity.ToTable("PayOffStragedy");

                entity.Property(e => e.PayOffOrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("PayOffOrderID");

                entity.Property(e => e.StragedyName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentHistory>(entity =>
            {
                entity.HasKey(e => e.PaymentId);

                entity.ToTable("PaymentHistory");

                entity.Property(e => e.PaymentId).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.DatePayed).HasColumnType("datetime");

                entity.Property(e => e.LoadId).HasColumnName("loadId");

                entity.HasOne(d => d.Load)
                    .WithMany(p => p.PaymentHistories)
                    .HasForeignKey(d => d.LoadId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentHistory_loadId");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("UserID");

                entity.Property(e => e.Adddress)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Paassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.UserRolesNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoles)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_UserRoles");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.IduserRoles);

                entity.Property(e => e.IduserRoles)
                    .ValueGeneratedNever()
                    .HasColumnName("IDUserRoles");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
