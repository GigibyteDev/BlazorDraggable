using DraggableDemoUI.Store.ConnectionUseCase;
using DraggableDemoUI.Store.DragUseCase;
using DraggableDemoUI.Store.DragUseCase.DragActions;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace DraggableDemoUI.Pages
{
    public partial class Draggable
    {
        [Parameter]
        public DraggableModel DraggableModel { get; set; }


        [Inject]
        private IDispatcher Dispatcher { get; set; }

        public void HandleDragStart()
        {
            Dispatcher.Dispatch(new BeginDraggingAction(DraggableModel));

            StateHasChanged();
        }
    }
}
