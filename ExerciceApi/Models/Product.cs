namespace ExerciceApi.Models
{
    public class Product
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public int Stock { get; set; } = 0;
        public string Description { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new();
        public float Price { get; set; }
    }
}