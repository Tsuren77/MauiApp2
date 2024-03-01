using MauiApp2.Models;
using Location = MauiApp2.Models.Location;

namespace MauiApp2.Servicios;

public interface IRickAndMortyService
{
    Task<Personajes> Obtener();
    Task<Personajes> ObtenerMas(string url);
    Task<List<Location1>> ObtenerLocalizacion();
}