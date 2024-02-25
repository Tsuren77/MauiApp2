using MauiApp2.Models;
using Location = MauiApp2.Models.Location;

namespace MauiApp2.Servicios;

public interface IRickAndMortyService
{
    public Task<List<Personajes>>Obtener();
    Task<List<Location>> ObtenerLocalizacion();
}