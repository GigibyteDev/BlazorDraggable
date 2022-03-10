using DraggableDemoBackend.Models;
using Microsoft.AspNetCore.SignalR;

namespace DraggableDemoBackend.Hubs
{
    public class DragHub : Hub
    {
        private readonly IEnumerable<DraggableContainerModel> draggableModels;
        public DragHub()
        {
            draggableModels = new List<DraggableContainerModel>()
            {
                new DraggableContainerModel(0, "Container1", new List<DraggableModel>()
                {
                    new DraggableModel(0),
                    new DraggableModel(1),
                    new DraggableModel(5),
                    new DraggableModel(6),
                    new DraggableModel(10),
                    new DraggableModel(11),
                }),
                new DraggableContainerModel(1, "Container2", new List<DraggableModel>()
                {
                    new DraggableModel(2),
                    new DraggableModel(7),
                    new DraggableModel(12),
                }),
                new DraggableContainerModel(2, "Container3", new List<DraggableModel>()
                {
                    new DraggableModel(3),
                    new DraggableModel(4),
                    new DraggableModel(8),
                    new DraggableModel(9),
                    new DraggableModel(13),
                    new DraggableModel(14),
                }),
                new DraggableContainerModel(3, "Container4", new List<DraggableModel>()
                {
                    new DraggableModel(15),
                    new DraggableModel(16),
                    new DraggableModel(17),
                }),
                new DraggableContainerModel(4, "Container5", new List<DraggableModel>()
                {
                    new DraggableModel(18),
                    new DraggableModel(19),
                    new DraggableModel(20),
                }),
            };
        }

        public async Task InstantiateConnection()
        {
            await Clients.Client(Context.ConnectionId).SendAsync("ConnectionSuccessful", draggableModels);
        }
    }
}
