using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace TutoringApp.ViewModels
{
    [QueryProperty(nameof(TeacherId), nameof(TeacherId))]
    class TeacherDetailViewModel : BaseViewModel
    {
        private string _teacherId;
        private string _name;
        private int _age;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public int Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }
        public string TeacherId
        {
            get
            {
                return _teacherId;
            }
            set
            {
                _teacherId = value;
                LoadTeacherById(value);
            }
        }

        public async void LoadTeacherById(string teacherId)
        {
            try
            {
                var teacher = await TeacherDataStore.GetItemAsync(teacherId);
                Name = teacher.Name;
                Age = teacher.Age;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Teacher");
            }
        }
    }
}
