﻿using TutoringApp.Models;
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


            List<string> subjectsMathsPhysics = new List<string>(new string[] { "Maths", "Physics" });
            List<string> subjectsMaths = new List<string>(new string[] { "Maths" });
            List<string> subjectsEnglishSpanish = new List<string>(new string[] { "English", "Spanish" });
            List<string> subjectsMathsPhysicsChemistry = new List<string>(new string[] { "Maths", "Physics", "Chemistry" });
            List<string> subjectsEnglishSpanishFrench = new List<string>(new string[] { "English", "Spanish", "French" });

            teachers = new List<Teacher>()
            {
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Larisa Samuel", Birthday = new DateTime(2000, 8, 14), NativeLanguage="English", Occupation="Student", Subjects=subjectsMathsPhysics,
                ProfilePictureSource="https://source.unsplash.com/ROJFuWCsfmA/100x100"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Peter Gray", Birthday = new DateTime(1995, 10, 4), NativeLanguage="German", Occupation="Student", Subjects=subjectsMathsPhysicsChemistry,
                ProfilePictureSource="https://source.unsplash.com/c_GmwfHBDzk/100x100"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Loretta Dylan", Birthday = new DateTime(1998, 2, 1), NativeLanguage="Spanish", Occupation="Librarian", Subjects=subjectsEnglishSpanishFrench,
                ProfilePictureSource="https://source.unsplash.com/JN0SUcTOig0/100x100"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Brynne Starr", Birthday = new DateTime(2002, 7, 30), NativeLanguage="English", Occupation="Web Designer", Subjects=subjectsMaths,
                ProfilePictureSource="https://source.unsplash.com/tTdC88_6a_I/100x100"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Roland Sandy", Birthday = new DateTime(2001, 11, 18), NativeLanguage="Japanese", Subjects=subjectsEnglishSpanishFrench,
                ProfilePictureSource="https://source.unsplash.com/YUu9UAcOKZ4/100x100"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Ronan Kurtis", Birthday = new DateTime(1990, 5, 17), NativeLanguage="English", Occupation="Student", Subjects=subjectsEnglishSpanish,
                ProfilePictureSource="https://source.unsplash.com/v2aKnjMbP_k/100x100"}
            };
        }

        public async Task<Teacher> GetItemAsync(string id)
        {
            return await Task.FromResult(teachers.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Teacher>> GetItemsAsync(bool forceRefresh = false)
        {
            //return await Task.FromResult(teachers);

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
            //teachers.Add(teacher);

            //return await Task.FromResult(true);


            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            string json = JsonConvert.SerializeObject(teacher);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            response = await client.PostAsync(uri, content);


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
