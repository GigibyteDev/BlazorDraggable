namespace DraggableDemoBackend.Models
{
    public class DraggableContainerModel
    {
        public int ContainerId { get; set; }
        public string ContainerName { get; set; }
        public List<DraggableModel> DraggableModels { get; set; }
        public List<int> ModelsOrder { get; set; }

        public DraggableContainerModel(int containerId, string containerName, List<DraggableModel> draggableModels)
        {
            ContainerId = containerId;
            ContainerName = containerName;
            DraggableModels = draggableModels;
            ModelsOrder = new List<int>();
            foreach(DraggableModel model in DraggableModels)
            {
                ModelsOrder.Add(model.Id);
            }
        }
    }
}
