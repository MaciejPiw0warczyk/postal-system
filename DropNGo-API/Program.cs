using System.Text.Json;
using DropNGo_Shared.Enums;
using DropNGo_Shared;
namespace DropNGo_API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        
        

        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();
        
        app.Urls.Add("http://0.0.0.0:5112");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseAuthorization();

        app.MapGet("/", () => "Hello World!");

        //TODO move to real implementation 
        app.MapGet("/parcel", () =>
        {
            var parcels = Enumerable.Range(1, 10).Select(index =>
                new Parcel(
                    Random.Shared.Next().ToString(),
                    
                    (ParcelStatus)Random.Shared.Next(0, Enum.GetNames(typeof(ParcelStatus)).Length)
                )
            ).ToArray();
            return JsonSerializer.Serialize(parcels);
        }).WithDisplayName("Parcels");

    app.Run();
    }
}