using System;
using Xunit;
using CreateInk.Context;
using CreateInk.Domain.Dtos;
using CreateInk.Models;
using CreateInk.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using CreateInk;

namespace CreateInkTest
{
    public class ArtistServiceTest
    {
        private DbContextOptions<CreateInkContext> dbContextOptions = new DbContextOptionsBuilder<CreateInkContext>()
            .UseInMemoryDatabase(databaseName: "CreateInkDb").Options;
        private IUserService _userService;

        
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
                   Id = Guid.Parse("b100ab4a-914b-4c59-889d-320fcec8582b"),
                   Age = 25,
                   Description = "Test 1",
                   FirstName = "f1",
                   LastName = "l1",
                   Role = new RoleDto{ 
                       Id = Guid.Parse("B77FECCB-8928-42C1-BC8C-F82093FBCCB6"),
                       Name="Artist", 
                       Permissions = new List<PermissionDto>{ 
                           new PermissionDto { Id = Guid.Parse("652ff0e1-1ce0-46ee-8158-3ceae3d89c00"), Name = "CanEdit"} 
                       } 
                   }
               },
               new UserDto{
                   Id = Guid.Parse("d6cbe464-c5fd-4f10-96e6-7c5ac1a165bb"),
                   Age = 33,
                   Description = "Test 2",
                   FirstName = "f2",
                   LastName = "l2",
                   Role = new RoleDto{
                       Id = Guid.Parse("B77FECCB-8928-42C1-BC8C-F82093FBCCB6"),
                       Name="Artist",
                       Permissions = new List<PermissionDto>{
                           new PermissionDto { Id = Guid.Parse("652ff0e1-1ce0-46ee-8158-3ceae3d89c00"), Name = "CanEdit"}
                       }
                   }
               },
               new UserDto{
                   Id = Guid.Parse("4725e6a9-359a-412e-b28e-617c2b094f1e"),
                   Age = 19,
                   Description = "Test 3",
                   FirstName = "f3",
                   LastName = "l3",
                   Role =  new RoleDto{
                       Id = Guid.Parse("B77FECCB-8928-42C1-BC8C-F82093FBCCB6"),
                       Name="Artist",
                       Permissions = new List<PermissionDto>{
                           new PermissionDto { Id = Guid.Parse("652ff0e1-1ce0-46ee-8158-3ceae3d89c00"), Name = "CanEdit"}
                       }
                   }
               }
            }.Select(x => Artist.Create(x)).ToList();

            var arts = new List<ArtDto>
            {
                new ArtDto
                {
                    ArtistId = Guid.Parse("4725e6a9-359a-412e-b28e-617c2b094f1e"),
                    Id = Guid.Parse("d86c304b-144b-4124-b8e7-5396515c9897"),
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


        [Fact]
        public void Get_GetAllArtist()
        {
            SetUp();
            var artist = _userService.GetArtists();
            Assert.True(artist.Any());
        }
    }
}