// <auto-generated />
using System;
using EmployeeDepartmentProject.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeDepartmentProject.DataAccess.Migrations
{
    [DbContext(typeof(EmployeeDepartmentDbContext))]
    [Migration("20221128123250_Intial Migration")]
    partial class IntialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeDepartmentProject.Models.Department", b =>
                {
                    b.Property<int>("DepartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartID"));

                    b.Property<string>("DepartName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmployeeDepartmentProject.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<int?>("DepartID")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<float>("EmployeeSalary")
                        .HasColumnType("real");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeDepartmentProject.Models.Employee", b =>
                {
                    b.HasOne("EmployeeDepartmentProject.Models.Department", "Departments")
                        .WithMany()
                        .HasForeignKey("DepartID");

                    b.Navigation("Departments");
                });
#pragma warning restore 612, 618
        }
    }
}
