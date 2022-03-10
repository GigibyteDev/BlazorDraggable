namespace DraggableDemoBackend.Models
{
    public class DraggableContainerModel
    {
        public int ContainerId { get; set; }
        public string ContainerName { get; set; }
        public IEnumerable<DraggableModel> DraggableModels { get; set; }

        public DraggableContainerModel(int containerId, string containerName, IEnumerable<DraggableModel> draggableModels)
        {
            ContainerId = containerId;
            ContainerName = containerName;
            DraggableModels = draggableModels;
        }
    }
}
