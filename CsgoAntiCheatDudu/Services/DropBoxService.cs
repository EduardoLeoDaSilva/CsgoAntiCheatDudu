using System.Net.Http.Headers;
using System.Text;
using CsgoAntiCheatDudu.Utils;
using Newtonsoft.Json;

namespace CsgoAntiCheatDudu.Services
{
    public class DropboxService : IDropboxService
    {

        private readonly ImageHandler _imageHandler;

        public DropboxService()
        {
            _imageHandler = new ImageHandler();
        }

        public async Task<DropbBoxResponseSave> SendImage(IFormFile image, string playerName)
        {
            var path = $"/cs/{DateTime.Now.ToString("yy-MM-dd")}/{playerName}/{image.FileName}";

            var bytesImage = _imageHandler.GetBytesFromImage(image);

            var dropBoxModel = new DropBoxUploadModel { Path = path, Mode = "add", AutoRename = true, Mute = false, Strict_Conflict = false };

            var content = new ByteArrayContent(bytesImage);
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://content.dropboxapi.com/2/files/upload"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Add("Dropbox-API-Arg", JsonConvert.SerializeObject(dropBoxModel).ToLower());
                request.Content.Headers.Remove("Content-type");
                request.Content.Headers.Add("Content-type", "application/octet-stream");
                message = await _httpClient.SendAsync(request);
            }
            var responseJson = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DropbBoxResponseSave>(responseJson);
        }

        public async Task<DropbBoxResponseSave> SendImage(byte[] image, string playerName, string mapName)
        {
            var path = $"/cs/{DateTime.Now.ToString("yy-MM-dd")}/{playerName}/{mapName}/{Guid.NewGuid()}.jpg";



            var dropBoxModel = new DropBoxUploadModel { Path = path, Mode = "add", AutoRename = true, Mute = false, Strict_Conflict = false };

            var content = new ByteArrayContent(image);
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://content.dropboxapi.com/2/files/upload"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Add("Dropbox-API-Arg", JsonConvert.SerializeObject(dropBoxModel).ToLower());
                request.Content.Headers.Remove("Content-type");
                request.Content.Headers.Add("Content-type", "application/octet-stream");
                message = await _httpClient.SendAsync(request);
            }
            var responseJson = await message.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DropbBoxResponseSave>(responseJson);
        }


        public async Task<string> DeleteForlderOrArq(string playerName)
        {
            var path = $"/cs/{DateTime.Now.ToString("yy-MM-dd")}/{playerName}/";


            var dropBoxModel = new DropBoxBaseModel { Path = path };

            var content = new StringContent(JsonConvert.SerializeObject(dropBoxModel).ToLower());
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://api.dropboxapi.com/2/files/delete_v2"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Remove("Content-type");
                message = await _httpClient.SendAsync(request);
            }
            return await message.Content.ReadAsStringAsync();
        }


        public async Task<DropBoxResponseSharedAndTemporaryLink> GetTemporaryLink(string pathArquivo)
        {
            //var path = $"/dudteste/lojinha/{pathArquivo}/";


            var dropBoxModel = new DropBoxBaseModel { Path = pathArquivo };

            var content = new StringContent(JsonConvert.SerializeObject(dropBoxModel).ToLower(), Encoding.UTF8, "application/json");
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://api.dropboxapi.com/2/files/get_temporary_link"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Remove("Content-type");
                request.Content.Headers.Add("Content-type", "application/json");
                message = await _httpClient.SendAsync(request);
            }
            var responseJson = await message.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<DropBoxResponseSharedAndTemporaryLink>(responseJson);
            return model;
        }

        public async Task<DropBoxResponseSharedAndTemporaryLink> GetSharedLink(string pathArquivo)
        {
            //var path = $"/dudteste/lojinha/{pathArquivo}/";


            var dropBoxModel = new DropBoxRequestSharedLinkModel { Path = pathArquivo };

            var content = new StringContent(JsonConvert.SerializeObject(dropBoxModel).ToLower(), Encoding.UTF8, "application/json");
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://api.dropboxapi.com/2/sharing/create_shared_link_with_settings"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Remove("Content-type");
                request.Content.Headers.Add("Content-type", "application/json");
                message = await _httpClient.SendAsync(request);
            }
            var responseJson = await message.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<DropBoxResponseSharedAndTemporaryLink>(responseJson);
            if (model == null)
            {
            }
            return model;
        }


        public async Task<string> GetThumbNail(string pathArquivo)
        {
            var path = $"/dudteste/lojinha/{pathArquivo}/";


            var dropBoxModel = new DropBoxBaseModel { Path = path };

            var content = new StringContent(JsonConvert.SerializeObject(dropBoxModel).ToLower());
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://content.dropboxapi.com/2/files/get_thumbnail_v2"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Remove("Content-type");
                message = await _httpClient.SendAsync(request);
            }
            return await message.Content.ReadAsStringAsync();
        }

        public async Task<string> Download(string pathArquivo)
        {
            var path = $"/dudteste/lojinha/{pathArquivo}/";


            var dropBoxModel = new DropBoxBaseModel { Path = path };

            var content = new StringContent(JsonConvert.SerializeObject(dropBoxModel).ToLower());
            HttpResponseMessage message;

            using (var request = new HttpRequestMessage(HttpMethod.Post, "https://content.dropboxapi.com/2/files/download"))
            using (var _httpClient = new HttpClient())
            {
                // request.Headers.Clear();
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", "Qu-u5klpwxAAAAAAAAAAlFn8Naaep2p00TcallvtGpctJVeyL549OC386GVtm6YO");
                request.Content = content;
                request.Content.Headers.Remove("Content-type");
                message = await _httpClient.SendAsync(request);
            }
            return await message.Content.ReadAsStringAsync();
        }


    }



    public class DropBoxUploadModel : DropBoxBaseModel
    {
        public string Mode { get; set; }
        public bool AutoRename { get; set; }
        public bool Mute { get; set; }
        public bool Strict_Conflict { get; set; }
    }

    public class DropBoxBaseModel
    {
        public string Path { get; set; }

    }

    public class DropbBoxResponseSave
    {
        public string Name { get; set; }
        public string Path_lower { get; set; }
        public string Path_display { get; set; }
        public string Id { get; set; }
        public string Rev { get; set; }
        public int Size { get; set; }
        public bool Is_downloadable { get; set; }
    }

    public class DropBoxResponseSharedAndTemporaryLink
    {
        public string Link { get; set; }
        public string Url { get; set; }
        public Error Error { get; set; }
    }

    public class DropBoxRequestSharedLinkModel
    {
        public string Path { get; set; }
        public SettingSharedLinkModel Settings { get; }
    }

    public class SettingSharedLinkModel
    {
        public string Requested_visibility { get; } = "public";
        public string Audience { get; } = "public";
        public string Access { get; } = "viewer";


    }


    public class Error
    {
        public SharedeLinkError Shared_link_already_exists { get; set; }
    }

    public class SharedeLinkError
    {
        public MetaData MetaData { get; set; }
    }

    public class MetaData
    {
        public string Url { get; set; }
    }
}
