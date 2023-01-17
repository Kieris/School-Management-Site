using Microsoft.AspNetCore.Components;
using LMS.Database.Model;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Text;

namespace LMS.Blazor.Components
{
    public partial class AddCourse : ComponentBase
    {
        public bool ShowDialog { get; set; }
        private Course course = new();
        private HttpResponseMessage response;

        [Parameter]
        public EventCallback<Course> CloseEventCallback { get; set; }

        public string[] SelectedDays { get; set; } = new string[] { };
        public string[] SelectedSem { get; set; } = new string[] { };


        void SelectedDaysChanged(ChangeEventArgs e)
        {
            SelectedDays = (string[])e.Value;
            StringBuilder strb = new StringBuilder();
            foreach(var p in SelectedDays)
            {
                strb.Append(p);
            }
            course.Days = strb.ToString();
        }

        void SelectedSemChanged(ChangeEventArgs e)
        {
            SelectedSem = (string[])e.Value;
            StringBuilder strb = new StringBuilder();

            for (int i = 0; i < SelectedSem.Length; i++)
            {
                strb.Append(SelectedSem[i]);
                if(i != SelectedSem.Length -1)
                {
                    strb.Append(", ");
                }
            }            
            course.Semesters = strb.ToString();
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

        private async Task HandleValidSubmit()
        {
            response = await this.CommonService.AddCourse(course);
            if (response.StatusCode == HttpStatusCode.Created) 
            {
                await CloseEventCallback.InvokeAsync(course);
            }
        }
    }
}