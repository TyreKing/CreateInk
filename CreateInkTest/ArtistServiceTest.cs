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
using Microsoft.Extensions.DependencyInjection;

namespace CreateInkTest
{
    public class ArtistServiceTest
    {
        //private DbContextOptions<CreateInkContext> dbContextOptions = new DbContextOptionsBuilder<CreateInkContext>()
        //    .UseInMemoryDatabase(databaseName: "CreateInkDb").Options;
        private IUserService _userService;

        
        //public void SetUp(bool seedData = false)
        //{
        //    if(seedData)SeedDb();
        //    _userService = new UserService(new CreateInkContext(dbContextOptions));
        //}

        private static DbContextOptions<CreateInkContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh 
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<CreateInkContext>();
            builder.UseInMemoryDatabase(databaseName: "CreateInkDb")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }


        private void SeedDb(CreateInkContext context)
        {

            var roles = new List<RoleDto>()
            {
                new RoleDto{Id = Guid.Parse("795DF5BE-7260-4857-AEF0-2C2288D026B0"), Name = "Admin"},
                new RoleDto{Id = Guid.Parse("B77FECCB-8928-42C1-BC8C-F82093FBCCB6"), Name = "Artist"}
            }.Select(x => Role.Create(x));

            var artists = new List<UserDto>
            {
               new UserDto{
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

        private UserService SetUpService(CreateInkContext context)
        {
            SeedDb(context);
            var userService = new UserService(context);
            return userService;
        }

        [Fact]
        public void Get_All_Artists()
        {
            using var context = new CreateInkContext(CreateNewContextOptions());
            var userService = SetUpService(context);
            var artist = userService.GetArtists();
            Assert.True(artist.Any());
        }


        [Fact]
        public void Get_Artist_By_Id()
        {
            using var context = new CreateInkContext(CreateNewContextOptions());
            var userService = SetUpService(context);
            var artistId = userService.GetArtists().Select(x =>x.Id).First();
            var artist = userService.GetArtist(artistId);
            Assert.True(null != artist);
        }
    }
}
