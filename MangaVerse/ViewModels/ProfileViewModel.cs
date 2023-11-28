using System.ComponentModel;
using MangaVerse.ViewModels;

namespace MangaVerse
{
    public class ProfileViewModel : BaseViewModel
    {
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
    }
}
