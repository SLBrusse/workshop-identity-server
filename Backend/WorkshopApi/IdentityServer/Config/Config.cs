using Duende.IdentityServer.Models;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResource("roles", new[] { "role" })
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new ApiScope[]
        {
            new ApiScope("api1", "Toegang tot API", new[] { "role","name" })
        };

    public static IEnumerable<Client> Clients =>
        new Client[]
        {
            new Client
            {
                ClientId = "workshop-client",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                RequirePkce = true,
                RequireClientSecret = false,
                RedirectUris = { "https://localhost:5002/authentication/login-callback" },
                PostLogoutRedirectUris = { "https://localhost:5002/" },
                AllowedScopes = { "openid", "profile", "roles", "api1" },
                AllowAccessTokensViaBrowser = true
            }
        };
}