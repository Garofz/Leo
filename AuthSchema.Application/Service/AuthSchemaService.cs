using AuthSchema.Application.Model.Request;
using AuthSchema.Application.Model.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AuthSchema.Application.Service
{
    public class AuthSchemaService : IAuthSchemaService
    {
        string URL = "https://167.114.160.121:41001"; 
        public AuthSchemaService()
        {
            
        }

        public async Task<ILoginUsuarioResponse> LoginUsuario(LoginUsuarioRequest model, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"{URL}/user/login";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer {token}");

                HttpResponseMessage response = await client.PostAsJsonAsync<LoginUsuarioRequest>(requestUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    ILoginUsuarioResponse userResponse = JsonConvert.DeserializeObject<ILoginUsuarioResponse>(responseContent);

                    return userResponse;
                }
                else
                {
                    Console.WriteLine("Erro na solicitação: " + response.StatusCode);
                    return null;
                }
            }
        }

        public async Task<IUserResponse> NovaSenhaUsuario(NewUserPasswordRequest model, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                string requestUrl = $"{URL}/user/senha";

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue($"Bearer {token}");

                HttpResponseMessage response = await client.PostAsJsonAsync<NewUserPasswordRequest>(requestUrl, model);

                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();

                    IUserResponse userResponse = JsonConvert.DeserializeObject<IUserResponse>(responseContent);

                    return userResponse;
                }
                else
                {
                    Console.WriteLine("Erro na solicitação: " + response.StatusCode);
                    return null;
                }
            }
        }
    }
}
