using DraggableDemoUI.Store.DragUseCase.DragActions;
using Fluxor;

namespace DraggableDemoUI.Store.DragUseCase
{
    public class DragReducer
    {
        [ReducerMethod]
        public static DragState DraggableMovedLocalAction(DragState state, DraggableMovedLocalAction action)
        {
            try
            {
                var previousContainer = state.Draggables.Single(container => container.DraggableModels.Select(drag => drag.Id).Contains(action.DraggableModel.Id));
                var newContainer = state.Draggables.Single(container => container.ContainerId == action.ContainerId);

                previousContainer.DraggableModels.RemoveAll(d => d.Id == action.DraggableModel.Id);
                previousContainer.ModelsOrder.Remove(action.DraggableModel.Id);

                if (action.Position is not null)
                {
                    newContainer.DraggableModels.Insert(action.Position.Value, action.DraggableModel);
                    newContainer.ModelsOrder.Insert(action.Position.Value, action.DraggableModel.Id);
                }
                else
                {
                    newContainer.DraggableModels.Add(action.DraggableModel);
                    newContainer.ModelsOrder.Add(action.DraggableModel.Id);
                }

                action.DraggableModel.LastUpdated = DateTime.Now;
            }
            catch (Exception ex)
            {}

            return new DragState(state, currentlyDragging: new DraggableModel(-1));
        }

        [ReducerMethod]
        public static DragState DraggableMovedAction(DragState state, DraggableMovedAction action)
        {
            return new DragState(state, newDraggables: action.DraggableModels.ToList());
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
