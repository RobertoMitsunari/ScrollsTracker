using ScrollsTracker.Domain.Interfaces;

namespace ScrollsTracker.Application.Services
{
    //TODO: Talvez seja removido!
    public class ImagemService : IImagemService
    {
        public string SalvarImagemBase64(byte[] imagemBase64, string nomeArquivo)
        {
            try
            {
                string pastaDestino = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "imagens");

                if (!Directory.Exists(pastaDestino))
                {
                    Directory.CreateDirectory(pastaDestino);
                }

                string caminhoArquivo = Path.Combine(pastaDestino, nomeArquivo);

                File.WriteAllBytes(caminhoArquivo, imagemBase64);

                return $"/imagens/{nomeArquivo}";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar a imagem: " + ex.Message);
            }
        }
    }
}
