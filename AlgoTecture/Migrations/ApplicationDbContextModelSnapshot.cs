﻿// <auto-generated />
using System;
using AlgoTecture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlgoTecture.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("AlgoTecture.Models.Entities.TypeOfSpace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TypeOfSpaces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Public buildings and structures"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Residential buildings"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Industrial buildings and structures"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Buildings and structures intended for the needs of agriculture"
                        });
                });

            modelBuilder.Entity("AlgoTecture.Models.Entities.UtilizationType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UtilizationTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Residential"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Сommercial"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Production"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Warehouse"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Public catering"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Utility"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Office space"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Education"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Free target"
                        });
                });

            modelBuilder.Entity("AlgoTecture.Models.RepositoryModels.Contract", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ContractDateStart")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ContractDateStop")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ContractDateTime")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DeclarationDateTime")
                        .HasColumnType("TEXT");

                    b.Property<long>("OwnerUserId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("SpaceId")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SubSpaceId")
                        .HasColumnType("TEXT");

                    b.Property<long?>("TenantUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UtilizationTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("OwnerUserId");

                    b.HasIndex("SpaceId");

                    b.HasIndex("TenantUserId");

                    b.HasIndex("UtilizationTypeId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("AlgoTecture.Models.RepositoryModels.Space", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<string>("SpaceAddress")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("SpaceProperty")
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeOfSpaceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Latitude");

                    b.HasIndex("Longitude");

                    b.HasIndex("TypeOfSpaceId");

                    b.ToTable("Spaces");
                });

            modelBuilder.Entity("AlgoTecture.Models.RepositoryModels.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AlgoTecture.Models.RepositoryModels.UserAuthentication", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HashedPassword")
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<long>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserAuthentications");
                });

            modelBuilder.Entity("AlgoTecture.Models.RepositoryModels.Contract", b =>
                {
                    b.HasOne("AlgoTecture.Models.RepositoryModels.User", "OwnerUser")
                        .WithMany()
                        .HasForeignKey("OwnerUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlgoTecture.Models.RepositoryModels.Space", "Space")
                        .WithMany()
                        .HasForeignKey("SpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AlgoTecture.Models.RepositoryModels.User", "TenantUser")
                        .WithMany()
                        .HasForeignKey("TenantUserId");

                    b.HasOne("AlgoTecture.Models.Entities.UtilizationType", "UtilizationType")
                        .WithMany()
                        .HasForeignKey("UtilizationTypeId");

                    b.Navigation("OwnerUser");

                    b.Navigation("Space");

                    b.Navigation("TenantUser");

                    b.Navigation("UtilizationType");
                });

            modelBuilder.Entity("AlgoTecture.Models.RepositoryModels.Space", b =>
                {
                    b.HasOne("AlgoTecture.Models.Entities.TypeOfSpace", "TypeOfSpace")
                        .WithMany()
                        .HasForeignKey("TypeOfSpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOfSpace");
                });

            modelBuilder.Entity("AlgoTecture.Models.RepositoryModels.UserAuthentication", b =>
                {
                    b.HasOne("AlgoTecture.Models.RepositoryModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
