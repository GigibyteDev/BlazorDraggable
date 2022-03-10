namespace DraggableDemoUI.Store.DragUseCase.DragActions
{
    public class InstantiateDraggablesAction
    {
        public IEnumerable<DraggableContainerModel> DraggableModels { get; set; }

        public InstantiateDraggablesAction(IEnumerable<DraggableContainerModel> draggableModels)
        {
            DraggableModels = draggableModels;
        }
    }
}
