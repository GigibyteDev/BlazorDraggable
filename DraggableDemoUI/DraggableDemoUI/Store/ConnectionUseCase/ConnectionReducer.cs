using DraggableDemoUI.Store.ConnectionUseCase.ConnectionActions;
using Fluxor;

namespace DraggableDemoUI.Store.ConnectionUseCase
{
    public static class ConnectionReducer
    {
        [ReducerMethod(typeof(ConnectionBeginAction))]
        public static ConnectionState ConnectionBeginAction(ConnectionState state) =>
            new (
                    previousConnection: state,
                    loading: true
                );

        [ReducerMethod]
        public static ConnectionState ConnectionSuccessAction(ConnectionState state, ConnectionSuccessAction action)
        {
            return new ConnectionState
                (
                    previousConnection: state,
                    loading: false,
                    error: string.Empty,
                    connection: action.Connection
                );
        }

        [ReducerMethod]
        public static ConnectionState ConnectionDroppedAction(ConnectionState state, ConnectionDroppedAction action) 
        {
            return new ConnectionState(
                    previousConnection: state,
                    loading: false,
                    error: action.Error
                );
        }

        [ReducerMethod]
        public static ConnectionState ConnectionReceivedMessageAction(ConnectionState state, ConnectionReceivedMessageAction action)
        {
            return new ConnectionState(
                previousConnection: state,
                response: action.Message
            );
        }
    }
}
