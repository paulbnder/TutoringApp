using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TutoringApp.ViewModels
{
    [QueryProperty(nameof(TeacherId), nameof(TeacherId))]
    class TeacherDetailViewModel : BaseViewModel
    {
        private string _teacherId;

        public string TeacherId
        {
            get
            {
                return _teacherId;
            }
            set
            {
                _teacherId = value;
            }
        }
    }
}
