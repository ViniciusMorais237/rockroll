using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;

namespace backend.Domain.Services
{
    public class RollService : IRollService
    {
        private readonly IRollRepository _rollRepository;
        private readonly IArquivoService _arquivoService;
        public RollService(IRollRepository rollRepository, IArquivoService arquivoService)
        {
            _rollRepository = rollRepository;
            _arquivoService = arquivoService;

        }

        public async Task<bool> InserirMusica(CriarMusicaCommand command)
        {
            var urlMusica = await _arquivoService.ArmazenarERetornarCaminho(command.FileMusica, "Musicas");

            var musica = Musica.Criar(
                command.Titulo,
                urlMusica,
                [new(command.IdArtista, command.NomeArtista)]);

            return await _rollRepository.InserirMusica(musica);
        }


        public async Task<Musica> ObterInfoMusicaPorId(int id)
        {
            return await _rollRepository.ObterInfoMusicaPorId(id);
        }
    }
}