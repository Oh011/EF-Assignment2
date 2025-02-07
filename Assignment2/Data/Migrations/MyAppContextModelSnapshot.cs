﻿// <auto-generated />
using System;
using Assignment2.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment2.Data.Migrations
{
    [DbContext(typeof(MyAppContext))]
    partial class MyAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment2.Data.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Description")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Top_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Top_Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.CourseInstructor", b =>
                {
                    b.Property<int>("Course_Id")
                        .HasColumnType("int");

                    b.Property<int>("Inst_Id")
                        .HasColumnType("int");

                    b.Property<decimal>("Evaluate")
                        .HasColumnType("Decimal(18,2)");

                    b.HasKey("Course_Id", "Inst_Id");

                    b.HasIndex("Inst_Id");

                    b.ToTable("CourseInstructor");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Department", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateOnly>("HiringDate")
                        .HasColumnType("date");

                    b.Property<int>("Ins_Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("Ins_Id")
                        .IsUnique();

                    b.ToTable("Department");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Bonus")
                        .HasColumnType("Decimal(18,3)");

                    b.Property<int>("Dept_Id")
                        .HasColumnType("int");

                    b.Property<double>("HourRate")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("Decimal(18,3)");

                    b.HasKey("Id");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Instructor");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<int?>("Dept_Id")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Dept_Id");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.StudentCourse", b =>
                {
                    b.Property<int>("Stud_Id")
                        .HasColumnType("int");

                    b.Property<int>("course_Id")
                        .HasColumnType("int");

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Stud_Id", "course_Id");

                    b.HasIndex("course_Id");

                    b.ToTable("StudentCourse");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Course", b =>
                {
                    b.HasOne("Assignment2.Data.Entities.Topic", "Topic")
                        .WithMany("Courses")
                        .HasForeignKey("Top_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.CourseInstructor", b =>
                {
                    b.HasOne("Assignment2.Data.Entities.Course", "Course")
                        .WithMany("courseInstructors")
                        .HasForeignKey("Course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2.Data.Entities.Instructor", "Instructor")
                        .WithMany("GivenCourses")
                        .HasForeignKey("Inst_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Department", b =>
                {
                    b.HasOne("Assignment2.Data.Entities.Instructor", "MangerInstructor")
                        .WithOne("MangerDepartment")
                        .HasForeignKey("Assignment2.Data.Entities.Department", "Ins_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("MangerInstructor");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Instructor", b =>
                {
                    b.HasOne("Assignment2.Data.Entities.Department", "WorkDepartment")
                        .WithMany("WorkingInstrctors")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.OwnsOne("Assignment2.Data.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("InstructorId")
                                .HasColumnType("int");

                            b1.Property<int?>("BlockNo")
                                .HasColumnType("int")
                                .HasColumnName("BlockNo");

                            b1.Property<int>("City")
                                .HasColumnType("int")
                                .HasColumnName("city");

                            b1.Property<int?>("Region")
                                .HasColumnType("int")
                                .HasColumnName("Region");

                            b1.HasKey("InstructorId");

                            b1.ToTable("Instructor");

                            b1.WithOwner()
                                .HasForeignKey("InstructorId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("WorkDepartment");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Student", b =>
                {
                    b.HasOne("Assignment2.Data.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("Dept_Id")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.OwnsOne("Assignment2.Data.Entities.Name", "Name", b1 =>
                        {
                            b1.Property<int>("StudentID")
                                .HasColumnType("int");

                            b1.Property<string>("Fname")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("Lname")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.HasKey("StudentID");

                            b1.ToTable("Student");

                            b1.WithOwner()
                                .HasForeignKey("StudentID");
                        });

                    b.OwnsOne("Assignment2.Data.Entities.Address", "Address", b1 =>
                        {
                            b1.Property<int>("StudentID")
                                .HasColumnType("int");

                            b1.Property<int?>("BlockNo")
                                .HasColumnType("int")
                                .HasColumnName("BlockNo");

                            b1.Property<int>("City")
                                .HasColumnType("int")
                                .HasColumnName("city");

                            b1.Property<int?>("Region")
                                .HasColumnType("int")
                                .HasColumnName("Region");

                            b1.HasKey("StudentID");

                            b1.ToTable("Student");

                            b1.WithOwner()
                                .HasForeignKey("StudentID");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment2.Data.Entities.StudentCourse", b =>
                {
                    b.HasOne("Assignment2.Data.Entities.Student", "Student")
                        .WithMany("Courses")
                        .HasForeignKey("Stud_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment2.Data.Entities.Course", "Course")
                        .WithMany("TakenCourses")
                        .HasForeignKey("course_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Course", b =>
                {
                    b.Navigation("TakenCourses");

                    b.Navigation("courseInstructors");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Department", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("WorkingInstrctors");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Instructor", b =>
                {
                    b.Navigation("GivenCourses");

                    b.Navigation("MangerDepartment");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Student", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("Assignment2.Data.Entities.Topic", b =>
                {
                    b.Navigation("Courses");
                });
#pragma warning restore 612, 618
        }
    }
}
