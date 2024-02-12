﻿// <auto-generated />
using System;
using BankApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankApp.Data.Migrations
{
    [DbContext(typeof(BankAppContext))]
    partial class BankAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BankApp.Models.BankAccount", b =>
                {
                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Number");

                    b.ToTable("BankAccounts");

                    b.HasData(
                        new
                        {
                            Number = "1234567890",
                            Owner = "John Doe"
                        },
                        new
                        {
                            Number = "0987654321",
                            Owner = "Jane Doe"
                        });
                });

            modelBuilder.Entity("BankApp.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("BankAccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionId");

                    b.HasIndex("BankAccountId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            Amount = 200.00m,
                            BankAccountId = "1234567890",
                            Date = new DateTime(2021, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified),
                            Note = "Deposito inicial"
                        },
                        new
                        {
                            TransactionId = 2,
                            Amount = 300.00m,
                            BankAccountId = "1234567890",
                            Date = new DateTime(2021, 1, 2, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Note = "Deposito"
                        },
                        new
                        {
                            TransactionId = 3,
                            Amount = -150.00m,
                            BankAccountId = "1234567890",
                            Date = new DateTime(2021, 1, 3, 9, 30, 0, 0, DateTimeKind.Unspecified),
                            Note = "Retiro"
                        },
                        new
                        {
                            TransactionId = 4,
                            Amount = 400.00m,
                            BankAccountId = "0987654321",
                            Date = new DateTime(2021, 1, 4, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Note = "Deposito"
                        });
                });

            modelBuilder.Entity("BankApp.Models.Transaction", b =>
                {
                    b.HasOne("BankApp.Models.BankAccount", "BankAccount")
                        .WithMany("transactions")
                        .HasForeignKey("BankAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("BankApp.Models.BankAccount", b =>
                {
                    b.Navigation("transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
