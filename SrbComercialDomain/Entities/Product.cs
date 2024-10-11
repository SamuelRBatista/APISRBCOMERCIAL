using System.Text.Json.Serialization;

namespace SrbComercialDomain.Entities;
public  class Product
{
    public int Id { get; set; } 
    public string Ean {get; set;}
    public string? Name { get; set; }
    public string? Description { get; set; } 
    public Decimal Price { get; set; }
    public int Quantity {get; set;}
    public string? Image_Url {get;set;}    
    public int CategoryId { get; set; }

    [JsonIgnore]
    public Category? Category { get; set; }

}
