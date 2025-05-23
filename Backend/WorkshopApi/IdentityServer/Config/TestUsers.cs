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
                Password = "password",
                Claims =
                {
                    new Claim("name", "Alice"),
                    new Claim("email", "alice@test.com"),
                    new Claim("role", "admin")
                }
            },
            new TestUser
            {
                SubjectId = "2",
                Username = "bob",
                Password = "password",
                Claims =
                {
                    new Claim("name", "Bob"),
                    new Claim("email", "bob@test.com"),
                    new Claim("role", "user")
                }
            }
        };
}
