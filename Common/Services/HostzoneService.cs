using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services
{
    public class HostzoneService
    {
        public async Task<string> Logar()
        {
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://painel.hostzone.com.br/index.php"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                var dataContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("ulogin", "dudkiller"),
                    new KeyValuePair<string, string>("upassword", "02121441"),
                    new KeyValuePair<string, string>("lang", "-"),
                    new KeyValuePair<string, string>("login", "Entrar")
                });

                request.Content = dataContent;
                request.Content.Headers.Remove("Content-type");
                request.Content.Headers.Add("content-type", "application/x-www-form-urlencoded");
                request.Content.Headers.Add("authority", "painel.hostzone.com.br");
                request.Content.Headers.TryAddWithoutValidation("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7,es-ES;q=0.6,es;q=0.5,en-XA;q=0.4");
                request.Content.Headers.TryAddWithoutValidation("cache-control", "max-age=0");
                request.Content.Headers.TryAddWithoutValidation("origin", "https://painel.hostzone.com.br");
                request.Content.Headers.TryAddWithoutValidation("referer", "https://painel.hostzone.com.br/index.php");

                message = await _httpClient.SendAsync(request);

                if (message.IsSuccessStatusCode)
                    Console.WriteLine("Login efetuado com sucesso");

                var tt = message.Headers.FirstOrDefault(x => x.Key == "Set-Cookie");
                return tt.Value.First();
            }
        }

        public async Task KikarJogador(string nome, string cookie)
        {

            HttpResponseMessage message;
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://painel.hostzone.com.br/home.php?m=gamemanager&p=log&home_id-mod_id-ip-port=6644-3799-177.54.148.107-27422"))
            using (var _httpClient = new HttpClient(handler))
            {
                // request.Headers.Clear();
                var dataContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("command", $"kick {nome}"),
                    new KeyValuePair<string, string>("remote_send_rcon_command", "Enviar+comando"),
                });

                // request.Headers.Clear();
                var dataContent2 = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("command", $"say Rala pau no cu do caralho {nome}"),
                    new KeyValuePair<string, string>("remote_send_rcon_command", "Enviar+comando"),
                });

                request.Content = dataContent;
                request.Content.Headers.Remove("Content-type");


                var name = cookie.Split("=").First();
                var value = cookie.Split("=")[1].Split(";").First();

                cookieContainer.Add(new Uri("https://painel.hostzone.com.br"), new Cookie(name, value) { Domain = "painel.hostzone.com.br" });


                request.Content.Headers.Add("content-type", "application/x-www-form-urlencoded");
                request.Content.Headers.Add("authority", "painel.hostzone.com.br");
                request.Content.Headers.TryAddWithoutValidation("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7,es-ES;q=0.6,es;q=0.5,en-XA;q=0.4");
                request.Content.Headers.TryAddWithoutValidation("cache-control", "max-age=0");
                request.Content.Headers.TryAddWithoutValidation("origin", "https://painel.hostzone.com.br");
                request.Content.Headers.TryAddWithoutValidation("referer", "https://painel.hostzone.com.br/index.php");
                message = await _httpClient.SendAsync(request);


            }
            if (message.IsSuccessStatusCode)
                Console.WriteLine($"Jogador {nome} kickado");

        }


        public async Task KickMessage(string kickMessage, string cookie)
        {

            HttpResponseMessage message;
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://painel.hostzone.com.br/home.php?m=gamemanager&p=log&home_id-mod_id-ip-port=6644-3799-177.54.148.107-27422"))
            using (var _httpClient = new HttpClient(handler))
            {
                // request.Headers.Clear();
                var dataContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("command", $"say {kickMessage}"),
                    new KeyValuePair<string, string>("remote_send_rcon_command", "Enviar+comando"),
                });


                request.Content = dataContent;
                request.Content.Headers.Remove("Content-type");


                var name = cookie.Split("=").First();
                var value = cookie.Split("=")[1].Split(";").First();

                cookieContainer.Add(new Uri("https://painel.hostzone.com.br"), new Cookie(name, value) { Domain = "painel.hostzone.com.br" });


                request.Content.Headers.Add("content-type", "application/x-www-form-urlencoded");
                request.Content.Headers.Add("authority", "painel.hostzone.com.br");
                request.Content.Headers.TryAddWithoutValidation("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7,es-ES;q=0.6,es;q=0.5,en-XA;q=0.4");
                request.Content.Headers.TryAddWithoutValidation("cache-control", "max-age=0");
                request.Content.Headers.TryAddWithoutValidation("origin", "https://painel.hostzone.com.br");
                request.Content.Headers.TryAddWithoutValidation("referer", "https://painel.hostzone.com.br/index.php");
                message = await _httpClient.SendAsync(request);


            }
        }


        public async Task<string> StatusMatch(string cookie)
        {

            HttpResponseMessage message;
            var cookieContainer = new CookieContainer();
            using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://painel.hostzone.com.br/home.php?m=gamemanager&p=log&home_id-mod_id-ip-port=6644-3799-177.54.148.107-27422"))
            using (var _httpClient = new HttpClient(handler))
            {
                // request.Headers.Clear();
                var dataContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("command", $"status"),
                    new KeyValuePair<string, string>("remote_send_rcon_command", "Enviar+comando"),
                });


                request.Content = dataContent;
                request.Content.Headers.Remove("Content-type");


                var name = cookie.Split("=").First();
                var value = cookie.Split("=")[1].Split(";").First();

                cookieContainer.Add(new Uri("https://painel.hostzone.com.br"), new Cookie(name, value) { Domain = "painel.hostzone.com.br" });


                request.Content.Headers.Add("content-type", "application/x-www-form-urlencoded");
                request.Content.Headers.Add("authority", "painel.hostzone.com.br");
                request.Content.Headers.TryAddWithoutValidation("accept-language", "pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7,es-ES;q=0.6,es;q=0.5,en-XA;q=0.4");
                request.Content.Headers.TryAddWithoutValidation("cache-control", "max-age=0");
                request.Content.Headers.TryAddWithoutValidation("origin", "https://painel.hostzone.com.br");
                request.Content.Headers.TryAddWithoutValidation("referer", "https://painel.hostzone.com.br/index.php");
                message = await _httpClient.SendAsync(request);

                if (message.IsSuccessStatusCode)
                    return await message.Content.ReadAsStringAsync();

                return "";
            }
        }
    }
}
