﻿using frontend.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Repository
{
    public class CargoRepository : ICargoRepository
    {
        public HttpClient Client { get; set; }

        public CargoRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(Global.IP_ADRESS);
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Cargo>> GetAllCargos()
        {
            var url = "/cargos/all";
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var cargos = JsonConvert.DeserializeObject<IEnumerable<Cargo>>(jsonString);
            return cargos;
        }

        public async Task<Cargo> GetCargoById(int id)
        {
            var url = "/cargos/get/" + id;
            HttpResponseMessage response = Client.GetAsync(url).Result;
            string jsonString = "";

            if (response.IsSuccessStatusCode)
            {
                jsonString = await response.Content.ReadAsStringAsync();
            }

            var cargo = JsonConvert.DeserializeObject<Cargo>(jsonString);
            return cargo;
        }

        public async void AddCargo(Cargo cargo)
        {
            var url = "/cargos/add";
            var jsonString = JsonConvert.SerializeObject(cargo);
            await Client.PostAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void UpdateCargo(Cargo cargo)
        {
            var url = "/cargos/update";
            var jsonString = JsonConvert.SerializeObject(cargo);
            await Client.PutAsync(url, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async void DeleteCargo(int id)
        {
            var url = "/cargos/delete/" + id;
            await Client.DeleteAsync(url);
        }
    }
}