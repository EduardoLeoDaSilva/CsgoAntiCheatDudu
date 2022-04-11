namespace CsgoAntiCheatDudu.Services
{
    public interface IDropboxService
    {
        Task<string> DeleteForlderOrArq(string pasta);
        Task<string> Download(string pathArquivo);
        Task<DropBoxResponseSharedAndTemporaryLink> GetSharedLink(string pathArquivo);
        Task<DropBoxResponseSharedAndTemporaryLink> GetTemporaryLink(string pathArquivo);
        Task<string> GetThumbNail(string pathArquivo);
        Task<DropbBoxResponseSave> SendImage(IFormFile image, string player);
        Task<DropbBoxResponseSave> SendImage(byte[] image, string player,string mapName);

    }
}
