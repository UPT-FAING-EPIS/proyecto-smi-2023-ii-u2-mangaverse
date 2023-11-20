using System.Collections.ObjectModel;
using System.ComponentModel;
using MangaVerse.Models;

namespace MangaVerse
{
    public class DescubreViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Descubre> DescubreItems { get; set; }

        public DescubreViewModel()
        {
            DescubreItems = new ObservableCollection<Descubre>();
            DescubreImages();
        }

        private void DescubreImages()
        {
            DescubreItems = new ObservableCollection<Descubre>
            {
                new Descubre
                {
                    Image = "diasporaiser.jpg",
                    Title = "Diasporaiser",
                    Author = "Ondori Nukui",
                    Descripcion = "asdasdasdasdasdasdasdasdas",
                },
                new Descubre
                {
                    Image = "tsurukoreturnsthefavor.jpg",
                    Title = "Tsuruko Returns the Favor",
                    Author = "Yokoyama Hidari",
                    Descripcion = "asdasdasdasdasdasdasdasdas",
                },
                new Descubre
                {
                    Image = "wildstrawberry.jpg",
                    Title = "Wild Strawberry",
                    Author = "Ire Yonemoto",
                    Descripcion = "asdasdasdasdasdasdasdasdas",
                },
                new Descubre
                {
                    Image = "diasporaiser.jpg",
                    Title = "Diasporaiser",
                    Author = "Ondori Nukui",
                    Descripcion = "asdasdasdasdasdasdasdasdas",
                },
                new Descubre
                {
                    Image = "tsurukoreturnsthefavor.jpg",
                    Title = "Tsuruko Returns the Favor",
                    Author = "Yokoyama Hidari",
                    Descripcion = "asdasdasdasdasdasdasdasdas",
                },
                new Descubre
                {
                    Image = "wildstrawberry.jpg",
                    Title = "Wild Strawberry",
                    Author = "Ire Yonemoto",
                    Descripcion = "asdasdasdasdasdasdasdasdas",
                },
            };
        }

        // INotifyPropertyChanged para notificar a la vista de cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
