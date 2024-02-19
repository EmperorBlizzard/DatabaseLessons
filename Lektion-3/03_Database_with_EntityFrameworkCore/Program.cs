using _03_Database_with_EntityFrameworkCore.Models.Entities;
using _03_Database_with_EntityFrameworkCore.Services;

var userService = new UserService();

var user = new UserEntity()
{
    FirstName = "Emil",
    LastName = "Olsson",
    Email = "emil111@live.se",
    Address = new AddressEntity
    {
        StreetName = "Björkbacksvägen 37",
        PostalCode = "13540",
        City = "Tyresö"
    }
};

userService.CreateUser(user);
Console.ReadKey();