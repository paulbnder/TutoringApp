using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TutoringApp.MarkupExtensions
{
    class EmbeddedImage : IMarkupExtension
    {
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            return ImageSource.FromResource("LanguageTeacherApp.Images.person1.jpg");
        }
    }
}
