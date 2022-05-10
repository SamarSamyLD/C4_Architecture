using Structurizr;

namespace OnlineShoppingArchticture.Application.Models

{
    public class Structure
    {
        public string? Alias { get; set; }
        public string? Label { get; set; }
        public string Description { get; set; } = string.Empty;
        public string[] Tags { get; set; } = Array.Empty<string>();
        public Location Boundary { get; set; } = Location.Internal;
        public List<RelationshipModel>? Relationships { get; set; }

    }
}