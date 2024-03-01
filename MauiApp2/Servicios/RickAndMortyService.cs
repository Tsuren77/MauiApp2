using System.Text.Json;
using System.Text.Json.Nodes;
using MauiApp2.Models;

namespace MauiApp2.Servicios;

public class RickAndMortyService : IRickAndMortyService
{
    private readonly HttpClient _httpClient;
    private string urlApiLocat = "https://rickandmortyapi.com/api/location";
    public RickAndMortyService()
    {
        _httpClient = new HttpClient();
    }
    public async Task<Personajes> Obtener()
    {
        var response = await _httpClient.GetAsync("https://rickandmortyapi.com/api/character");
        response.EnsureSuccessStatusCode();
        using var responseStream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<Personajes>(responseStream);
    }
    public async Task<List<Location1>> ObtenerLocalizacion()
    {
        var client = new HttpClient();
        var response = await client.GetAsync(urlApiLocat);
        var responseBody = await response.Content.ReadAsStreamAsync();
        JsonNode nodos = JsonNode.Parse(responseBody);
        JsonNode results = nodos["results"];

        var localizacionData = JsonSerializer.Deserialize<List<Location1>>(results.ToString());
        return localizacionData;
    }
    public async Task<Personajes> ObtenerMas(string url)
    {
        if (string.IsNullOrEmpty(url))
            throw new ArgumentNullException(nameof(url));
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        using var responseStream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<Personajes>(responseStream);
    }
}
