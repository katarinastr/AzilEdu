using AzilEdu.Api.Data;
using Microsoft.EntityFrameworkCore;
using AzilEdu.Shared.Models;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AzilEduDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AzilEduDbContext>();
    await db.Database.MigrateAsync();


    if (!await db.Animals.AnyAsync())
    {
        db.Animals.AddRange(
            new Animal
            {
                Name = "Luna",
                Species = "Pas",
                Breed = "Labrador",
                Gender = "Ženka",
                Age = 3,
                ArrivalDate = new DateTime(2025, 10, 12),
                IsAdopted = false,
                ImageUrl = "/images/animals/luna.webp",
                Description = "Mirna i druželjubiva kujica koja voli šetnje."
            },
            new Animal
            {
                Name = "Maza",
                Species = "Mačka",
                Breed = "Domaća kratkodlaka",
                Gender = "Ženka",
                Age = 2,
                ArrivalDate = new DateTime(2025, 11, 5),
                IsAdopted = true,
                ImageUrl = "/images/animals/maza.webp",
                Description = "Zaigrana mačka naviknuta na boravak u zatvorenom prostoru."
            },
            new Animal
            {
                Name = "Rex",
                Species = "Pas",
                Breed = "Njemački ovčar",
                Gender = "Mužjak",
                Age = 5,
                ArrivalDate = new DateTime(2026, 1, 20),
                IsAdopted = false,
                ImageUrl = "/images/animals/rex.webp",
                Description = "Aktivan pas koji traži iskusnijeg vlasnika."
            },
            new Animal
            {
                Name = "Nala",
                Species = "Mačka",
                Breed = "Maine Coon mješanac",
                Gender = "Ženka",
                Age = null,
                ArrivalDate = new DateTime(2026, 2, 3),
                IsAdopted = false,
                ImageUrl = "/images/animals/nala.webp",
                Description = "Mlada mačka pronađena bez poznate povijesti."
            },
            new Animal
            {
                Name = "Tobi",
                Species = "Pas",
                Breed = "Mješanac",
                Gender = "Mužjak",
                Age = 1,
                ArrivalDate = null,
                IsAdopted = false,
                ImageUrl = "/images/animals/tobi.webp",
                Description = "Vesel pas kojem datum dolaska još nije potvrđen."
            },
            new Animal
            {
                Name = "Bruno",
                Species = "Pas",
                Breed = "Bigl",
                Gender = "Mužjak",
                Age = 4,
                ArrivalDate = new DateTime(2025, 9, 18),
                IsAdopted = true,
                ImageUrl = "/images/animals/bruno.webp",
                Description = "Udomljen pas koji ostaje u evidenciji azila."
            }
        );
        await db.SaveChangesAsync();
    }

    if (!await db.HousingUnits.AnyAsync())
    {
        db.HousingUnits.AddRange(
            new HousingUnit
            {
                Name = "Boks A1",
                UnitType = "Dog Box",
                Capacity = 4,
                Occupied = 4,
                LastCleanedAt = DateTime.Now.AddDays(-1),
                IsActive = true,
                ImageUrl = "/images/housing-units/box-1.webp",
                Note = "Pun boks"
            },

            new HousingUnit
            {
                Name = "Boks A2",
                UnitType = "Dog Box",
                Capacity = 3,
                Occupied = 1,
                LastCleanedAt = DateTime.Now.AddDays(-2),
                IsActive = true,
                ImageUrl = "/images/housing-units/box-2.webp",
                Note = "Slobodna mjesta"
            },

            new HousingUnit
            {
                Name = "Mačja soba",
                UnitType = "Cat Room",
                Capacity = 5,
                Occupied = 2,
                LastCleanedAt = null,
                IsActive = true,
                ImageUrl = "/images/housing-units/cat-room.webp",
                Note = "Datum čišćenja nije unesen"
            },

            new HousingUnit
            {
                Name = "Karantena",
                UnitType = "Quarantine",
                Capacity = 2,
                Occupied = 1,
                LastCleanedAt = DateTime.Now,
                IsActive = true,
                ImageUrl = "/images/housing-units/quarantine.webp",
                Note = "Nova životinja"
            },

            new HousingUnit
            {
                Name = "Vanjski prostor",
                UnitType = "Dog Yard",
                Capacity = 6,
                Occupied = 3,
                LastCleanedAt = DateTime.Now.AddDays(-4),
                IsActive = true,
                ImageUrl = "/images/housing-units/yard-unit.webp",
                Note = "Slobodna mjesta"
            },

            new HousingUnit
            {
                Name = "Stari boks",
                UnitType = "Dog Box",
                Capacity = 4,
                Occupied = 0,
                LastCleanedAt = DateTime.Now.AddDays(-10),
                IsActive = false,
                ImageUrl = "/images/housing-units/inactive-unit.webp",
                Note = "Ne koristi se"
            }
        );
        await db.SaveChangesAsync();
    }
            
        
        
       
       
    
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
