using RollWithIt.Models;

namespace RollWithIt.Views.Lessons;

public partial class ShowSubLesson : ContentPage
{
	public ShowSubLesson(SubLesson subLesson)
	{
		InitializeComponent();
        BindingContext = subLesson;

    }
}