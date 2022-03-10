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
            Draggables = newDraggables ?? previousState.Draggables;
            CurrentlyDragging = currentlyDragging ?? previousState.CurrentlyDragging;
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

        public DraggableContainerModel(int containerId, string containerName, List<DraggableModel> draggableModels)
        {
            ContainerId = containerId;
            ContainerName = containerName;
            DraggableModels = draggableModels;
        }
    }
}
