﻿// <auto-generated />
using System;
using IAT2022.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IAT2022.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220412065456_asssssd")]
    partial class asssssd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectPoco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Buissness")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Customer")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Finance")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("IPR")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Owner")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Product")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjectName")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProjectType")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Team")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.CommentPoco", b =>
                {
                    b.HasOne("IAT2022.Data.Poco.ProjectPoco", null)
                        .WithMany("Comments")
                        .HasForeignKey("ProjectPocoId");
                });

            modelBuilder.Entity("IAT2022.Data.Poco.ProjectPoco", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
