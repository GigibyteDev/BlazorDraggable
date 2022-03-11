namespace DraggableDemoUI.Store.DragUseCase.DragActions
{
    public class DraggableMovedAction
    {
        public IEnumerable<DraggableContainerModel> DraggableModels { get; set; }

        public DraggableMovedAction(IEnumerable<DraggableContainerModel> draggableModels)
        {
            DraggableModels = draggableModels;
        }
    }
}
