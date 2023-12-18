using ArchitectureApi.Data.Models;
using ArchitectureApi.Models;
using Microsoft.EntityFrameworkCore;
using DateTime = System.DateTime;

namespace ArchitectureApi.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Visit> Visits { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedDb(modelBuilder);
        InitUserVisit(modelBuilder);
    }

    private void InitUserVisit(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasMany<Visit>()
            .WithMany(x => x.Participants)
            .UsingEntity<UserVisit>();
    }
    
    private void SeedDb(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasData(new List<User>
            {
                new()
                {
                    Role = "Patient", FirstName = "Руслан", SecondName = "Пундак", LastName = "Ігорович", Id = 1,
                    Password = "RuslanPass",
                    Address = "Львів, вул. Жовківська, 39", Phone = "095-655-65-89", Email = "ruslan_p@gmail.com",
                    PhotoFile =
                        "https://img.freepik.com/free-photo/smiley-man-relaxing-outdoors_23-2148739334.jpg?w=360&t=st=1702807538~exp=1702808138~hmac=e4d0e9393c54c1ee1bd095ec5661699ca013cdb7205b4753ec46e0ecea406956"
                },
                new()
                {
                    Role = "Doctor", FirstName = "Папа", SecondName = "Пйотр", LastName = "Батьковтч", Id = 2,
                    Address = "Львів, вул. Київська, 49", Phone = "097-586-55-25", Email = "papa@gmail.com",
                    DoctorType = "Стоматолог", Password = "DoctorPass",
                    PhotoFile =
                        "https://professions.ng/wp-content/uploads/2023/07/The-Process-of-Becoming-a-Doctor-in-Nigeria-A-Roadmap2-768x768.jpg"
                },
                new()
                {
                    Role = "Doctor", FirstName = "Карпінець", SecondName = "Юрій", LastName = "Батькович", Id = 3,
                    Address = "Львів, вул. Луганська, 77", Phone = "097-785-55-25", Email = "yukarp@gmail.com",
                    DoctorType = "Стоматолог", Password = "DoctorPass",
                    PhotoFile =
                        "https://hips.hearstapps.com/hmg-prod/images/portrait-of-a-happy-young-doctor-in-his-clinic-royalty-free-image-1661432441.jpg?crop=0.66698xw:1xh;center,top&resize=1200:*"
                },
                new()
                {
                    Role = "Doctor", FirstName = "Артур", SecondName = "Пацкун", LastName = "Батькович", Id = 4,
                    Address = "Львів, просп. Свободи, 21", Phone = "097-688-55-25", Email = "art_patskun@gmail.com",
                    DoctorType = "Стоматолог", Password = "DoctorPass",
                    PhotoFile =
                        "https://images.unsplash.com/photo-1612349317150-e413f6a5b16d?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D"
                },
                new()
                {
                    Id = 5,
                    Role = "Doctor", FirstName = "Анастасія", SecondName = "Зайчук", LastName = "Іванівна",
                    Address = "Львів, просп. Свободи, 21", Phone = "097-586-55-25", Email = "papa@gmail.com",
                    DoctorType = "Педіатр", Password = "DoctorPass",
                    PhotoFile =
                        "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg"
                },
                new()
                {
                    Id = 6,
                    Role = "Doctor", FirstName = "Анастасія", SecondName = "Зайчук", LastName = "Іванівна",
                    Address = "Львів, просп. Свободи, 21", Phone = "097-586-55-25", Email = "papa@gmail.com",
                    DoctorType = "Педіатр", Password = "DoctorPass",
                    PhotoFile =
                        "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg"
                },
                new()
                {
                    Id = 12,
                    Role = "Doctor", FirstName = "Анастасія", SecondName = "Зайчук", LastName = "Іванівна",
                    Address = "Львів, просп. Свободи, 21", Phone = "097-586-55-25", Email = "papa@gmail.com",
                    DoctorType = "Педіатр", Password = "DoctorPass",
                    PhotoFile =
                        "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg"
                },
                new()
                {
                    Id = 7,
                    Role = "Doctor", FirstName = "Анастасія", SecondName = "Зайчук", LastName = "Іванівна",
                    Address = "Львів, просп. Свободи, 21", Phone = "097-586-55-25", Email = "papa@gmail.com",
                    DoctorType = "Педіатр", Password = "DoctorPass",
                    PhotoFile =
                        "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg"
                },
                new()
                {
                    Id = 11,
                    Role = "Doctor", FirstName = "Анастасія", SecondName = "Зайчук", LastName = "Іванівна",
                    Address = "Львів, просп. Свободи, 21", Phone = "097-586-55-25", Email = "papa@gmail.com",
                    DoctorType = "Педіатр", Password = "DoctorPass",
                    PhotoFile =
                        "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg"
                },
                new()
                {
                    Id = 8,
                    Role = "Doctor", FirstName = "Анастасія", SecondName = "Зайчук", LastName = "Іванівна",
                    Address = "Львів, просп. Свободи, 21", Phone = "097-586-55-25", Email = "papa@gmail.com",
                    DoctorType = "Педіатр", Password = "DoctorPass",
                    PhotoFile =
                        "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg"
                },
                new()
                {
                    Id = 9,
                    Role = "Doctor", FirstName = "Анастасія", SecondName = "Зайчук", LastName = "Іванівна",
                    Address = "Львів, просп. Свободи, 21", Phone = "097-586-55-25", Email = "papa@gmail.com",
                    DoctorType = "Педіатр", Password = "DoctorPass",
                    PhotoFile =
                        "https://cdn-cmdnf.nitrocdn.com/rIbSxuwuPAXwZSWprHLoMZwMQUyOlAnq/assets/images/optimized/rev-597a6f2/www.unitekemt.com/wp-content/uploads/2022/05/shutterstock_1473042992-1030x687.jpg"
                },
                new()
                {
                    Role = "Patient", FirstName = "Вікторія", SecondName = "Анашян", LastName = "Орестівна", Id = 10,
                    Address = "Львів, вул. Жовківська, 39", Phone = "095-655-65-89", Email = "vika@gmail.com",
                    Password = "VictoriaPass",
                    PhotoFile =
                        "https://img.freepik.com/free-photo/smiley-man-relaxing-outdoors_23-2148739334.jpg?w=360&t=st=1702807538~exp=1702808138~hmac=e4d0e9393c54c1ee1bd095ec5661699ca013cdb7205b4753ec46e0ecea406956"
                }
            });

        modelBuilder.Entity<TimeSlot>()
            .HasData(new List<TimeSlot>
            {
                new()
                {
                    Id = 1,
                    DoctorId = 2, From = new DateTime(2024, 1, 1, 8, 0, 0), To = new DateTime(2024, 1, 1, 18, 0, 0)
                },
                new()
                {
                    Id = 2,
                    DoctorId = 3, From = new DateTime(2024, 1, 1, 8, 0, 0), To = new DateTime(2024, 1, 1, 18, 0, 0)
                },
                new()
                {
                    Id = 3,
                    DoctorId = 4, From = new DateTime(2024, 1, 1, 8, 0, 0), To = new DateTime(2024, 1, 1, 18, 0, 0)
                }
            });

        modelBuilder.Entity<Visit>()
            .HasData(new List<Visit>
            {
                new()
                {
                    Time = new DateTime(2023, 12, 28, 12, 00, 00),
                    Notes = "Болить горло", Treatment = "Прополоскати горло", Id = 2
                },
                new()
                {
                    Time = new DateTime(2023, 12, 28, 14, 00, 00),
                    Notes = "Болить живіт", Treatment = "Випити ліки від болю в животі", Id = 3
                }
            });

        modelBuilder.Entity<UserVisit>()
            .HasData(new List<UserVisit>
            {
                new()
                {
                    VisitId = 2, UserId = 1, Id = 3
                },
                new()
                {
                    VisitId = 3, UserId = 10, Id = 4
                },
                new()
                {
                    VisitId = 2, UserId = 4, Id = 5
                },
                new()
                {
                    VisitId = 3, UserId = 6, Id = 6
                }
            });
    }
}