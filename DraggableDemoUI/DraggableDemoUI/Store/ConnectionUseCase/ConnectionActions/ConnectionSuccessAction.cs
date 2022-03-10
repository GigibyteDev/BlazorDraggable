using Microsoft.AspNetCore.SignalR.Client;

namespace DraggableDemoUI.Store.ConnectionUseCase.ConnectionActions
{
    public class ConnectionSuccessAction
    {
        public HubConnection Connection { get; set; }

        public ConnectionSuccessAction(HubConnection connection)
        {
            Connection = connection;
        }
    }
}
