
using System.Text.Json.Serialization;

namespace SrbComercialDomain.Entities;

public class Client{

    public int Id {get; set;}
    public string? Cnpj {get; set;}
    public string? Name {get; set;}
    public string? Email {get; set;}
    public string? Cep {get; set;}
    public string? Address {get; set;}
    public int CityId { get; set;}
    
    [JsonIgnore]
    public City? City {get; set;}
}