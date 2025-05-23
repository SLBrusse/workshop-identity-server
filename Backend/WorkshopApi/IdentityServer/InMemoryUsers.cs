using IdentityServer.Models;

namespace IdentityServer
{
    public static class InMemoryUsers
    {
        public static List<User> Users = new()
    {
        new User { Username = "jan", Password = "123", Role = "leerling" },
        new User { Username = "piet", Password = "abc", Role = "docent" },
        new User { Username = "klaas", Password = "admin", Role = "beheerder" },
        new User { Username = "sanne", Password = "slb", Role = "slb" },
    };
    }

}
