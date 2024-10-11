using System.Text.Json.Serialization;

namespace SrbComercialDomain.Entities;
public class Supplier {
    public int Id {get; set;}
    public string? Cnpj {get; set;}
    public string? Name {get; set;}
    public string? Email {get; set;}
    public string? Phone {get; set;}
    public string? Cep {get; set;}
    public string? Address {get; set;}

     public int CityId {get; set;}

    [JsonIgnore]
    public virtual City? City{ get; set; }

    // public int StateId {get; set;}

    // [JsonIgnore]
    // public virtual State? State { get; set; } // Referência ao estado
}