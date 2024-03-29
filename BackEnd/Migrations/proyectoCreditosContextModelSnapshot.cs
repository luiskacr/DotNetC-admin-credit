﻿// <auto-generated />
using System;
using BackEnd.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEnd.Migrations
{
    [DbContext(typeof(proyectoCreditosContext))]
    partial class proyectoCreditosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BackEnd.Authentication.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("BackEnd.Entities.Country", b =>
                {
                    b.Property<int>("IdCountry")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCountry");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCountry"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("countryName");

                    b.HasKey("IdCountry")
                        .HasName("PK__countrie__8536480902BD26E8");

                    b.ToTable("countries", (string)null);
                });

            modelBuilder.Entity("BackEnd.Entities.Currency", b =>
                {
                    b.Property<int>("IdCurrencies")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCurrencies");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCurrencies"), 1L, 1);

                    b.Property<string>("CurrencyIso")
                        .IsRequired()
                        .HasMaxLength(5)
                        .IsUnicode(false)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("currencyISO");

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("currencyName");

                    b.HasKey("IdCurrencies")
                        .HasName("PK__currenci__937C33358DCE9719");

                    b.ToTable("currencies", (string)null);
                });

            modelBuilder.Entity("BackEnd.Entities.Customer", b =>
                {
                    b.Property<int>("IdCustomers")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idCustomers");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCustomers"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime")
                        .HasColumnName("birthDate");

                    b.Property<string>("DocumentId")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("documentId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("firstName");

                    b.Property<int>("IdState")
                        .HasColumnType("int")
                        .HasColumnName("idState");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .IsUnicode(false)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("lastName");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(25)
                        .IsUnicode(false)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("telephone");

                    b.Property<string>("UserAddress")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("userAddress");

                    b.HasKey("IdCustomers")
                        .HasName("PK__customer__D2815072D9FD6DA8");

                    b.HasIndex("IdState");

                    b.HasIndex(new[] { "DocumentId" }, "UQ__customer__EFAAAD846B292DF3")
                        .IsUnique();

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("BackEnd.Entities.Loan", b =>
                {
                    b.Property<int>("IdLoan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idLoan");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLoan"), 1L, 1);

                    b.Property<decimal>("BankFees")
                        .HasColumnType("money")
                        .HasColumnName("bankFees");

                    b.Property<decimal?>("CurrentAmount")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasColumnName("currentAmount")
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime")
                        .HasColumnName("endDate");

                    b.Property<int>("IdCurrencies")
                        .HasColumnType("int")
                        .HasColumnName("idCurrencies");

                    b.Property<int>("IdLoansState")
                        .HasColumnType("int")
                        .HasColumnName("idLoansState");

                    b.Property<int>("Idcustomers")
                        .HasColumnType("int")
                        .HasColumnName("idcustomers");

                    b.Property<int>("IdloansType")
                        .HasColumnType("int")
                        .HasColumnName("idloansType");

                    b.Property<decimal>("InteresRate")
                        .HasColumnType("decimal(9,6)")
                        .HasColumnName("interesRate");

                    b.Property<decimal>("LoanAmount")
                        .HasColumnType("money")
                        .HasColumnName("loanAmount");

                    b.Property<string>("LoansDescription")
                        .HasMaxLength(250)
                        .IsUnicode(false)
                        .HasColumnType("varchar(250)")
                        .HasColumnName("loansDescription");

                    b.Property<decimal>("MonthlyAmount")
                        .HasColumnType("money")
                        .HasColumnName("monthlyAmount");

                    b.Property<DateTime>("NextDueDate")
                        .HasColumnType("datetime")
                        .HasColumnName("nextDueDate");

                    b.Property<DateTime>("StarDate")
                        .HasColumnType("datetime")
                        .HasColumnName("starDate");

                    b.HasKey("IdLoan")
                        .HasName("PK__loans__1B9464CDA0FE3C6E");

                    b.HasIndex("IdCurrencies");

                    b.HasIndex("IdLoansState");

                    b.HasIndex("Idcustomers");

                    b.HasIndex("IdloansType");

                    b.ToTable("loans", (string)null);
                });

            modelBuilder.Entity("BackEnd.Entities.LoansHistory", b =>
                {
                    b.Property<int>("IdLoansHistory")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idLoansHistory");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLoansHistory"), 1L, 1);

                    b.Property<int>("LoadId")
                        .HasColumnType("int")
                        .HasColumnName("loadId");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime")
                        .HasColumnName("payDate");

                    b.Property<decimal>("PaymentAmount")
                        .HasColumnType("money")
                        .HasColumnName("paymentAmount");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int")
                        .HasColumnName("paymentType");

                    b.HasKey("IdLoansHistory")
                        .HasName("PK__loansHis__1CA1D5C4536F1AE0");

                    b.HasIndex("LoadId");

                    b.HasIndex("PaymentType");

                    b.ToTable("loansHistories", (string)null);
                });

            modelBuilder.Entity("BackEnd.Entities.LoansState", b =>
                {
                    b.Property<int>("LoansStatesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("loansStatesId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoansStatesId"), 1L, 1);

                    b.Property<string>("LoansStateName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("loansStateName");

                    b.HasKey("LoansStatesId")
                        .HasName("PK__loansSta__14BED58B42694273");

                    b.ToTable("loansStates", (string)null);
                });

            modelBuilder.Entity("BackEnd.Entities.LoansType", b =>
                {
                    b.Property<int>("IdloansType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idloansType");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdloansType"), 1L, 1);

                    b.Property<string>("LoansTypeName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("loansTypeName");

                    b.HasKey("IdloansType")
                        .HasName("PK__loansTyp__BC3185C6EFEBC25A");

                    b.ToTable("loansType", (string)null);
                });

            modelBuilder.Entity("BackEnd.Entities.PaymentType", b =>
                {
                    b.Property<int>("IdPaymentType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idPaymentType");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPaymentType"), 1L, 1);

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasMaxLength(75)
                        .IsUnicode(false)
                        .HasColumnType("varchar(75)")
                        .HasColumnName("paymentTypeName");

                    b.HasKey("IdPaymentType")
                        .HasName("PK__paymentT__EC3BF50C999C8771");

                    b.ToTable("paymentType", (string)null);
                });

            modelBuilder.Entity("BackEnd.Entities.State", b =>
                {
                    b.Property<int>("IdState")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("idState");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdState"), 1L, 1);

                    b.Property<int>("IdCountry")
                        .HasColumnType("int")
                        .HasColumnName("idCountry");

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("stateName");

                    b.HasKey("IdState")
                        .HasName("PK__states__98CB37231FE181DF");

                    b.HasIndex("IdCountry");

                    b.ToTable("states", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BackEnd.Entities.Customer", b =>
                {
                    b.HasOne("BackEnd.Entities.State", "IdStateNavigation")
                        .WithMany("Customers")
                        .HasForeignKey("IdState")
                        .IsRequired()
                        .HasConstraintName("FK__customers__idSta__2A4B4B5E");

                    b.Navigation("IdStateNavigation");
                });

            modelBuilder.Entity("BackEnd.Entities.Loan", b =>
                {
                    b.HasOne("BackEnd.Entities.Currency", "IdCurrenciesNavigation")
                        .WithMany("Loans")
                        .HasForeignKey("IdCurrencies")
                        .IsRequired()
                        .HasConstraintName("FK__loans__idCurrenc__3B75D760");

                    b.HasOne("BackEnd.Entities.LoansState", "IdLoansStateNavigation")
                        .WithMany("Loans")
                        .HasForeignKey("IdLoansState")
                        .IsRequired()
                        .HasConstraintName("FK__loans__idLoansSt__3C69FB99");

                    b.HasOne("BackEnd.Entities.Customer", "IdcustomersNavigation")
                        .WithMany("Loans")
                        .HasForeignKey("Idcustomers")
                        .IsRequired()
                        .HasConstraintName("FK__loans__idcustome__38996AB5");

                    b.HasOne("BackEnd.Entities.LoansType", "IdloansTypeNavigation")
                        .WithMany("Loans")
                        .HasForeignKey("IdloansType")
                        .IsRequired()
                        .HasConstraintName("FK__loans__idloansTy__3A81B327");

                    b.Navigation("IdCurrenciesNavigation");

                    b.Navigation("IdLoansStateNavigation");

                    b.Navigation("IdcustomersNavigation");

                    b.Navigation("IdloansTypeNavigation");
                });

            modelBuilder.Entity("BackEnd.Entities.LoansHistory", b =>
                {
                    b.HasOne("BackEnd.Entities.Loan", "Load")
                        .WithMany("LoansHistories")
                        .HasForeignKey("LoadId")
                        .IsRequired()
                        .HasConstraintName("FK__loansHist__loadI__412EB0B6");

                    b.HasOne("BackEnd.Entities.PaymentType", "PaymentTypeNavigation")
                        .WithMany("LoansHistories")
                        .HasForeignKey("PaymentType")
                        .IsRequired()
                        .HasConstraintName("FK__loansHist__payme__4222D4EF");

                    b.Navigation("Load");

                    b.Navigation("PaymentTypeNavigation");
                });

            modelBuilder.Entity("BackEnd.Entities.State", b =>
                {
                    b.HasOne("BackEnd.Entities.Country", "IdCountryNavigation")
                        .WithMany("States")
                        .HasForeignKey("IdCountry")
                        .IsRequired()
                        .HasConstraintName("FK__states__idCountr__267ABA7A");

                    b.Navigation("IdCountryNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BackEnd.Authentication.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BackEnd.Authentication.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Authentication.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BackEnd.Authentication.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEnd.Entities.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("BackEnd.Entities.Currency", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("BackEnd.Entities.Customer", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("BackEnd.Entities.Loan", b =>
                {
                    b.Navigation("LoansHistories");
                });

            modelBuilder.Entity("BackEnd.Entities.LoansState", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("BackEnd.Entities.LoansType", b =>
                {
                    b.Navigation("Loans");
                });

            modelBuilder.Entity("BackEnd.Entities.PaymentType", b =>
                {
                    b.Navigation("LoansHistories");
                });

            modelBuilder.Entity("BackEnd.Entities.State", b =>
                {
                    b.Navigation("Customers");
                });
#pragma warning restore 612, 618
        }
    }
}
