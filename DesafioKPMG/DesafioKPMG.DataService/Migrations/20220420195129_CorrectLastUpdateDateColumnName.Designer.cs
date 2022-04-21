﻿// <auto-generated />
using System;
using DesafioKPMG.DataService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DesafioKPMG.DataService.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220420195129_CorrectLastUpdateDateColumnName")]
    partial class CorrectLastUpdateDateColumnName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DesafioKPMG.Entities.Models.GameResult", b =>
                {
                    b.Property<long>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("GameId"), 1L, 1);

                    b.Property<long>("PlayerId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<long>("Win")
                        .HasColumnType("bigint");

                    b.HasKey("GameId");

                    b.HasIndex("PlayerId");

                    b.ToTable("GameResults");
                });

            modelBuilder.Entity("DesafioKPMG.Entities.Models.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<long>("Balance")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("DesafioKPMG.Entities.Models.GameResult", b =>
                {
                    b.HasOne("DesafioKPMG.Entities.Models.Player", null)
                        .WithMany("GameResults")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DesafioKPMG.Entities.Models.Player", b =>
                {
                    b.Navigation("GameResults");
                });
#pragma warning restore 612, 618
        }
    }
}
