using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using PM02G1_Ejercicio2._2.Models;
using System.Collections.Generic;

namespace PM02G1_Ejercicio2._2
{
    public partial class MainPage : ContentPage
    {
        // Colección para almacenar los elementos del ListView
        ObservableCollection<string> itemsCollection = new ObservableCollection<string>();

        private ListaApi datos;

        public MainPage()
        {
            InitializeComponent();

            // Asignar la colección al ListView
            itemsListView.ItemsSource = itemsCollection;
            datos = new ListaApi();
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

        private void CargarApi(object sender, EventArgs e)
        {
            Solicitud();
        }


        public async void Solicitud() {

            var requet = new HttpRequestMessage();
            requet.RequestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
            requet.Method = HttpMethod.Get;

            requet.Headers.Add("Accpet", "application/json");

            var client = new HttpClient();
            //respuesta de la solicitud
            HttpResponseMessage response = await client.SendAsync(requet);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                string content = await response.Content.ReadAsStringAsync();

                // convertir el Json a String, osea deserealizarlo
                var resultado = JsonConvert.DeserializeObject<List<ListaApi>>(content);
                //Cargarle los datos al listview
                itemsListView.ItemsSource = resultado;


            }

        
        }

    }
}
