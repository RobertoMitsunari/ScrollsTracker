namespace ScrollsTracker.Api.Services.Interface
{
    public interface IImagemService
    {
        public string SalvarImagemBase64(byte[] imagemBase64, string nomeArquivo);
    }
}
