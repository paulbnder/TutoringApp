using LanguageTeacherApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageTeacherApp.Services
{
    public class TeacherDataStore
    {
        readonly List<Teacher> teachers;
        public TeacherDataStore()
        {
            List<string> subjectsMathsPhysics = new List<string>(new string[] { "Maths", "Physics" });
            List<string> subjectsMaths = new List<string>(new string[] { "Maths" });
            List<string> subjectsEnglishSpanish = new List<string>(new string[] { "Maths", "Physics" });
            List<string> subjectsMathsPhysicsChemistry = new List<string>(new string[] { "Maths", "Physics" });
            List<string> subjectsEnglishSpanishFrench = new List<string>(new string[] { "Maths", "Physics" });


            teachers = new List<Teacher>()
            {
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Larisa Samuel", NativeLanguage="English", Occupation="Student", Subjects=subjectsMathsPhysics,
                ProfilePictureSource="https://source.unsplash.com/ROJFuWCsfmA/100x100"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Peter Gray", NativeLanguage="German", Occupation="Student", Subjects=subjectsMathsPhysicsChemistry,
                ProfilePictureSource="https://source.unsplash.com/c_GmwfHBDzk/100x100"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Loretta Dylan", NativeLanguage="Spanish", Occupation="Librarian", Subjects=subjectsEnglishSpanishFrench,
                ProfilePictureSource="https://source.unsplash.com/JN0SUcTOig0/100x100"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Brynne Starr", NativeLanguage="English", Occupation="Web Designer", Subjects=subjectsMaths,
                ProfilePictureSource="https://source.unsplash.com/tTdC88_6a_I/100x100"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Roland Sandy", NativeLanguage="Japanese", Subjects=subjectsEnglishSpanishFrench,
                ProfilePictureSource="https://source.unsplash.com/YUu9UAcOKZ4/100x100"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Ronan Kurtis", NativeLanguage="English", Occupation="Student", Subjects=subjectsEnglishSpanish,
                ProfilePictureSource="https://source.unsplash.com/v2aKnjMbP_k/100x100"}
            };
        }

        public async Task<Teacher> GetTeacherAsync(string id)
        {
            return await Task.FromResult(teachers.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(teachers);
        }
    }
}
