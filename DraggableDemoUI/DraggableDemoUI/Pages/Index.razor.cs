using DraggableDemoUI.Store.ConnectionUseCase.Effects;
using Fluxor;
using Microsoft.AspNetCore.Components;

namespace DraggableDemoUI.Pages
{
    public partial class Index
    {
        [Inject]
        private IDispatcher Dispatcher { get; set; }
        protected override void OnInitialized()
        {
            Dispatcher.Dispatch(new ConnectionConnectEffect(StateHasChanged));
            base.OnInitialized();
        }
    }
}
