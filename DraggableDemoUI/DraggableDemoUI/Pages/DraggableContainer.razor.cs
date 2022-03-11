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

        public void HandleContainerDrop()
        {
            if (ConnectionState.Value.Connection is not null 
                && DragState.Value.CurrentlyDragging is not null
                && DragState.Value.CurrentlyDragging.Id != -1)
            {
                ConnectionState.Value.Connection.SendCoreAsync("MoveDraggable", new object[] { DragState.Value.CurrentlyDragging, ContainerData.ContainerId, null });
                Dispatcher.Dispatch(new DraggableMovedLocalAction(DragState.Value.CurrentlyDragging, ContainerData.ContainerId));
            }
        }

        public void HandleContainerDragEnter()
        {

        }

        public void HandleContainerDragLeave()
        {

        }

        public void HandleDraggableDrop(int draggableId)
        {
            if (ConnectionState.Value.Connection is not null 
                && DragState.Value.CurrentlyDragging is not null
                && DragState.Value.CurrentlyDragging.Id != -1)
            {
                int draggablePosition = ContainerData.ModelsOrder.IndexOf(draggableId);
                ConnectionState.Value.Connection.SendCoreAsync("MoveDraggable", new object[] { DragState.Value.CurrentlyDragging, ContainerData.ContainerId, draggablePosition });
                Dispatcher.Dispatch(new DraggableMovedLocalAction(DragState.Value.CurrentlyDragging, ContainerData.ContainerId, draggablePosition));
            }
        }
    }
}
