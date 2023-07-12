﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TCM.Infrastructure.Contexts;

#nullable disable

namespace TCM.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230710154416_DB Initialize")]
    partial class DBInitialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TCM.Core.Entities.TrainComponent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("CanAssignQuantity")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UniqueNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TrainComponents");
                });

            modelBuilder.Entity("TrainComponentRelations", b =>
                {
                    b.Property<int>("ChildrenId")
                        .HasColumnType("int");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("ChildrenId", "ParentId");

                    b.HasIndex("ParentId");

                    b.ToTable("TrainComponentRelations");
                });

            modelBuilder.Entity("TrainComponentRelations", b =>
                {
                    b.HasOne("TCM.Core.Entities.TrainComponent", null)
                        .WithMany()
                        .HasForeignKey("ChildrenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TCM.Core.Entities.TrainComponent", null)
                        .WithMany()
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}