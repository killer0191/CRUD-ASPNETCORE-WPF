using AppEscritorio.environments;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppEscritorio.Models;

namespace AppEscritorio.services
{
    public class FacturaService
    {
        public static async Task<List<FacturaModel>> FindFacturasByPersona(string identificacion)
        {
            try
            {
                using (HttpResponseMessage response = await ApiConfig.Client.GetAsync($"{ApiConfig.ApiBaseUrl}/factura/findFacturasByPersona/{identificacion}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResponse = await response.Content.ReadAsStringAsync();
                        List<FacturaModel> facturas = JsonConvert.DeserializeObject<List<FacturaModel>>(jsonResponse);
                        return facturas;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                Console.WriteLine($"Error al encontrar las facturas por persona: {ex}");
            }

            return null;
        }

        public static async Task<bool> StoreFactura(FacturaModel factura)
        {
            try
            {
                string json = JsonConvert.SerializeObject(factura);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await ApiConfig.Client.PostAsync($"{ApiConfig.ApiBaseUrl}/factura/storeFactura", content))
                {
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                Console.WriteLine($"Error al almacenar la factura: {ex}");
            }

            return false;
        }
    }

}
