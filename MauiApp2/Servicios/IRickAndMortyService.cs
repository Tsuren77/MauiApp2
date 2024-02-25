using MauiApp2.Models;

namespace MauiApp2.Servicios;

public interface IRickAndMortyService
{
    public Task<List<Personajes>>Obtener();
}