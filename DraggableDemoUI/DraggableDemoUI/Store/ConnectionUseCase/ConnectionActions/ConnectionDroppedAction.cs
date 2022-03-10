namespace DraggableDemoUI.Store.ConnectionUseCase.ConnectionActions
{
    public class ConnectionDroppedAction
    {
        public string Error { get; set; }

        public ConnectionDroppedAction(string error)
        {
            Error = error;
        }
    }
}
