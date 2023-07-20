using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace PM02G1_Ejercicio2._2.Models
{
            public class ListaApi
        {
                    [JsonProperty("userId")]
                public long UserId { get; set; }

                [JsonProperty("id")]
                public long Id { get; set; }

                [JsonProperty("title")]
                public string Title { get; set; }

                [JsonProperty("body")]
                public string Body { get; set; }
        }
}
