using Frontend.Web.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var backendUrl = builder.Configuration["BackendApi:BaseUrl"];
Uri.TryCreate(backendUrl, UriKind.Absolute, out var backendUri);

builder.Services.AddHttpClient<ProductApiClient>(client =>
{
    if (backendUri is not null)
    {
        client.BaseAddress = backendUri;
    }
    client.Timeout = TimeSpan.FromSeconds(15);
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();