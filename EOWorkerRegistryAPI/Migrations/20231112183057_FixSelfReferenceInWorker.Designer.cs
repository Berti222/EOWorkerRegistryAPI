﻿// <auto-generated />
using System;
using EOWorkerRegistryAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EOWorkerRegistryAPI.Migrations
{
    [DbContext(typeof(WorkerRegisterContext))]
    [Migration("20231112183057_FixSelfReferenceInWorker")]
    partial class FixSelfReferenceInWorker
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EOWorkerRegistryAPI.Model.OrganizationalUnit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("OrganizationalUnits");
                });

            modelBuilder.Entity("EOWorkerRegistryAPI.Model.Worker", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrganizationalUnitId")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SuperiorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SuperiorId1")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationalUnitId");

                    b.HasIndex("SuperiorId");

                    b.HasIndex("SuperiorId1");

                    b.ToTable("Workers");
                });

            modelBuilder.Entity("EOWorkerRegistryAPI.Model.Worker", b =>
                {
                    b.HasOne("EOWorkerRegistryAPI.Model.OrganizationalUnit", "OrganizationalUnit")
                        .WithMany("Workers")
                        .HasForeignKey("OrganizationalUnitId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("EOWorkerRegistryAPI.Model.Worker", null)
                        .WithMany("Emploies")
                        .HasForeignKey("SuperiorId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("EOWorkerRegistryAPI.Model.Worker", "Superior")
                        .WithMany()
                        .HasForeignKey("SuperiorId1");

                    b.Navigation("OrganizationalUnit");

                    b.Navigation("Superior");
                });

            modelBuilder.Entity("EOWorkerRegistryAPI.Model.OrganizationalUnit", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("EOWorkerRegistryAPI.Model.Worker", b =>
                {
                    b.Navigation("Emploies");
                });
#pragma warning restore 612, 618
        }
    }
}
