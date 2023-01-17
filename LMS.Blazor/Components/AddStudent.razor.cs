using Microsoft.AspNetCore.Components;
using LMS.Database.Model;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace LMS.Blazor.Components
{
    public partial class AddStudent : ComponentBase
    {
        public bool ShowDialog { get; set; }
        private Student student = new();

        [Parameter]
        public EventCallback<bool> CloseEventCallback { get; set; }
        private HttpResponseMessage response;

        private async Task HandleValidSubmit()
        {
            response = await this.StudentService.AddStudent(student);
            if (response.StatusCode == HttpStatusCode.Created) 
            {
                await CloseEventCallback.InvokeAsync(true);
            }
        }

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
    }
}