## Config.cs
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

## voorbeeld endpoint:
  [HttpGet("lessons")]
  [Authorize(Roles = "Leerling,Docent")]
  public IActionResult GetLessons()
  {
      return Ok(InMemoryData.Lessen);
  }

## Login fetch:
 try {
      // Stap 4
      const formData = new URLSearchParams();
      formData.append('client_id', 'workshop-client');
      formData.append('client_secret', 'secret');
      formData.append('grant_type', 'password');
      formData.append('username', username);
      formData.append('password', password);

      const res = await fetch('https://localhost:7240/connect/token', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/x-www-form-urlencoded',
        },
        body: formData.toString(),
      });

      if (!res.ok) {
        alert('Verkeerde naam of wachtwoord');
        return;
      }

      const data = await res.json();
      localStorage.setItem('token', data.access_token);
      navigate('/home');
    } catch (err)