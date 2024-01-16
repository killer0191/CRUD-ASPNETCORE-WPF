using AppEscritorio.environments;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AppEscritorio.Models;
using System.Linq;

namespace AppEscritorio.services
{
    public static class PersonaService
    {
        public static async Task<PersonaModel> FindPersonaByIdentificacion(string identificacion)
        {
            try
            {
                using (HttpResponseMessage response = await ApiConfig.Client.GetAsync($"{ApiConfig.ApiBaseUrl}/directorio/findPersonaByIdentificacion/{identificacion}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        List<PersonaModel> personas = JsonConvert.DeserializeObject<List<PersonaModel>>(json);
                        return personas.FirstOrDefault();
                    }
                    else
                    {
                        Console.WriteLine($"Error al obtener la persona por identificación. Estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la persona por identificación: {ex}");
            }

            return null;
        }

        public static async Task<List<PersonaModel>> FindPersonas()
        {
            try
            {
                using (HttpResponseMessage response = await ApiConfig.Client.GetAsync($"{ApiConfig.ApiBaseUrl}/directorio/findPersonas"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string json = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<PersonaModel>>(json);
                    }
                    else
                    {
                        Console.WriteLine($"Error al obtener las personas. Estado: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las personas: {ex}");
            }

            return null;
        }


        public static async Task<bool> DeletePersonaByIdentificacion(string identificacion)
        {
            try
            {
                using (HttpResponseMessage response = await ApiConfig.Client.DeleteAsync($"{ApiConfig.ApiBaseUrl}/directorio/deletePersonaByIdentificacion/{identificacion}"))
                {
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                Console.WriteLine($"Error al eliminar la persona por identificación: {ex}");
            }

            return false;
        }

        public static async Task<bool> StorePersona(PersonaModel persona)
        {
            try
            {
                string json = JsonConvert.SerializeObject(persona);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                using (HttpResponseMessage response = await ApiConfig.Client.PostAsync($"{ApiConfig.ApiBaseUrl}/directorio/storePersona", content))
                {
                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                Console.WriteLine($"Error al almacenar la persona: {ex}");
            }

            return false;
        }

    }
}
