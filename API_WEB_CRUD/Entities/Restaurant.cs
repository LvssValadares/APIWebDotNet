namespace API_WEB_CRUD.Entities
{
    public class Restaurant
    {
        public int Id { get; set; }
        public required string Name {  get; set; }
        public string Specialty {  get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;

    }
}
