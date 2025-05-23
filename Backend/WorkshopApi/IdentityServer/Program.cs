var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages(); // <-- toevoegen

builder.Services.AddIdentityServer(options =>
{
    options.EmitStaticAudienceClaim = true;
    options.KeyManagement.Enabled = false; // voorkom licentie-fout
    options.UserInteraction.LoginUrl = "/Account/Login";
    // options.UserInteraction.LogoutUrl = "/Account/Logout";
})
.AddInMemoryClients(Config.Clients)
.AddInMemoryIdentityResources(Config.IdentityResources)
.AddInMemoryApiScopes(Config.ApiScopes)
.AddTestUsers(TestUsers.Users)
.AddDeveloperSigningCredential();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseRouting(); // <-- toevoegen

app.UseIdentityServer();

app.UseAuthorization();

app.MapRazorPages(); // <-- toevoegen

app.UseDeveloperExceptionPage(); // optioneel

app.Run();
