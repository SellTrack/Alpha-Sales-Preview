﻿// <auto-generated />
using System;
using AlphaSales.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AlphaSales.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlphaSales.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Client_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Client_Owner_ID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Client_QC_Caller_ID")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnOrder(3);

                    b.Property<string>("Client_QC_Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Client_insert_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Client_order_number")
                        .HasColumnType("int");

                    b.Property<string>("Client_pdf_file_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Client_status")
                        .HasColumnType("int");

                    b.Property<string>("Client_tariff_type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Corporation_ID")
                        .HasColumnType("int");

                    b.HasKey("ClientID");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("Client_Owner_ID");

                    b.HasIndex("Client_QC_Caller_ID");

                    b.HasIndex("Corporation_ID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("AlphaSales.Models.Corporation", b =>
                {
                    b.Property<int>("CorporationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CorporationID"));

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SuccessfulSales")
                        .HasColumnType("int");

                    b.Property<int>("TotalSales")
                        .HasColumnType("int");

                    b.Property<int>("UnsuccessfulSales")
                        .HasColumnType("int");

                    b.HasKey("CorporationID");

                    b.ToTable("Corporations");

                    b.HasData(
                        new
                        {
                            CorporationID = 1,
                            Adress = "AA",
                            City = "Amasya",
                            MemberCount = 0,
                            Name = "Alpha",
                            SuccessfulSales = 0,
                            TotalSales = 0,
                            UnsuccessfulSales = 0
                        },
                        new
                        {
                            CorporationID = 2,
                            Adress = "bb",
                            City = "Akasya",
                            MemberCount = 0,
                            Name = "Beta",
                            SuccessfulSales = 0,
                            TotalSales = 0,
                            UnsuccessfulSales = 0
                        },
                        new
                        {
                            CorporationID = 3,
                            Adress = "cc",
                            City = "Alaçam",
                            MemberCount = 0,
                            Name = "Charlie",
                            SuccessfulSales = 0,
                            TotalSales = 0,
                            UnsuccessfulSales = 0
                        });
                });

            modelBuilder.Entity("AlphaSales.Models.Employee", b =>
                {
                    b.Property<int>("Employee_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Employee_ID"));

                    b.Property<string>("Corporation_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Declined_Client_Number")
                        .HasColumnType("int");

                    b.Property<int>("Successful_QCs")
                        .HasColumnType("int");

                    b.Property<int>("Total_Client_Number")
                        .HasColumnType("int");

                    b.Property<int>("Total_QCs")
                        .HasColumnType("int");

                    b.Property<int>("Unsuccessful_QCs")
                        .HasColumnType("int");

                    b.Property<string>("User_ID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Verified_Client_Number")
                        .HasColumnType("int");

                    b.HasKey("Employee_ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("AlphaSales.Models.LanguagePack", b =>
                {
                    b.Property<int>("Word_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Word_ID"));

                    b.Property<string>("DE")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("EN")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("TR")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Word_ID");

                    b.ToTable("LanguagePacks");
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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("AlphaSales.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int?>("CorporationID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("Declined_Client_Number")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Successful_QCs")
                        .HasColumnType("int");

                    b.Property<int>("Total_Client_Number")
                        .HasColumnType("int");

                    b.Property<int>("Total_QCs")
                        .HasColumnType("int");

                    b.Property<int>("Unsuccessful_QCs")
                        .HasColumnType("int");

                    b.Property<int>("Verified_Client_Number")
                        .HasColumnType("int");

                    b.HasIndex("CorporationID");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("AlphaSales.Models.Client", b =>
                {
                    b.HasOne("AlphaSales.Models.ApplicationUser", null)
                        .WithMany("Clients")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("AlphaSales.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("Client_Owner_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AlphaSales.Models.ApplicationUser", "ApplicationUser2")
                        .WithMany()
                        .HasForeignKey("Client_QC_Caller_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("AlphaSales.Models.Corporation", "Corporation")
                        .WithMany()
                        .HasForeignKey("Corporation_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("ApplicationUser2");

                    b.Navigation("Corporation");
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
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
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

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AlphaSales.Models.ApplicationUser", b =>
                {
                    b.HasOne("AlphaSales.Models.Corporation", "Corporation")
                        .WithMany()
                        .HasForeignKey("CorporationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Corporation");
                });

            modelBuilder.Entity("AlphaSales.Models.ApplicationUser", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
