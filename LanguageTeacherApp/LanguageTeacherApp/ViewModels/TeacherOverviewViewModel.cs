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
        public new TeacherDataStore DataStore => DependencyService.Get<TeacherDataStore>();

        private Teacher _selectedTeacher;
        public Command LoadTeachersCommand { get; }
        public Command AddTeacherCommand { get; }

        public Command<Teacher> TeacherTapped;


        public ObservableCollection<Teacher> Teachers { get; }

        public TeacherOverviewViewModel()
        {
            Title = "Browse";
            Teachers = new ObservableCollection<Teacher>();
            LoadTeachersCommand = new Command(async () => await ExecuteLoadTeachersCommand());

            TeacherTapped = new Command<Teacher>(OnTeacherSelected);

            AddTeacherCommand = new Command(OnAddTeacher);
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

        async void OnTeacherSelected(Teacher teacher)
        {
            Console.WriteLine("Teacher Tapped");
            if (teacher == null)
            {
                Console.WriteLine("teacher is null");
                return;

            }
            Console.WriteLine("Teacher not null");

            await Shell.Current.GoToAsync(nameof(NewItemPage));

            // This will push the TeacherDetailPage onto the navigation stack
            // await Shell.Current.GoToAsync($"{nameof(TeacherDetailPage)}?{nameof(TeacherDetailViewModel.TeacherId)}={teacher.Id}");
        }

        private async void OnAddTeacher(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewTeacherPage));
        }
    }
}
