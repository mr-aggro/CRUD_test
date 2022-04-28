namespace CRUD
{
    public class Tank
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public int MinVolume { get; set; }

        public int MaxVolume { get; set; }

        public int CurrentVolume { get; set; }

        public override string ToString()
        {
            return $"Id={this.Id} Name={this.Name}";
        }
    }
}
