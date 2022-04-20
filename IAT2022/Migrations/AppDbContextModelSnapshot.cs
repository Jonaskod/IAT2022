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

                    b.Property<bool>("K1")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("K2")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("K3")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("K4")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("K5")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("K6")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("K7")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("K8")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("K9")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CustomerValue");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Buissness")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Finance")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IPR")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("K1TEST")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Owner")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Product")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("TagsBoolId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Team")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TagsBoolId");

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

            modelBuilder.Entity("IAT2022.Data.Poco.QuestionsPoco.CustomerQuestionsPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("K1")
                        .HasColumnType("TEXT");

                    b.Property<string>("K2")
                        .HasColumnType("TEXT");

                    b.Property<string>("K3")
                        .HasColumnType("TEXT");

                    b.Property<string>("K4")
                        .HasColumnType("TEXT");

                    b.Property<string>("K5a")
                        .HasColumnType("TEXT");

                    b.Property<string>("K5b")
                        .HasColumnType("TEXT");

                    b.Property<string>("K6a")
                        .HasColumnType("TEXT");

                    b.Property<string>("K6b")
                        .HasColumnType("TEXT");

                    b.Property<string>("K7a")
                        .HasColumnType("TEXT");

                    b.Property<string>("K7b")
                        .HasColumnType("TEXT");

                    b.Property<string>("K8a")
                        .HasColumnType("TEXT");

                    b.Property<string>("K8b")
                        .HasColumnType("TEXT");

                    b.Property<string>("K9")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CustomerQuestions");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.TagsBool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Tag1")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Tag2")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Tag3")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Tag4")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Tag5")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("TagsBool");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.CommentPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Comments")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.CustomerPoco", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");

                    b.HasOne("IAT2022.Data.Poco.TagsBool", "TagsBool")
                        .WithMany()
                        .HasForeignKey("TagsBoolId");

                    b.Navigation("Customer");

                    b.Navigation("TagsBool");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectTagsPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Tags")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectPoco", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
