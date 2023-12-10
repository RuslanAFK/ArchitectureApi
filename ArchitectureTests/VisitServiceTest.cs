using ArchitectureApi.Data;
using ArchitectureApi.Data.Repositories.Concrete;
using ArchitectureApi.Models;
using ArchitectureApi.Services;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureTests;

public class VisitServiceTest
{
    private VisitService _service;
    private AppDbContext _db;

    private const string ConnectionString =
        "data source=.;initial catalog=ArchitectureTestDb;integrated security=SSPI;encrypt=false";

    [SetUp]
    public void Setup()
    {
        var dbOptions = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer(ConnectionString)
            .Options;
        
        _db = new AppDbContext(dbOptions);
        _db.Database.EnsureCreated();
        var unitOfWork = new UnitOfWork(_db);
        var visitRepo = new VisitRepository(_db);
        _service = new VisitService(visitRepo, unitOfWork);
    }

    [TearDown]
    public void TearDown()
    {
        _db.Database.EnsureDeleted(); 
    }

    [Test]
    public async Task GetVisits_ReturnsNone_WhenWrongName()
    {
        var patient = new User()
        {
            FirstName = "Ruslan",
            LastName = "Afk",
            Role = "Patient"
        };
        var doctor = new User()
        {
            FirstName = "",
            LastName = "",
            Role = "Doctor"
        };
        _db.Users.Add(patient);
        _db.Users.Add(doctor);
        _db.Visits.Add(new Visit()
        {
            Time = DateTime.Today,
            Participants =
            {
                patient, doctor
            }
        });
        await _db.SaveChangesAsync();
        
        var visits = _service.GetVisits("");
        Assert.That(visits.Count, Is.EqualTo(0));
    }
    [Test]
    public async Task GetVisits_Returns1_WhenOneVisitIsThere()
    {
        var patient = new User()
        {
            FirstName = "Ruslan",
            LastName = "Afk",
            Role = "Patient"
        };
        var doctor = new User()
        {
            FirstName = "",
            LastName = "",
            Role = "Doctor"
        };
        _db.Users.Add(patient);
        _db.Users.Add(doctor);
        _db.Visits.Add(new Visit()
        {
            Time = DateTime.Today,
            Participants =
            {
                patient, doctor
            }
        });
        await _db.SaveChangesAsync();
        
        var visits = _service.GetVisits("Ruslan Afk");
        Assert.That(visits.Count, Is.EqualTo(1));
    }
    [Test]
    public async Task GetVisits_ReturnsNone_WhenUsernameIsNull()
    {
        var patient = new User()
        {
            FirstName = "Ruslan",
            LastName = "Afk",
            Role = "Patient"
        };
        var doctor = new User()
        {
            FirstName = "",
            LastName = "",
            Role = "Doctor"
        };
        _db.Users.Add(patient);
        _db.Users.Add(doctor);
        _db.Visits.Add(new Visit()
        {
            Time = DateTime.Today,
            Participants =
            {
                patient, doctor
            }
        });
        await _db.SaveChangesAsync();
        
        var visits = _service.GetVisits(null);
        Assert.That(visits.Count, Is.EqualTo(0));
    }
    [Test]
    public async Task GetTreatments_ReturnsNone_WhenTreatmentIsNull()
    {
        var patient = new User()
        {
            FirstName = "Ruslan",
            LastName = "Afk",
            Role = "Patient"
        };
        var doctor = new User()
        {
            FirstName = "",
            LastName = "",
            Role = "Doctor"
        };
        _db.Users.Add(patient);
        _db.Users.Add(doctor);
        _db.Visits.Add(new Visit()
        {
            Time = DateTime.Today,
            Participants =
            {
                patient, doctor
            }
        });
        await _db.SaveChangesAsync();
        
        var visits = _service.GetTreatments("Ruslan Afk");
        Assert.That(visits.Count, Is.EqualTo(0));
    }
    [Test]
    public async Task GetTreatments_Returns1_WhenTreatmentIsNotNull()
    {
        var patient = new User()
        {
            FirstName = "Ruslan",
            LastName = "Afk",
            Role = "Patient"
        };
        var doctor = new User()
        {
            FirstName = "",
            LastName = "",
            Role = "Doctor"
        };
        _db.Users.Add(patient);
        _db.Users.Add(doctor);
        _db.Visits.Add(new Visit()
        {
            Time = DateTime.Today,
            Participants =
            {
                patient, doctor
            }, 
            Treatment = ""
        });
        await _db.SaveChangesAsync();
        
        var visits = _service.GetTreatments("Ruslan Afk");
        Assert.That(visits.Count, Is.EqualTo(1));
    }
    [Test]
    public async Task GetTreatments_ReturnsNone_WhenWrongUser()
    {
        var patient = new User()
        {
            FirstName = "Ruslan",
            LastName = "Afk",
            Role = "Patient"
        };
        var doctor = new User()
        {
            FirstName = "",
            LastName = "",
            Role = "Doctor"
        };
        _db.Users.Add(patient);
        _db.Users.Add(doctor);
        _db.Visits.Add(new Visit()
        {
            Time = DateTime.Today,
            Participants =
            {
                patient, doctor
            }, 
            Treatment = ""
        });
        await _db.SaveChangesAsync();
        
        var visits = _service.GetTreatments("NotMe");
        Assert.That(visits.Count, Is.EqualTo(0));
    }
    [Test]
    public async Task Create_CreatesNew()
    {
        var patient = new User()
        {
            FirstName = "Ruslan",
            LastName = "Afk",
            Role = "Patient"
        };
        var doctor = new User()
        {
            FirstName = "",
            LastName = "",
            Role = "Doctor"
        };
        
        await _service.Create(doctor, patient, DateTime.Now.AddDays(2));
        
        var visitFromDb = _db.Visits.FirstOrDefault();
        Assert.That(visitFromDb?.Id, Is.Not.Null);
    }
   
    [Test]
    public async Task Create_ThrowsArgumentException_WhenAnyUserIsNull()
    {
        var doctor = new User()
        {
            FirstName = "",
            LastName = "",
            Role = "Doctor"
        };
        
        Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            var res = await _service.Create(doctor, null, DateTime.Now.AddDays(2));
        }); 
    }
    [Test]
    public async Task Create_ThrowsArgumentException_WhenAnyUserIsWrongRole()
    {
        var patient = new User()
        {
            FirstName = "Ruslan",
            LastName = "Afk",
            Role = "Doctor"
        };

        Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await _service.Create(patient, patient, DateTime.Now);
        });
    }
    [Test]
    public async Task Create_ThrowsArgumantException_WhenTimeIsNow()
    {
        var patient = new User()
        {
            FirstName = "Ruslan",
            LastName = "Afk",
            Role = "Doctor"
        };

        Assert.ThrowsAsync<ArgumentException>(async () =>
        {
            await _service.Create(patient, patient, DateTime.Now);
        });
    }
}