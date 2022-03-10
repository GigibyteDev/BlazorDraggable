namespace DraggableDemoUI.Store.ConnectionUseCase.Effects
{
    public class ConnectionConnectEffect
    {
        public string BackendURI => "https://localhost:7069/";
        public string DragHubName => "drag";
        public string DragHubURI => BackendURI + DragHubName;
        public Action UpdateState { get; set; }

        public ConnectionConnectEffect(Action updateState)
        {
            UpdateState = updateState;
        }
    }
}
