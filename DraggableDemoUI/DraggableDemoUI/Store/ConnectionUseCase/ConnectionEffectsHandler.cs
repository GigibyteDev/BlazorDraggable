using DraggableDemoUI.Store.ConnectionUseCase.ConnectionActions;
using DraggableDemoUI.Store.ConnectionUseCase.Effects;
using DraggableDemoUI.Store.DragUseCase;
using DraggableDemoUI.Store.DragUseCase.DragActions;
using Fluxor;
using Microsoft.AspNetCore.SignalR.Client;

namespace DraggableDemoUI.Store.ConnectionUseCase
{
    public class ConnectionEffectsHandler
    {
        [EffectMethod]
        public async Task HandleConnectionConnect(ConnectionConnectEffect action, IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new ConnectionBeginAction());

            try
            {
                HubConnection connection = new HubConnectionBuilder()
                    .WithUrl(action.DragHubURI)
                    .ConfigureLogging(options => {
                        options.SetMinimumLevel(LogLevel.Information);
                    })
                    .Build();

                connection.On<IEnumerable<DraggableContainerModel>>("ConnectionSuccessful", (response) =>
                {
                    dispatcher.Dispatch(new InstantiateDraggablesAction(response));
                    action.UpdateState();
                });

                await connection.StartAsync();

                dispatcher.Dispatch(new ConnectionSuccessAction(connection));
            }
            catch (Exception ex)
            {
                dispatcher.Dispatch(new ConnectionDroppedAction("Could not instantiate Connection... Exception: " + ex.Message));
            }
        }
    }
}
