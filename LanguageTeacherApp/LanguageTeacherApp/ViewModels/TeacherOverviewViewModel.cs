﻿using LanguageTeacherApp.Models;
using LanguageTeacherApp.Services;
using LanguageTeacherApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LanguageTeacherApp.ViewModels
{
    class TeacherOverviewViewModel : BaseViewModel
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
            Console.WriteLine("Beginning of ExexuteLoadTeachers");
            try
            {
                Teachers.Clear();
                Console.WriteLine("Cleared Teachers Collection, next comment after GetTeachersAsync");

                var teachers = await DataStore.GetTeachersAsync(true);
                Console.WriteLine("Stored Teachers collection in 'teachers'");

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
            if (teacher == null)
                return;

            // This will push the TeacherDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(TeacherDetailPage)}?{nameof(TeacherDetailViewModel.TeacherId)}={teacher.Id}");
        }

        private async void OnAddTeacher(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }
    }
}