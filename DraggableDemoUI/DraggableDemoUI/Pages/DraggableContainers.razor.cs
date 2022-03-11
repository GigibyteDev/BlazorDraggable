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
        public IState<DragState> DragState { get; set; }

        public int CurrentlyDraggingId => DragState.Value.CurrentlyDragging?.Id ?? -1;
    }
}
