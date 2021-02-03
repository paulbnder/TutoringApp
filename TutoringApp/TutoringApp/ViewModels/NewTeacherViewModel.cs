using TutoringApp.Models;
using TutoringApp.Services;
using TutoringApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using TutoringApp.Views;

namespace TutoringApp.ViewModels
{
    class NewTeacherViewModel : BaseViewModel
    {
        private string name;
        private string occupation;
        private DateTime birthday;
        private Gender gender;
        private string subjects;
        private string profilePictureSource;

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        public NewTeacherViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }
        public DateTime Birthday
        {
            get => birthday;
            set => SetProperty(ref birthday, value);
        }
        public Gender Gender
        {
            get => gender;
            set => SetProperty(ref gender, value);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Occupation
        {
            get => occupation;
            set => SetProperty(ref occupation, value);
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(Name)
                && !String.IsNullOrWhiteSpace(Occupation);
        }

        private async void OnSave()
        {
            Teacher newTeacher = new Teacher()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Occupation = Occupation
            };

            await TeacherDataStore.AddItemAsync(newTeacher);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

    }
}
