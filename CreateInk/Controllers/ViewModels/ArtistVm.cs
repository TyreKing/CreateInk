﻿using CreateInk.Domain.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreateInk.Controllers.ViewModels
{
    public class ArtistVm
    {
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("roleId")]
        public Guid RoleId { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public UserDto ToDto()
        {
            return new UserDto()
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Description = Description,
                Role = new RoleDto()
                {
                    Id = RoleId
                },
                Email = Email,
                UserName = UserName,
                Password = Password
            };
        }
    }
}
