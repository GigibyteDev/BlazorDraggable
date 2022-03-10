using DraggableDemoUI.Store.DragUseCase.DragActions;
using Fluxor;

namespace DraggableDemoUI.Store.DragUseCase
{
    public class DragReducer
    {
        [ReducerMethod]
        public static DragState DraggableMovedAction(DragState state, DraggableMovedAction action)
        {
            try
            {
                var previousContainer = state.Draggables.Single(container => container.DraggableModels.Contains(action.DraggableModel));
                var newContainer = state.Draggables.Single(container => container.ContainerId == action.ContainerId);

                action.DraggableModel.LastUpdated = DateTime.Now;

                previousContainer.DraggableModels.Remove(action.DraggableModel);
                newContainer.DraggableModels.Add(action.DraggableModel);
            }
            catch (Exception ex)
            {}

            return new DragState(state, currentlyDragging: null);
        }

        [ReducerMethod]
        public static DragState BeginDraggingAction(DragState state, BeginDraggingAction action)
        {
            return new DragState
            (
                previousState: state,
                currentlyDragging: action.DraggableModel
            );
        }

        [ReducerMethod]
        public static DragState InstantiateDraggablesAction(DragState state, InstantiateDraggablesAction action)
        {
            return new DragState
            (
                previousState: state,
                newDraggables: action.DraggableModels.ToList()
            );
        }
    }
}
