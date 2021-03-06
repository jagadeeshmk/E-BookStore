﻿// <auto-generated />
using System;
using EBookStore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EBookStore.Persistence.Migrations
{
    [DbContext(typeof(EBookStoreDbContext))]
    [Migration("20200207071220_IntialMigration")]
    partial class IntialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("bs")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("Relational:Sequence:.auto_increment", "'auto_increment', '', '1', '1', '', '', 'Int64', 'False'");

            modelBuilder.Entity("EBookStore.Persistence.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("nextval('bs.auto_increment')");

                    b.Property<string>("AuthorName");

                    b.Property<decimal>("Cost");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("PublishedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(now() at time zone 'utc')");

                    b.Property<int>("Stock");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("EBookStore.Persistence.Models.PurchasedBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("nextval('bs.auto_increment')");

                    b.Property<int>("BookId");

                    b.Property<int>("Count");

                    b.Property<string>("PaymentMode");

                    b.Property<DateTime>("PurchasedOn")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(now() at time zone 'utc')");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("PurchasedBook");
                });

            modelBuilder.Entity("EBookStore.Persistence.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("nextval('bs.auto_increment')");

                    b.Property<string>("Email");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EBookStore.Persistence.Models.PurchasedBook", b =>
                {
                    b.HasOne("EBookStore.Persistence.Models.Book", "Book")
                        .WithMany("PurchasedBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EBookStore.Persistence.Models.User", "User")
                        .WithMany("PurchasedBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
