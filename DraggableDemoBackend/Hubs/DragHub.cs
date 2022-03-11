using DraggableDemoBackend.Models;
using Microsoft.AspNetCore.SignalR;

namespace DraggableDemoBackend.Hubs
{
    public class DragHub : Hub
    {
        private readonly List<DraggableContainerModel> draggableModels;
        public DragHub()
        {
            draggableModels = new List<DraggableContainerModel>();

            for(int i = 0; i < 3; i++)
            {
                draggableModels.Add(new DraggableContainerModel(i, $"container{i}", new List<DraggableModel>()));
            }

            for (int i = 0; i < 35; i++) 
            {
                var container = draggableModels.First(d => d.ContainerId == i % draggableModels.Count());
                container.DraggableModels.Add(new DraggableModel(i));
                container.ModelsOrder.Add(i);
            }
        }

        public async Task InstantiateConnection()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("ConnectionSuccessful", draggableModels);
        }

        public async Task MoveDraggable(DraggableModel draggableModel, int containerId, int? position = null)
        {
            await Clients.AllExcept(new List<string>(){ Context.ConnectionId }).SendAsync("DraggableMoved", draggableModel, containerId, position);
            
            try
            {
                var previousContainer = draggableModels.First(container => container.DraggableModels.Select(draggable => draggable.Id).Contains(draggableModel.Id));
                var newContainer = draggableModels.First(container => container.ContainerId == containerId);

                previousContainer.DraggableModels.RemoveAll(d => d.Id == draggableModel.Id);
                previousContainer.ModelsOrder.Remove(draggableModel.Id);

                newContainer.DraggableModels.Add(draggableModel);

                if (position is not null)
                {
                    newContainer.ModelsOrder.Insert(position.Value, draggableModel.Id);
                }
                else
                {
                    newContainer.ModelsOrder.Add(draggableModel.Id);
                }

                draggableModel.LastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {}
        }
    }
}
