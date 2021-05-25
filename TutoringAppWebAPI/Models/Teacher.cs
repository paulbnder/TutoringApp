using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TutoringAppWebAPI.Models
{
    public class Teacher
    {
        //[Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        //[Required]
        public DateTime Birthday { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var calculatedAge = today.Year - Birthday.Year;
                if (Birthday.Date > today.AddYears(-calculatedAge)) calculatedAge--;

                return calculatedAge;
            }
        }

        //[Required]
        public Gender Gender { get; set; }

        //[Required]
        public string Occupation { get; set; }

        public string AboutMeText { get; set; }

        public string NativeLanguage { get; set; }

        public string CountryOfOrigin { get; set; }

        public List<string> Subjects { get; set; }

        //[Required]
        public string ProfilePictureSource { get; set; }
    }
}
