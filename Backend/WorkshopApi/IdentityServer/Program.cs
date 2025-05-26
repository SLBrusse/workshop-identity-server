var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddRazorPages();

builder.Services.AddIdentityServer(options =>
{
    options.EmitStaticAudienceClaim = true;
    options.KeyManagement.Enabled = false; 
})
.AddInMemoryClients(Config.Clients)
.AddInMemoryIdentityResources(Config.IdentityResources)
.AddInMemoryApiScopes(Config.ApiScopes)
.AddTestUsers(TestUsers.Users)
.AddDeveloperSigningCredential();


var app = builder.Build();


app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseRouting(); 

app.UseIdentityServer();

app.UseAuthorization();

app.MapRazorPages();

app.UseDeveloperExceptionPage();

app.Run();
