Console.WriteLine("Hello, World!");



/*
    Steg 1: Installera NuGet Paket
                Microsoft.EntityFrameworkCore.SqlServer
                Microsoft.EntityFrameworkCore.Tools

    Steg 2: Gör entiteter (klasser/modeller/objekt/tabeller)
                UserEntity              = tabell för att lagra användarinformation
                AddressEntity           = tabell för att lagra adressinformation
                RoleEntity              = tabell för att lagra användarroller

    Steg 3: Skapa en databas och hämnta connectionstring för den databasen
                g_database    Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Skola\Database\Lessons\Lektion-4\01_G_EntityFrameworkCore\Contexts\g_database.mdf;Integrated Security=True;Connect Timeout=30

    Steg 4: Skapa en Context som ärver ifrån DbContext och lagt in våra entiteter
                DataContext             = en context som hanterarkopplingen mellan databasen

    Steg 5: Gör en Add-Migration för att kontrollera alla kopplingar (måste göras i Package Manager Console)
                Add-Migration "Ange ett lämpligt migreringsnamn, börja på stor bokstav"

    Steg 6: Kontrollera så att vår Migration stämmer, om den stämmer gör en Update-Database annars Remove-Migration
            Update-Database             = sparar och skapar alla tabeller i databasen

    Steg 7: 




*/