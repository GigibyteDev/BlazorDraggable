namespace DraggableDemoUI.Store.DragUseCase.DragActions
{
    public class BeginDraggingAction
    {
        public DraggableModel DraggableModel { get; set; }

        public BeginDraggingAction(DraggableModel draggableModel)
        {
            DraggableModel = draggableModel;
        }
    }
}
