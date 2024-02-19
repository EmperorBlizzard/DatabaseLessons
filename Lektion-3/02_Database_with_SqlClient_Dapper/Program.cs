using _02_Database_with_SqlClient_Dapper.Models;
using _02_Database_with_SqlClient_Dapper.Services;

var userService = new UserService();
var user = new User
{
    Address = new Address()
};

Console.Write("Ange Förnamn: ");
user.FirstName = Console.ReadLine()!;

Console.Write("Ange Efternamn: ");
user.LastName = Console.ReadLine()!;

Console.Write("Ange E-postadress: ");
user.Email = Console.ReadLine()!;

Console.Write("Ange Gatunamn: ");
user.Address.StreetName = Console.ReadLine()!;

Console.Write("Ange Postnummer: ");
user.Address.PostalCode = Console.ReadLine()!;

Console.Write("Ange Ort: ");
user.Address.City = Console.ReadLine()!;


var result = userService.CreateUser(user);
if (result)
    Console.WriteLine("Användaren skapades");
else
    Console.WriteLine("Något gick fel");

Console.ReadKey();