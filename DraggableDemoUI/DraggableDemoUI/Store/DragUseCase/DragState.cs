using Fluxor;
using Microsoft.AspNetCore.SignalR.Client;

namespace DraggableDemoUI.Store.DragUseCase
{
    [FeatureState]
    public class DragState
    {
        public List<DraggableContainerModel> Draggables { get; set; }
        public DraggableModel? CurrentlyDragging { get; set; }

        public DragState()
        {
            Draggables = new List<DraggableContainerModel>();

            CurrentlyDragging = null;

        }

        public DragState(DragState previousState, List<DraggableContainerModel>? newDraggables = null, DraggableModel? currentlyDragging = null)
        {
            Draggables = newDraggables is not null ? OrderDraggableContainerModels(newDraggables) : previousState.Draggables;
            CurrentlyDragging = newDraggables is null ? currentlyDragging ?? previousState.CurrentlyDragging : null;
        }

        private List<DraggableContainerModel> OrderDraggableContainerModels(List<DraggableContainerModel> containers)
        {
            List<DraggableContainerModel> sortedDraggableModels = new List<DraggableContainerModel>();
            foreach (var container in containers)
            {
                DraggableContainerModel sortedContainerToAdd = new DraggableContainerModel(container.ContainerId, container.ContainerName, new List<DraggableModel>(), container.ModelsOrder);
                foreach(int id in container.ModelsOrder)
                {
                    sortedContainerToAdd.DraggableModels.Add(container.DraggableModels.First(d => d.Id == id));
                }
                sortedDraggableModels.Add(sortedContainerToAdd);
            }

            return sortedDraggableModels;
        }
    }

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

    public class DraggableContainerModel
    {
        public int ContainerId { get; set; }
        public string ContainerName { get; set; }
        public List<DraggableModel> DraggableModels { get; set; }
        public List<int> ModelsOrder { get; set; }

        public DraggableContainerModel(int containerId, string containerName, List<DraggableModel> draggableModels, List<int> modelsOrder)
        {
            ContainerId = containerId;
            ContainerName = containerName;
            DraggableModels = draggableModels;
            ModelsOrder = modelsOrder;
        }
    }
}
