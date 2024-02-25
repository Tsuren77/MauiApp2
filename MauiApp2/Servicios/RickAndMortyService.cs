using System.Text.Json;
using System.Text.Json.Nodes;
using MauiApp2.Models;
using Location = MauiApp2.Models.Location;

namespace MauiApp2.Servicios;

public class RickAndMortyService : IRickAndMortyService
{
    private string urlApi = "https://rickandmortyapi.com/api/character";
    private string urlApiLocat = "https://rickandmortyapi.com/api/location";

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
    
    public async Task<List<Location>> ObtenerLocalizacion()
    {
        var client = new HttpClient();
        var response = await client.GetAsync(urlApiLocat);
        var responseBody = await response.Content.ReadAsStreamAsync();
        JsonNode nodos = JsonNode.Parse(responseBody);
        JsonNode results = nodos["results"];

        var localizacionData = JsonSerializer.Deserialize<List<Location>>(results.ToString());
        return localizacionData;
    }
}