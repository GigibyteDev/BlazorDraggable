namespace DraggableDemoUI.Store.DragUseCase.DragActions
{
    public class DraggableMovedLocalAction
    {
        public DraggableModel DraggableModel { get; set; }
        public int ContainerId { get; set; }

        public DraggableMovedLocalAction(DraggableModel draggableModel, int containerId)
        {
            DraggableModel = draggableModel;
            ContainerId = containerId;
        }
    }
}
