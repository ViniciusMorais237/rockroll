using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;

namespace backend.Domain.Services
{
    public class RollService : IRollService
    {
        private readonly IUoW _uow;
        private readonly IWebHostEnvironment _env;
        private readonly IRollRepository _rollRepository;
        private readonly IArquivoService _arquivoService;
        public RollService(IRollRepository rollRepository, IArquivoService arquivoService, IWebHostEnvironment env, IUoW uow)
        {
            _rollRepository = rollRepository;
            _arquivoService = arquivoService;
            _env = env;
            _uow = uow;
        }

        public async Task<bool> DeletarMusica(int id)
        {
            return await _rollRepository.DeletarMusica(id);
        }

        public async Task<int> InserirMusica(CriarMusicaCommand command)
        {
            var urlMusica = "";
            var urlImagem = "";
            try
            {
                await _uow.Begin();

                urlMusica = await _arquivoService
                    .ArmazenarERetornarCaminho(command.FileMusica, "Musicas");

                if (command.FileImagem != null)
                    urlImagem = await _arquivoService
                    .ArmazenarERetornarCaminho(command.FileImagem, "Images");

                var musica = Musica.Criar(
                    command.Titulo,
                    command.IdArtista,
                    urlMusica,
                    urlImagem);

                var idMusica = await _rollRepository.InserirMusica(musica);

                await _uow.Commit();

                return idMusica;
            }
            catch (Exception)
            {
                var caminhoMusica = Path.Combine(
                    _env.ContentRootPath,
                    "wwwroot",
                    "storage",
                    "Musicas",
                    urlMusica);

                var caminhoImagem = Path.Combine(
                _env.ContentRootPath,
                "wwwroot",
                "storage",
                "Musicas",
                urlMusica);

                if (File.Exists(caminhoMusica))
                    File.Delete(caminhoMusica);

                if (File.Exists(caminhoImagem))
                    File.Delete(caminhoImagem);

                await _uow.Rollback();

                throw;
            }
        }
        public async Task<Musica?> ObterInfoMusicaPorId(int id)
        {
            return await _rollRepository.ObterInfoMusicaPorId(id);
        }
    }
}