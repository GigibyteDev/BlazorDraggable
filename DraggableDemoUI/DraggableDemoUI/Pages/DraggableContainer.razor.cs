using DraggableDemoUI.Store.ConnectionUseCase;
using DraggableDemoUI.Store.DragUseCase;
using DraggableDemoUI.Store.DragUseCase.DragActions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace DraggableDemoUI.Pages
{
    public partial class DraggableContainer
    {
        [Parameter]
        public DraggableContainerModel ContainerData { get; set; }

        [Inject]
        public IState<DragState> DragState { get; set; }

        [Inject]
        private IState<ConnectionState> ConnectionState { get; set; }

        [Inject]
        public IDispatcher Dispatcher { get; set; }

        public void HandleDrop()
        {
            // Dispatcher.Dispatch(new DraggableMovedLocalAction(DragState.Value.CurrentlyDragging, ContainerData.ContainerId));
            if (ConnectionState.Value.Connection is not null && DragState.Value.CurrentlyDragging is not null)
            {
                ConnectionState.Value.Connection.SendCoreAsync("MoveDraggable", new object[] { DragState.Value.CurrentlyDragging, ContainerData.ContainerId });
            }

        }

        public void HandleDragEnter()
        {

        }

        public void HandleDragLeave()
        {

        }
    }
}
