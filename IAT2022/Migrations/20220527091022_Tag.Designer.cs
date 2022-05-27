﻿// <auto-generated />
using System;
using IAT2022.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IAT2022.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220527091022_Tag")]
    partial class Tag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("IAT2022.Data.Poco.BusinessPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("int");

                    b.Property<bool>("Result")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("BusinessPoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.CustomerPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("int");

                    b.Property<bool>("Result")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("CustomerValue");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Created")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectTagsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectTags");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.BusinessQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BuisnessQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.CustomerQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomerQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.FinanceQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FinanceQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.IprQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IPRQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.ProductQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.TeamQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TeamQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.FinancePoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("int");

                    b.Property<bool>("Result")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("FinancePoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.IPRPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("int");

                    b.Property<bool>("Result")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("IPRPoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.ProductPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("int");

                    b.Property<bool>("Result")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("ProductPoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.TagPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("TagPoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.TeamPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("int");

                    b.Property<bool>("Result")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("TeamPoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.BusinessPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Business")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.CustomerPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Customer")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.FinancePoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Finance")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.IPRPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("IPR")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.ProductPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Product")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.TagPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Tags")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.TeamPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Team")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectPoco", b =>
                {
                    b.Navigation("Business");

                    b.Navigation("Customer");

                    b.Navigation("Finance");

                    b.Navigation("IPR");

                    b.Navigation("Product");

                    b.Navigation("Tags");

                    b.Navigation("Team");
                });
#pragma warning restore 612, 618
        }
    }
}
