using System;
using System.Collections.Generic;

namespace TutoringApp.Models
{
    public class Teacher
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public enum _Gender { male, female }
        public _Gender Gender { get; set; }

        public string Occupation { get; set; }

        public string NativeLanguage { get; set; }

        public string CountryOfOrigin { get; set; }

        public List<string> Subjects { get; set; }

        public string ProfilePictureSource { get; set; }
    }
}
