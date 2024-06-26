﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp.Infrastructure.Contexts;

#nullable disable

namespace WebApp.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240409142154_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WebApp.Domain.PlayerAggregate.Entities.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Relational:JsonPropertyName", "id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()")
                        .HasAnnotation("Relational:JsonPropertyName", "createdAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasAnnotation("Relational:JsonPropertyName", "email");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasAnnotation("Relational:JsonPropertyName", "updatedAt");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("WebApp.Domain.PlayerAggregate.Entities.Player", b =>
                {
                    b.OwnsOne("WebApp.Domain.PlayerAggregate.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<long>("PlayerId")
                                .HasColumnType("bigint");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("City")
                                .HasAnnotation("Relational:JsonPropertyName", "city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Country")
                                .HasAnnotation("Relational:JsonPropertyName", "country");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("Street")
                                .HasAnnotation("Relational:JsonPropertyName", "street");

                            b1.Property<string>("ZipCode")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("ZipCode")
                                .HasAnnotation("Relational:JsonPropertyName", "zipCode");

                            b1.HasKey("PlayerId");

                            b1.ToTable("Players");

                            b1.HasAnnotation("Relational:JsonPropertyName", "address");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.OwnsOne("WebApp.Domain.PlayerAggregate.ValueObjects.FullName", "Name", b1 =>
                        {
                            b1.Property<long>("PlayerId")
                                .HasColumnType("bigint");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("FirstName")
                                .HasAnnotation("Relational:JsonPropertyName", "firstName");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("LastName")
                                .HasAnnotation("Relational:JsonPropertyName", "lastName");

                            b1.HasKey("PlayerId");

                            b1.ToTable("Players");

                            b1.HasAnnotation("Relational:JsonPropertyName", "name");

                            b1.WithOwner()
                                .HasForeignKey("PlayerId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
