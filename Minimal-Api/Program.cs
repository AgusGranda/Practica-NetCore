using Microsoft.EntityFrameworkCore;
using Minimal_Api.Data;
using Minimal_Api.Modelos;
using Minimal_Api.Repositorys;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle




// seteo db context y repository

builder.Services.AddDbContext<PeliculasDbContext>
    (options => options.UseInMemoryDatabase("PeliculasDb"));

builder.Services.AddDbContext<SocioDbContext>
    (options => options.UseInMemoryDatabase("SocioDb"));

builder.Services.AddScoped<IPeliculaRepository,PeliculaRepository>();
builder.Services.AddScoped<ISocioRepository, SocioRepository>();

// end seteo db context y repository



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


// endpoints Peliculas // 

app.UseHttpsRedirection();

app.MapGet("/api/peliculas", (IPeliculaRepository repository) =>
{
    var pelicula = repository.GetAllPeliculas();
    return Results.Ok(pelicula);
});

app.MapGet("api/peliculas/{id}",(IPeliculaRepository repository, int id) =>
{
    var pelicula = repository.GetPeliculaById(id);
    return Results.Ok(pelicula);
});

app.MapPost("/api/peliculas/", (IPeliculaRepository repository, Pelicula pelicula) =>
{
    repository.AddPelicula(pelicula);
    return Results.Created($"/api/peliculas{pelicula.Id}", pelicula);
});
app.MapPut("/api/peliculas/{id}", (IPeliculaRepository repository, Pelicula pelicula, int id) =>
{
    var peliculaSeleccionada = repository.GetPeliculaById(id);
    if (peliculaSeleccionada != null)
    {
        peliculaSeleccionada.Duracion = pelicula.Duracion;
        peliculaSeleccionada.Descripcion = pelicula.Descripcion;
        peliculaSeleccionada.Genero = pelicula.Genero;
        return Results.NoContent();
    }
    return Results.NotFound();
});

app.MapDelete("/api/peliculas/{id}", (IPeliculaRepository repository, int id) =>
{
    var pelicula = repository.GetPeliculaById(id);
    if (pelicula != null)
    {
        repository.DeletePelicula(id);
        return Results.NoContent();
    }
    return Results.NotFound();
});

// end endpoints Peliculas // 




// Socios //

app.MapGet("/api/socios",(ISocioRepository repository) =>
{
    var socios = repository.GetAllSocios();
    return Results.Ok(socios);
});

app.MapGet("/api/socios/{id}", (ISocioRepository repository, int id) =>
{
    var socio = repository.GetSocioById(id);
    if (socio != null)
    {
      return Results.Ok(socio);
    }
    return Results.NotFound();
});

app.MapPost("/api/socios", (ISocioRepository repository, Socio socio) =>
{
    repository.AddSocio(socio);
    return Results.Created($"/api/socios{socio.Id}", socio);
});
app.MapPut("/api/socios/{id}", (ISocioRepository repository, Socio socio, int id) =>
{
    var socioSeleccionado = repository.GetSocioById(id);
    if(socioSeleccionado != null)
    {
        socioSeleccionado.Direccion = socio.Direccion;
        socioSeleccionado.Nombre = socio.Nombre;
        socioSeleccionado.Apellido = socio.Apellido;    
        return Results.NoContent();
    }
    return Results.NotFound();
}) ;

app.MapDelete("/api/socios/{id}",(ISocioRepository repository, int id) =>
{
    var socio = repository.GetSocioById(id);
    if (socio != null) 
    {
        repository.DeleteSocio(id);
    }
    return Results.NotFound();
});


// end Socios //

app.Run();

