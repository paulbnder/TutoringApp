using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringAppWebAPI.Interfaces;
using TutoringAppWebAPI.Models;

namespace TutoringAppWebAPI.Services
{
    public class TeacherRepository : IRepository<Teacher>
    {
        readonly List<Teacher> teachers;
        public TeacherRepository()
        {
            List<string> subjectsMathsPhysics = new List<string>(new string[] { "Maths", "Physics" });
            List<string> subjectsMaths = new List<string>(new string[] { "Maths" });
            List<string> subjectsEnglishSpanish = new List<string>(new string[] { "English", "Spanish" });
            List<string> subjectsMathsPhysicsChemistry = new List<string>(new string[] { "Maths", "Physics", "Chemistry" });
            List<string> subjectsEnglishSpanishFrench = new List<string>(new string[] { "English", "Spanish", "French" });


            teachers = new List<Teacher>()
            {
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Larisa Samuel", Birthday = new DateTime(2000, 8, 14), NativeLanguage="English", Occupation="Student", Subjects=subjectsMathsPhysics,
                ProfilePictureSource="https://source.unsplash.com/ROJFuWCsfmA/300x300"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Peter Gray", Birthday = new DateTime(1995, 10, 4), NativeLanguage="German", Occupation="Student", Subjects=subjectsMathsPhysicsChemistry,
                ProfilePictureSource="https://source.unsplash.com/c_GmwfHBDzk/300x300"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Loretta Dylan", Birthday = new DateTime(1998, 2, 1), NativeLanguage="Spanish", Occupation="Librarian", Subjects=subjectsEnglishSpanishFrench,
                ProfilePictureSource="https://source.unsplash.com/JN0SUcTOig0/300x300"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Brynne Starr", Birthday = new DateTime(2002, 7, 30), NativeLanguage="English", Occupation="Web Designer", Subjects=subjectsMaths,
                ProfilePictureSource="https://source.unsplash.com/tTdC88_6a_I/300x300"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Roland Sandy", Birthday = new DateTime(2001, 11, 18), NativeLanguage="Japanese", Subjects=subjectsEnglishSpanishFrench,
                ProfilePictureSource="https://source.unsplash.com/YUu9UAcOKZ4/300x300"},
                new Teacher { Id = Guid.NewGuid().ToString(), Name = "Ronan Kurtis", Birthday = new DateTime(1990, 5, 17), NativeLanguage="English", Occupation="Student", Subjects=subjectsEnglishSpanish,
                ProfilePictureSource="https://source.unsplash.com/v2aKnjMbP_k/300x300", AboutMeText="Etiam imperdiet imperdiet orci. Morbi vestibulum volutpat enim. Phasellus volutpat, metus eget egestas mollis, lacus lacus blandit dui, id egestas quam mauris ut lacus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Nullam quis ante Nullam accumsan lorem in dui. Fusce a quam. In turpis. Etiam vitae tortor. Pellentesque commodo eros a enim."}
            };
        }

        public async Task<Teacher> GetItemAsync(string id)
        {
            return await Task.FromResult(teachers.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Teacher>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(teachers);
        }

        public List<Teacher> GetItems(bool forceRefresh = false)
        {
            return teachers;
        }

        public async Task<bool> AddItemAsync(Teacher teacher)
        {
            teachers.Add(teacher);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Teacher teacher)
        {
            var oldTeacher = teachers.Where((Teacher arg) => arg.Id == teacher.Id).FirstOrDefault();
            teachers.Remove(oldTeacher);
            teachers.Add(teacher);

            return await Task.FromResult(true);
        }

        public void DeleteItemAsync(string id)
        {
            var oldTeacher = teachers.Where((Teacher arg) => arg.Id == id).FirstOrDefault();
            teachers.Remove(oldTeacher);

        }

        public async Task<bool> DoesTeacherExist(string id)
        {
            return await Task.FromResult(teachers.Any(teacher => teacher.Id == id));
        }
    }
}
