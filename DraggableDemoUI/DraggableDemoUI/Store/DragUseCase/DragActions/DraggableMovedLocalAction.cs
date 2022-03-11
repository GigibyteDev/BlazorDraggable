namespace DraggableDemoUI.Store.DragUseCase.DragActions
{
    public class DraggableMovedLocalAction
    {
        public DraggableModel DraggableModel { get; set; }
        public int ContainerId { get; set; }
        public int? Position { get; set; }

        public DraggableMovedLocalAction(DraggableModel draggableModel, int containerId, int? position = null)
        {
            DraggableModel = draggableModel;
            ContainerId = containerId;
            Position = position;
        }
    }
}
