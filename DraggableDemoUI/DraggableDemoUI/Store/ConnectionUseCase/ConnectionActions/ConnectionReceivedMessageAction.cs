namespace DraggableDemoUI.Store.ConnectionUseCase.ConnectionActions
{
    public class ConnectionReceivedMessageAction
    {
        public string Message { get; set; }

        public ConnectionReceivedMessageAction(string message)
        {
            Message = message;
        }
    }
}
