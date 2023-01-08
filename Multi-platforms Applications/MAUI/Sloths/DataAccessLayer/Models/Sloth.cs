namespace Sloths.Models
{
    public class Sloth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public double? MinSize { get; set; }
        public double? MaxSize { get; set; }
        public double? MinWeight { get; set; }
        public double? MaxWeight { get; set; }
        public string Localization { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
