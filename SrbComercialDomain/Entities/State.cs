using System.Text.Json.Serialization;

namespace SrbComercialDomain.Entities
{
    public class State
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Acronym { get; set; }

        // Uma coleção de cidades que pertencem a este estado
        [JsonIgnore]
        public virtual ICollection<City> Cities { get; set; } = new List<City>();
    }
}
