using IdentityServer.Models;

namespace IdentityServer
{
    public static class InMemoryUsers
    {
        public static List<User> Users = new()
    {
        new User { Name = "jan", Password = "123", Role = "leerling" },
        new User { Name = "piet", Password = "abc", Role = "docent" },
        new User { Name = "klaas", Password = "admin", Role = "beheerder" },
        new User { Name = "sanne", Password = "slb", Role = "slb" },
    };
    }

}
