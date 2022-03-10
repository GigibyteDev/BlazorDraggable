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
        public IDispatcher Dispatcher { get; set; }

        public void HandleDrop()
        {
            Dispatcher.Dispatch(new DraggableMovedAction(DragState.Value.CurrentlyDragging, ContainerData.ContainerId));
        }

        public void HandleDragEnter()
        {

        }

        public void HandleDragLeave()
        {

        }
    }
}
