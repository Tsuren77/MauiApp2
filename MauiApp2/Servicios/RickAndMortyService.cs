using System.Text.Json;
using System.Text.Json.Nodes;
using MauiApp2.Models;

namespace MauiApp2.Servicios;

public class RickAndMortyService : IRickAndMortyService
{
    private string urlApi = "https://rickandmortyapi.com/api/character";

    public async Task<List<Personajes>> Obtener()
    {
        var client = new HttpClient();
        var response = await client.GetAsync(urlApi);
        var responseBody = await response.Content.ReadAsStreamAsync();
        JsonNode nodos = JsonNode.Parse(responseBody);
        JsonNode results = nodos["results"];

        var personajesData = JsonSerializer.Deserialize<List<Personajes>>(results.ToString());
        return personajesData;
    }
}