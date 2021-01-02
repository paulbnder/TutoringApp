using System;
using System.Collections.Generic;

namespace LanguageTeacherApp.Models
{
    public class Teacher
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Occupation { get; set; }

        public string NativeLanguage { get; set; }

        public string CountryOfOrigin { get; set; }

        public List<string> Subjects { get; set; }

        public string ProfilePictureSource { get; set; }
    }
}
