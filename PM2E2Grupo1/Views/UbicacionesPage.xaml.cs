using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PM2E2Grupo1.Views
{
    public partial class UbicacionesPage : ContentPage
    {
        public List<Location> ubicaciones { get; set; }
        private string latitudSeleccionada;
        private string longitudSeleccionada;

        public UbicacionesPage()
        {
            InitializeComponent();
            PopulateList();
        }

        private void PopulateList()
        {
            ubicaciones = new List<Location>()
            {
                new Location { titulo = "Paris, Francia", latitud = "48.8566", longitud = "2.3522" },
                new Location { titulo = "Dubai, EAU", latitud = "25.2048", longitud = "55.2708" },
                new Location { titulo = "Nueva York, EUA", latitud = "40.71427", longitud = "-74.00597" },
            };

            ubicacionesListView.ItemsSource = ubicaciones;

            ubicacionesListView.ItemSelected += (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;
                var location = (Location)e.SelectedItem;
                latitudSeleccionada = location.latitud;
                longitudSeleccionada = location.longitud;
            };
        }

        public async void OnMapaClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(latitudSeleccionada) && !string.IsNullOrEmpty(longitudSeleccionada))
            {
                double latitud = double.Parse(latitudSeleccionada);
                double longitud = double.Parse(longitudSeleccionada);

                await Navigation.PushAsync(new UbicacionMapa(latitud, longitud));
            }
            else
            {
                await DisplayAlert("Error", "No se ha seleccionado una ubicación.", "OK");
            }
        }

       
}

    public class Location
    {
        public string titulo { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string display => $"Lat: {latitud}, Lon: {longitud}";
    }
}
