using Microsoft.AspNetCore.Mvc;
using Minimal_App.Model;
using Minimal_App.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IcoffeeService, CoffeeService>();

var app = builder.Build();


app.MapPost("/create",
    (CoffeeModel coffee, IcoffeeService service) =>
    {
        var result = service.Create(coffee);
        return Results.Ok(result);
    });

app.MapGet("/get",
    (int id, IcoffeeService service) =>
    {
        var coffee = service.Get(id);

        if (coffee is null) return Results.NotFound("Coffee not found");

        return Results.Ok(coffee);
    });

app.MapGet("/list",
    (IcoffeeService service) =>
    {
        var coffees = service.List();

        return Results.Ok(coffees);
    });

app.MapPut("/update",
    (CoffeeModel newCoffee, IcoffeeService service) =>
    {
        var updatedCoffee = service.Update(newCoffee);

        if (updatedCoffee is null) Results.NotFound("Coffee not found");

        return Results.Ok(updatedCoffee);
    });

app.MapDelete("/delete",
    (int id, IcoffeeService service) =>
    {
        var result = service.Delete(id);

        if (!result) Results.BadRequest("Something went wrong");

        return Results.Ok(result);
    });

app.Run();