namespace RollWithIt.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
        BindingContext = this; // Set the binding context to this page
    }

    // Property to hold user data (replace this with actual user data)
    public string UserData { get; set; } = "User Name: John Doe\nEmail: john.doe@example.com\nRole: Administrator";
}