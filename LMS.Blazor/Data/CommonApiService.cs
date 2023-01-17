using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using LMS.Database.Model;

namespace LMS.Blazor.Data
{
    public class CommonApiService
    {
        private string baseUrl;
        private HttpClient httpClient;

        public CommonApiService(IConfiguration config)
        {
            baseUrl = config.GetValue<string>("ApiBaseURI");
            httpClient = new HttpClient() { BaseAddress = new Uri(baseUrl) };
        }        

        public async Task<Course[]> GetCourses()
        {
            return await httpClient.GetFromJsonAsync<Course[]>("courses");
        }

        public async Task<Course> GetCourse(string id)
        {
            try 
            {
                return await httpClient.GetFromJsonAsync<Course>("courses/GetCourse/" + id);
            }
            catch
            {
                return new Course();
            }
        }

        public async Task<HttpResponseMessage> AddCourse(Course crse)
        {
            var json = JsonSerializer.Serialize(crse);
            return await httpClient.PutAsJsonAsync<string>("courses/AddCourse", json);
        }

        public async Task<HttpResponseMessage> DeleteCourse(Guid id)
        {
            return await httpClient.DeleteAsync("courses/DeleteCourse/" + id);
        }

        public async Task<HttpResponseMessage> AddInstructorForCourse(Course course, string id)
        {
            return await httpClient.PutAsJsonAsync("courses/AddInstructor/" + course.Id + "/" + id, false);
        }
    }

}