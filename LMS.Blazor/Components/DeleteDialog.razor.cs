using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace LMS.Blazor.Components
{
    public partial class DeleteDialog : ComponentBase
    {
        public bool ShowDialog { get; set; }

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }

        public void Show()
        {
            ShowDialog = true;
            StateHasChanged();
        }

        public void Close()
        {
            ShowDialog = false;
            StateHasChanged();
        }

        protected async Task DeleteConfirmed()
        {
            ShowDialog = false;
            await CloseEventCallback.InvokeAsync(true);
            StateHasChanged();
        }
    }
}