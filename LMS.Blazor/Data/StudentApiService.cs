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
    public class StudentApiService
    {
        private string baseUrl;
        private HttpClient httpClient;

        public StudentApiService(IConfiguration config)
        {
            baseUrl = config.GetValue<string>("ApiBaseURI");
            httpClient = new HttpClient() { BaseAddress = new Uri(baseUrl) };
        }        

        public async Task<Student[]> GetStudents()
        {
            return await httpClient.GetFromJsonAsync<Student[]>("students");
        }

        public async Task<Student> GetStudent(string id)
        {
            try 
            {
                return await httpClient.GetFromJsonAsync<Student>("students/GetStudent/" + id);
            }
            catch
            {
                return new Student();
            }
        }

        public async Task<HttpResponseMessage> AddStudent(Student stud)
        {
            var json = JsonSerializer.Serialize(stud);
            return await httpClient.PutAsJsonAsync<string>("students/AddStudent", json);
        }

        public async Task<HttpResponseMessage> DeleteStudent(Guid id)
        {
            return await httpClient.DeleteAsync("students/DeleteStudent/" + id);
        }

        public async Task<HttpResponseMessage> AddCourseForStudent(Student stud, string id)
        {
            return await httpClient.PutAsJsonAsync("students/AddCourse/" + stud.Id + "/" + id, false);
        }
    }

}