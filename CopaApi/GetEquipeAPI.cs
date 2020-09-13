using CopaApi.Domain.Entities.DTOs;
using CopaApi.Domain.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CopaApi
{
    public class GetEquipeAPI : IServiceEquipe
    {
        HttpClient client = new HttpClient();
        public async Task<List<EquipeDTo>> GetEquipesAsync()
        {
            try
            {
                string url = "https://raw.githubusercontent.com/delsonvictor/testetecnico/master/equipes.json";
                var response = await client.GetStringAsync(url);
                var equipes = JsonConvert.DeserializeObject<List<EquipeDTo>>(response);
                return equipes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
