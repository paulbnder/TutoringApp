using TutoringApp.Models;
using TutoringApp.Services;
using TutoringApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace TutoringApp.ViewModels
{
    public class TeacherOverviewViewModel : BaseViewModel
    {
        private Teacher _selectedTeacher;
        public ObservableCollection<Teacher> Teachers { get; }

        public Command LoadTeachersCommand { get; }
        public Command AddTeacherCommand { get; }

        public Command<Teacher> TeacherTapped { get; }



        public TeacherOverviewViewModel()
        {
            Title = "Browse";
            Teachers = new ObservableCollection<Teacher>();
            LoadTeachersCommand = new Command(async () => await ExecuteLoadTeachersCommand());

            TeacherTapped = new Command<Teacher>(OnTeacherSelected);

            AddTeacherCommand = new Command(OnAddTeacher);
        }

        async Task ExecuteLoadTeachersCommand()
        {
            IsBusy = true;
            try
            {
                Teachers.Clear();
                var teachers = await TeacherDataStore.GetItemsAsync(true);
                foreach (var teacher in teachers)
                {
                    Teachers.Add(teacher);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }


        public void OnAppearing()
        {
            IsBusy = true;
            SelectedTeacher = null;
        }

        public Teacher SelectedTeacher
        {
            get => _selectedTeacher;
            set
            {
                SetProperty(ref _selectedTeacher, value);
                OnTeacherSelected(value);
            }
        }

        private async void OnAddTeacher(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewTeacherPage));
        }


        async void OnTeacherSelected(Teacher teacher)
        {
            if (teacher == null)
            {
                return;

            }

            // This will push the TeacherDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(TeacherDetailPage)}?{nameof(TeacherDetailViewModel.TeacherId)}={teacher.Id}");
        }

       
    }
}
