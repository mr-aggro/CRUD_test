namespace CRUD.Controllers
{
    public class Tankadd
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public int MinVolume { get; set; }

        public int MaxVolume { get; set; }

        public int CurrentVolume { get; set; }

        public override string ToString()
        {
            return $"Name={this.Name}";
        }
    }
}