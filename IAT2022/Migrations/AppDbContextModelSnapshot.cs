﻿// <auto-generated />
using System;
using IAT2022.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IAT2022.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.3");

            modelBuilder.Entity("IAT2022.Data.Poco.BusinessPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Result")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("BusinessPoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.CommentPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("CommentPoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.CustomerPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Result")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("CustomerValue");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BusinessComment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerComment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("FinanceComment")
                        .HasColumnType("TEXT");

                    b.Property<string>("IPRComment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Owner")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductComment")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectType")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamComment")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectTagsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("ProjectTags");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.BusinessQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BuisnessQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.CustomerQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CustomerQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.FinanceQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("FinanceQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.IprQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("IPRQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.ProductQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProductQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.TeamQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("QuestionDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TeamQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.FinancePoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Result")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("FinancePoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.IPRPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Result")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("IPRPoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.ProductPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Result")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProjectPocoId");

                    b.ToTable("ProductPoco");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.TeamPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ProjectPocoId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Result")
                        .HasColumnType("INTEGER");

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

            modelBuilder.Entity("IAT2022.Data.Poco.CommentPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Comments")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.CustomerPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Customer")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectTagsPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Tags")
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

            modelBuilder.Entity("IAT2022.Data.Poco.SubCategoryPoco.TeamPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Team")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectPoco", b =>
                {
                    b.Navigation("Business");

                    b.Navigation("Comments");

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
