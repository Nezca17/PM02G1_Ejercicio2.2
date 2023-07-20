using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using PM02G1_Ejercicio2._2.Models;
using System.Collections.Generic;
using System.Numerics;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace PM02G1_Ejercicio2._2
{
    public partial class MainPage : ContentPage
    {
        // Colección para almacenar los elementos del ListView
        ObservableCollection<string> itemsCollection = new ObservableCollection<string>();

        public ListaApi datos;

        public MainPage()
        {
            InitializeComponent();

            // Asignar la colección al ListView
            itemsListView.ItemsSource = itemsCollection;
          
        }

        // Evento cuando se presiona el botón para agregar un nuevo elemento
        private async void OnAddItemButtonClicked(object sender, EventArgs e)
        {
            itemsListView.ItemsSource = "";
            await Post();
        }

        private async void CargarApi(object sender, EventArgs e)
        {
          await  Solicitud();
        }


        public async Task Solicitud() {

            var requet = new HttpRequestMessage();
            requet.RequestUri = new Uri($"https://jsonplaceholder.typicode.com/posts/");
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
        public async Task Post() {
            try
            {
                
                var requet = new HttpRequestMessage();
              await   DisplayAlert($"{long.Parse(txtId.Text)}","Prueba","OK");
                requet.RequestUri = new Uri($"https://jsonplaceholder.typicode.com/posts/{long.Parse(txtId.Text)}");
                requet.Method = HttpMethod.Get;

                requet.Headers.Add("Accpet", "application/json");

                var client = new HttpClient();
                //respuesta de la solicitud
                HttpResponseMessage response = await client.SendAsync(requet);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string content = await response.Content.ReadAsStringAsync();

                    // convertir el Json a String, osea deserealizarlo
                    var resultado = JsonConvert.DeserializeObject<ListaApi>(content);
                    
                    //Cargarle los datos al listview
                    itemsListView.ItemsSource = resultado.Id.ToString();
                    itemsListView.ItemsSource = resultado.Body;


                }
                else
                {

                    await DisplayAlert("Datos", "error", "Ok");
                }
                /*
                                requet.Headers.Add("Accpet", "application/json");

                                datos = new ListaApi {
                                    Id = long.Parse(txtId.Text),
                                UserId = long.Parse(txtUserId.Text),
                                Body = txtCuerpo.Text,
                                Title = txtTitulo.Text
                                };
                                var client = new HttpClient();
                                var json = JsonConvert.SerializeObject(datos);

                                var contentJson = new StringContent(json, Encoding.UTF8, "application/json");

                                var response = await client.PostAsync(requet.RequestUri, contentJson);

                                if(response.StatusCode == HttpStatusCode.OK)
                                {
                                    await DisplayAlert("Datos", "Se actualizo correctamente", "OK");
                                    txtCuerpo.Text = "";
                                    txtId.Text = "";
                                    txtTitulo.Text = "";
                                    txtUserId.Text = "";


                                }
                                else
                                {
                                    await DisplayAlert("Datos", "error", "Ok");
                                }*/

            }
            catch(Exception e) {
              await DisplayAlert("Datos", $"error{e}", "Ok");

            }

        }

    }
}
