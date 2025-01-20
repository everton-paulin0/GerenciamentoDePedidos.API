namespace GerenciamentoDePedidos.API.Entities
{
    public class BaseEntities
    {
        public BaseEntities()
        {
            
        }
        public BaseEntities(int id, DateTime createdAt, DateTime updatedAt, bool isDeleted)
        {
            Id = id;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
