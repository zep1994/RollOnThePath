using RollWithIt.Models;

namespace RollWithIt.Views.Lessons;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class SectionShowPage : ContentPage
{
    public SectionShowPage(LessonSection section)
    {
        InitializeComponent();
        BindingContext = section;
    }
}