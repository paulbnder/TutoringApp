using TutoringApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;

namespace TutoringApp.Services
{
    public class TeacherDataStore: IDataStore<Teacher>
    {
        HttpClient client;

        List<Teacher> teachers;
        public TeacherDataStore()
        {
            client = new HttpClient();
        }

        public async Task<Teacher> GetItemAsync(string id)
        {
            return await Task.FromResult(teachers.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Teacher>> GetItemsAsync(bool forceRefresh = false)
        {

            teachers = new List<Teacher>();

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    teachers = JsonConvert.DeserializeObject<List<Teacher>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return teachers;
        }

        public async Task<Object> AddItemAsync(Teacher teacher)
        {
            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            string json = JsonConvert.SerializeObject(teacher);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                Debug.WriteLine("Teacher successfully saved.");
            }

            return response;
        }

        public async Task<bool> UpdateItemAsync(Teacher teacher)
        {
            var oldTeacher = teachers.Where((Teacher arg) => arg.Id == teacher.Id).FirstOrDefault();
            teachers.Remove(oldTeacher);
            teachers.Add(teacher);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldTeacher = teachers.Where((Teacher arg) => arg.Id == id).FirstOrDefault();
            teachers.Remove(oldTeacher);

            return await Task.FromResult(true);
        }

    }
}
