using System.Text.Json.Serialization;

namespace SrbComercialDomain.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }   
        public int StateId { get; set; }      
        [JsonIgnore]
        public State? State { get; set; }
    }
}
