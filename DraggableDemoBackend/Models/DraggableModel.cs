namespace DraggableDemoBackend.Models
{
    public class DraggableModel
    {
        public int Id { get; set; }
        public DateTime LastUpdated { get; set; }

        public DraggableModel(int id)
        {
            Id = id;
            LastUpdated = DateTime.Now;
        }
    }
}
