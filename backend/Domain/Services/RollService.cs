using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs;
using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;

namespace backend.Domain.Services
{
    public class RollService : IRollService
    {
        private readonly IWebHostEnvironment _env;
        private readonly IRollRepository _rollRepository;
        public RollService(IRollRepository rollRepository, IWebHostEnvironment env)
        {
            _rollRepository = rollRepository;
            _env = env;

        }

        public async Task<bool> InserirMusica(CriarMusicaCommand command)
        {
            var urlMusica = await ArmazenarERetornarUrlMusica(command.FileMusica);

            var musica = Musica.Criar(
                command.Titulo,
                urlMusica,
                [new(command.IdArtista, command.NomeArtista)]);

            return await _rollRepository.InserirMusica(musica);
        }


        public async Task<Musica> ObterMusicaPorId(int id)
        {
            return await _rollRepository.ObterMusicaPorId(id);
        }

        private async Task<string> ArmazenarERetornarUrlMusica(IFormFile musica)
        {
            var storagePath = Path.Combine(_env.WebRootPath, "Storage");

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(musica.FileName)}";
            var filePath = Path.Combine(storagePath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await musica.CopyToAsync(stream);

            return $"/Storage/{fileName}";
        }

    }
}