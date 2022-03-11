namespace DraggableDemoUI.Store.DragUseCase.DragActions
{
    public class DraggableMovedAction
    {
        public DraggableContainerModel PreviousContainer { get; set; }
        public DraggableContainerModel NewContainer { get; set; }

        public DraggableMovedAction(DraggableContainerModel previousContainer, DraggableContainerModel newContainer)
        {
            PreviousContainer = previousContainer;
            NewContainer = newContainer;
        }
    }
}
