using DraggableDemoUI.Store.ConnectionUseCase.Effects;
using Fluxor;
using DraggableDemoUI.Store.DragUseCase;
using Microsoft.AspNetCore.Components;
using DraggableDemoUI.Store.ConnectionUseCase;

namespace DraggableDemoUI.Pages
{
    public partial class DraggableContainers
    {

        [Inject]
        public IDispatcher Dispatcher { get; set; }
        
        [Inject]
        public IState<DragState> DragState { get; set; }

        [Inject]
        public IState<ConnectionState> ConnectionState { get; set; }

        public int CurrentlyDraggingId => DragState.Value.CurrentlyDragging?.Id ?? -1;

        private void HandleGetDraggables()
        {
            if (ConnectionState.Value.Connection is not null)
            {
                ConnectionState.Value.Connection.SendCoreAsync("InstantiateConnection", new object[] { });
            }
        }
    }
}
