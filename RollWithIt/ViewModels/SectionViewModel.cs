using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RollWithIt.ViewModels
{
    public class SectionViewModel
    {
        // Command property to handle section click
        public ICommand ShowSectionCommand { get; private set; }

        public SectionViewModel()
        {
            // Initialize the command
            ShowSectionCommand = new Command(OnShowSection);
        }

        // Method to execute when the section is clicked
        private void OnShowSection()
        {
            // Navigate to the show page for this section
            // You can implement the navigation logic here
            // For example:
            // await Application.Current.MainPage.Navigation.PushAsync(new ShowSectionPage());
        }
    }
}
