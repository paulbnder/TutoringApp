using System;
using System.Collections.Generic;
using System.Text;

namespace TutoringApp.ViewModels
{
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
