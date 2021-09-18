using CreateInk.Context;
using CreateInk.Controllers;
using CreateInk.Domain.Dtos;
using CreateInk.Models;
using CreateInk.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.UnitTesting
{
    public class ArtistControllerTests
    {
        private DbContextOptions<CreateInkContext> dbContextOptions = new DbContextOptionsBuilder<CreateInkContext>()
            .UseInMemoryDatabase(databaseName: "CreateInkDb").Options;
        private IUserService _userService;

        [OneTimeSetUp]
        public void SetUp()
        {
            SeedDb();
            _userService = new UserService(new CreateInkContext(dbContextOptions));   
        }

        private void SeedDb()
        {
            using var context = new CreateInkContext(dbContextOptions);

            var roles = new List<RoleDto>()
            {
                new RoleDto{Id = Guid.Parse("795DF5BE-7260-4857-AEF0-2C2288D026B0"), Name = "Admin"},
                new RoleDto{Id = Guid.Parse("B77FECCB-8928-42C1-BC8C-F82093FBCCB6"), Name = "Artist"}
            }.Select(x => Role.Create(x));

            var artists = new List<UserDto>
            {
               new UserDto{
                   Id = Guid.Parse("F6420EE9-C647-3E6E-EAB4-4ED39FDC5451"),
                   Age = 25,
                   Description = "Test 1",
                   FirstName = "f1",
                   LastName = "l1",
                   Role = new RoleDto{ Id = Guid.Parse("B77FECCB-8928-42C1-BC8C-F82093FBCCB6")} 
               },
               new UserDto{
                   Id = Guid.Parse("A6420CE9-C647-3E6E-EAB4-4ED39FDC5451"),
                   Age = 33,
                   Description = "Test 2",
                   FirstName = "f2",
                   LastName = "l2",
                   Role = new RoleDto{ Id = Guid.Parse("B77FECCB-8928-42C1-BC8C-F82093FBCCB6")}
               },
               new UserDto{
                   Id = Guid.Parse("R6420CE9-C647-3E6E-EAB4-4ED39FDC5451"),
                   Age = 19,
                   Description = "Test 3",
                   FirstName = "f3",
                   LastName = "l3",
                   Role = new RoleDto{ Id = Guid.Parse("B77FECCB-8928-42C1-BC8C-F82093FBCCB6")}
               }
            }.Select(x => Artist.Create(x)).ToList();

            var arts = new List<ArtDto>
            {
                new ArtDto
                {
                    ArtistId = Guid.Parse("R6420CE9-C647-3E6E-EAB4-4ED39FDC5451"),
                    Id = Guid.Parse("06420CE9-C647-3E6E-EAB4-4ED39FDC5451"),
                    Date = DateTime.UtcNow,
                    Description ="Art 1",
                    Name = "Art Test"
                }
            }.Select(x => Art.Create(x));

            context.Roles.AddRange(roles);
            context.Artists.AddRange(artists);
            context.Arts.AddRange(arts);
            context.SaveChanges();
        }

        //[Test]
        //public 
    }
}
