using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PM02G1_Ejercicio2._2
{
    public partial class MainPage : ContentPage
    {
        // Colección para almacenar los elementos del ListView
        ObservableCollection<string> itemsCollection = new ObservableCollection<string>();

        public MainPage()
        {
            InitializeComponent();

            // Asignar la colección al ListView
            itemsListView.ItemsSource = itemsCollection;
        }

        // Evento cuando se presiona el botón para agregar un nuevo elemento
        private void OnAddItemButtonClicked(object sender, EventArgs e)
        {
            string newItem = newItemEntry.Text;
            if (!string.IsNullOrWhiteSpace(newItem))
            {
                // Agregar el nuevo elemento a la colección y limpiar el Entry
                itemsCollection.Add(newItem);
                newItemEntry.Text = string.Empty;
            }
        }
    }
}
