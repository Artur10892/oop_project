namespace CleanArch_Application.DTO.Requests
{
    public class CategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}