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
    public class InstructorApiService
    {
        private string baseUrl;
        private HttpClient httpClient;

        public InstructorApiService(IConfiguration config)
        {
            baseUrl = config.GetValue<string>("ApiBaseURI");
            httpClient = new HttpClient() { BaseAddress = new Uri(baseUrl) };
        }        

        public async Task<Instructor[]> GetInstructors()
        {
            return await httpClient.GetFromJsonAsync<Instructor[]>("instructors");
        }

        public async Task<Instructor> GetInstructor(string id)
        {
            try 
            {
                return await httpClient.GetFromJsonAsync<Instructor>("instructors/GetInstructor/" + id);
            }
            catch
            {
                return new Instructor();
            }
        }

        public async Task<HttpResponseMessage> AddInstructor(Instructor crse)
        {
            var json = JsonSerializer.Serialize(crse);
            return await httpClient.PutAsJsonAsync<string>("instructors/AddInstructor", json);
        }

        public async Task<HttpResponseMessage> DeleteInstructor(Guid id)
        {
            return await httpClient.DeleteAsync("instructors/DeleteInstructor/" + id);
        }

        public async Task<HttpResponseMessage> AddCourseForInstructor(Instructor inst, string id)
        {
            return await httpClient.PutAsJsonAsync("instructors/AddCourse/" + inst.Id + "/" + id, false);
        }

    }

}