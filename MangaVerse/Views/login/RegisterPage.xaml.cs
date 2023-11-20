namespace MangaVerse.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }
        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Task.Delay(2000);
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}