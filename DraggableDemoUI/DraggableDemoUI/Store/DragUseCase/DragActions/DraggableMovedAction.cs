namespace DraggableDemoUI.Store.DragUseCase.DragActions
{
    public class DraggableMovedAction
    {
        public DraggableModel DraggableModel { get; set; }
        public int ContainerId { get; set; }

        public DraggableMovedAction(DraggableModel draggableModel, int containerId)
        {
            DraggableModel = draggableModel;
            ContainerId = containerId;
        }
    }
}
