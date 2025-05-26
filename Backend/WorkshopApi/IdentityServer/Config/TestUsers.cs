using Duende.IdentityServer.Test;
using System.Security.Claims;

public static class TestUsers
{
    public static List<TestUser> Users =>
        new List<TestUser>
        {
            new TestUser
            {
                SubjectId = "1",
                Username = "alice",
                Password = "ditiseenveiligwachtwoord",
                Claims =
                {
                    new Claim("name", "Alice"),
                    new Claim("email", "alice@test.com"),
                    new Claim("role", "Leerling")
                }
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "bob",
                Password = "bobiscool",
                Claims =
                {
                    new Claim("name", "Bob"),
                    new Claim("email", "bob@test.com"),
                    new Claim("role", "Docent")
                }
            },
             new TestUser
            {
                SubjectId = "3",
                Username = "sjaakie",
                Password = "sjaakieKwek",
                Claims =
                {
                    new Claim("name", "Sjaakie"),
                    new Claim("email", "Sjaakie@test.com"),
                    new Claim("role", "SLB")
                }
            },
              new TestUser
            {
                SubjectId = "4",
                Username = "piet",
                Password = "pietswachtwoord",
                Claims =
                {
                    new Claim("name", "Piet"),
                    new Claim("email", "Piet@test.com"),
                    new Claim("role", "Beheerder")
                }
            }
        };
}
