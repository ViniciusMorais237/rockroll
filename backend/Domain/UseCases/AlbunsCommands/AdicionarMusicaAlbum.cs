using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.DTOs;
using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;

namespace backend.Domain.UseCases.AlbunsCommands
{
    public class AdicionarMusicaAlbum
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IRollRepository _rollRepository;
        private readonly IArquivoService _arquivoService;

        public AdicionarMusicaAlbum(IAlbumRepository albumRepository, IRollRepository rollRepository, IArquivoService arquivoService)
        {
            _albumRepository = albumRepository;
            _rollRepository = rollRepository;
            _arquivoService = arquivoService;
        }

        public async Task<ApiResponse<bool>> Executar(int idAlbum, int idMusica)
        {
            var musica = _rollRepository.ObterInfoMusicaPorId(idMusica);
            if (musica == null) return new ApiResponse<bool>
            {
                StatusCode = 404,
                Mensagem = $"Musica com id '{idMusica} não encontrada'"
            };

            var insert = await _albumRepository.AdicionarMusicasAlbum(idAlbum, idMusica);
            return insert
            ? new ApiResponse<bool>
            {
                StatusCode = 202,
                Mensagem = "Sucesso"

            }
            : new ApiResponse<bool>
            {
                StatusCode = 400,
                Mensagem = "Não foi possivel inserir música no álbum"
            };
        }

    }
}