using Actividad.Class;
using System.Linq;
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Pokemon Pokemon = new Pokemon();

app.MapPost("/api/v1/Gimnasio", (PokemonDTO pokemon) =>
{
    Pokemon.Add(pokemon);
});

app.MapDelete("/api/v1/Gimnasio/{nombre}", (string nombre) =>
{
    Pokemon.Delete(nombre);
});

app.MapPost("/api/v1/Gimnasio/Batch", (List<PokemonDTO> pokemones) =>
{
    foreach (var pokemon in pokemones)
    {
        Pokemon.Add(pokemon);
    }
    return Results.Ok();
});

app.MapGet("/api/v1/Gimnasio", () =>
{
    return Results.Ok(Pokemon.All());
});


app.MapPut("/api/v1/Gimnasio/{tipo}/", (string Tipo) =>
{
    return Results.Ok(Pokemon.GetByType(Tipo));

});

app.MapPut("/api/v1/Gimnasio/Maestro/{nombre}/", (string Nombre) =>
{
    return Results.Ok(Pokemon.GetByName(Nombre));

});

// Endpoint para obtener todos los pokemones por la habilidad
app.MapGet("/api/v1/Gimnasio/PokemonesPorPoder/{poder}", (int poder) =>
{
    var resultado = Pokemon.All().Where(pokemon => pokemon.PoderHabilidad.Contains(poder)).ToList();
    return Results.Ok(resultado);
});

// Endpoint para eliminar por tipo
app.MapDelete("/api/v1/Gimnasio/PokemonesPorTipo/{tipo}", (string tipo) =>
{
    var pokemonesAEliminar = Pokemon.GetByType(tipo);
    if (pokemonesAEliminar.Count > 0)
    {
        foreach (var pokemon in pokemonesAEliminar)
        {
            Pokemon.Delete(pokemon.Nombre);
        }
        return Results.Ok($"Se eliminaron {pokemonesAEliminar.Count} pokemones de tipo {tipo}");
    }
    else
    {
        return Results.NotFound($"No se encontraron pokemones de tipo {tipo}");
    }
});

app.Run();
