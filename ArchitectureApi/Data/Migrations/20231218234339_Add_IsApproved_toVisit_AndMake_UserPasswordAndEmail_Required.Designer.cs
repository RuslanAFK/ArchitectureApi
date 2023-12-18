﻿// <auto-generated />
using System;
using ArchitectureApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArchitectureApi.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231218234339_Add_IsApproved_toVisit_AndMake_UserPasswordAndEmail_Required")]
    partial class Add_IsApproved_toVisit_AndMake_UserPasswordAndEmail_Required
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ArchitectureApi.Data.Models.Visit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Treatment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Visits");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Approved = false,
                            Notes = "Болить горло",
                            Time = new DateTime(2023, 12, 28, 12, 0, 0, 0, DateTimeKind.Unspecified),
                            Treatment = "Прополоскати горло"
                        },
                        new
                        {
                            Id = 3,
                            Approved = false,
                            Notes = "Болить живіт",
                            Time = new DateTime(2023, 12, 28, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Treatment = "Випити ліки від болю в животі"
                        });
                });

            modelBuilder.Entity("ArchitectureApi.Models.TimeSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("TimeSlots");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DoctorId = 2,
                            From = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            To = new DateTime(2024, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            DoctorId = 3,
                            From = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            To = new DateTime(2024, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            DoctorId = 4,
                            From = new DateTime(2024, 1, 1, 8, 0, 0, 0, DateTimeKind.Unspecified),
                            To = new DateTime(2024, 1, 1, 18, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("ArchitectureApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoctorType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Львів, вул. Жовківська, 39",
                            Email = "ruslan_p@gmail.com",
                            FirstName = "Руслан",
                            LastName = "Ігорович",
                            Password = "RuslanPass",
                            Phone = "095-655-65-89",
                            PhotoFile = "https://img.freepik.com/free-photo/smiley-man-relaxing-outdoors_23-2148739334.jpg?w=360&t=st=1702807538~exp=1702808138~hmac=e4d0e9393c54c1ee1bd095ec5661699ca013cdb7205b4753ec46e0ecea406956",
                            Role = "Patient",
                            SecondName = "Пундак"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Львів, вул. Київська, 49",
                            DoctorType = "Стоматолог",
                            Email = "papa@gmail.com",
                            FirstName = "Папа",
                            LastName = "Батьковтч",
                            Password = "DoctorPass",
                            Phone = "097-586-55-25",
                            PhotoFile = "https://professions.ng/wp-content/uploads/2023/07/The-Process-of-Becoming-a-Doctor-in-Nigeria-A-Roadmap2-768x768.jpg",
                            Role = "Doctor",
                            SecondName = "Пйотр"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Львів, вул. Луганська, 77",
                            DoctorType = "Стоматолог",
                            Email = "yukarp@gmail.com",
                            FirstName = "Карпінець",
                            LastName = "Батькович",
                            Password = "DoctorPass",
                            Phone = "097-785-55-25",
                            PhotoFile = "https://hips.hearstapps.com/hmg-prod/images/portrait-of-a-happy-young-doctor-in-his-clinic-royalty-free-image-1661432441.jpg?crop=0.66698xw:1xh;center,top&resize=1200:*",
                            Role = "Doctor",
                            SecondName = "Юрій"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Львів, просп. Свободи, 21",
                            DoctorType = "Стоматолог",
                            Email = "art_patskun@gmail.com",
                            FirstName = "Артур",
                            LastName = "Батькович",
                            Password = "DoctorPass",
                            Phone = "097-688-55-25",
                            PhotoFile = "https://images.unsplash.com/photo-1612349317150-e413f6a5b16d?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                            Role = "Doctor",
                            SecondName = "Пацкун"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Львів, просп. Свободи, 21",
                            DoctorType = "Педіатр",
                            Email = "papa@gmail.com",
                            FirstName = "Анастасія",
                            LastName = "Іванівна",
                            Password = "DoctorPass",
                            Phone = "097-586-55-25",
                            PhotoFile = "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg",
                            Role = "Doctor",
                            SecondName = "Зайчук"
                        },
                        new
                        {
                            Id = 6,
                            Address = "Львів, просп. Свободи, 21",
                            DoctorType = "Педіатр",
                            Email = "papa@gmail.com",
                            FirstName = "Анастасія",
                            LastName = "Іванівна",
                            Password = "DoctorPass",
                            Phone = "097-586-55-25",
                            PhotoFile = "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg",
                            Role = "Doctor",
                            SecondName = "Зайчук"
                        },
                        new
                        {
                            Id = 12,
                            Address = "Львів, просп. Свободи, 21",
                            DoctorType = "Педіатр",
                            Email = "papa@gmail.com",
                            FirstName = "Анастасія",
                            LastName = "Іванівна",
                            Password = "DoctorPass",
                            Phone = "097-586-55-25",
                            PhotoFile = "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg",
                            Role = "Doctor",
                            SecondName = "Зайчук"
                        },
                        new
                        {
                            Id = 7,
                            Address = "Львів, просп. Свободи, 21",
                            DoctorType = "Педіатр",
                            Email = "papa@gmail.com",
                            FirstName = "Анастасія",
                            LastName = "Іванівна",
                            Password = "DoctorPass",
                            Phone = "097-586-55-25",
                            PhotoFile = "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg",
                            Role = "Doctor",
                            SecondName = "Зайчук"
                        },
                        new
                        {
                            Id = 11,
                            Address = "Львів, просп. Свободи, 21",
                            DoctorType = "Педіатр",
                            Email = "papa@gmail.com",
                            FirstName = "Анастасія",
                            LastName = "Іванівна",
                            Password = "DoctorPass",
                            Phone = "097-586-55-25",
                            PhotoFile = "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg",
                            Role = "Doctor",
                            SecondName = "Зайчук"
                        },
                        new
                        {
                            Id = 8,
                            Address = "Львів, просп. Свободи, 21",
                            DoctorType = "Педіатр",
                            Email = "papa@gmail.com",
                            FirstName = "Анастасія",
                            LastName = "Іванівна",
                            Password = "DoctorPass",
                            Phone = "097-586-55-25",
                            PhotoFile = "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg",
                            Role = "Doctor",
                            SecondName = "Зайчук"
                        },
                        new
                        {
                            Id = 9,
                            Address = "Львів, просп. Свободи, 21",
                            DoctorType = "Педіатр",
                            Email = "papa@gmail.com",
                            FirstName = "Анастасія",
                            LastName = "Іванівна",
                            Password = "DoctorPass",
                            Phone = "097-586-55-25",
                            PhotoFile = "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg",
                            Role = "Doctor",
                            SecondName = "Зайчук"
                        },
                        new
                        {
                            Id = 10,
                            Address = "Львів, вул. Жовківська, 39",
                            Email = "vika@gmail.com",
                            FirstName = "Вікторія",
                            LastName = "Орестівна",
                            Password = "VictoriaPass",
                            Phone = "095-655-65-89",
                            PhotoFile = "https://img.freepik.com/free-photo/smiley-man-relaxing-outdoors_23-2148739334.jpg?w=360&t=st=1702807538~exp=1702808138~hmac=e4d0e9393c54c1ee1bd095ec5661699ca013cdb7205b4753ec46e0ecea406956",
                            Role = "Patient",
                            SecondName = "Анашян"
                        });
                });

            modelBuilder.Entity("ArchitectureApi.Models.UserVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VisitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("VisitId");

                    b.ToTable("UserVisit");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            UserId = 1,
                            VisitId = 2
                        },
                        new
                        {
                            Id = 4,
                            UserId = 10,
                            VisitId = 3
                        },
                        new
                        {
                            Id = 5,
                            UserId = 4,
                            VisitId = 2
                        },
                        new
                        {
                            Id = 6,
                            UserId = 6,
                            VisitId = 3
                        });
                });

            modelBuilder.Entity("ArchitectureApi.Models.TimeSlot", b =>
                {
                    b.HasOne("ArchitectureApi.Models.User", "Doctor")
                        .WithMany("FreeTimeSlots")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("ArchitectureApi.Models.UserVisit", b =>
                {
                    b.HasOne("ArchitectureApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ArchitectureApi.Data.Models.Visit", null)
                        .WithMany()
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ArchitectureApi.Models.User", b =>
                {
                    b.Navigation("FreeTimeSlots");
                });
#pragma warning restore 612, 618
        }
    }
}
