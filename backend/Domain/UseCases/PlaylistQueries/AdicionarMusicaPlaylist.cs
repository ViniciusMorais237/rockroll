using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.DTOs;
using backend.Domain.Interfaces.Repositories;

namespace backend.Domain.UseCases.PlaylistQueries
{
    public class AdicionarMusicaPlaylist
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IRollRepository _musicasRepository;

        public AdicionarMusicaPlaylist(IPlaylistRepository playlistRepository, IRollRepository musicasRepository)
        {
            _playlistRepository = playlistRepository;
            _musicasRepository = musicasRepository;
        }

        public async Task<ApiResponse<object?>> Executar(int idMusica, int idPlaylist)
        {
            var musica = await _musicasRepository.ObterInfoMusicaPorId(idMusica);
            if (musica == null) return new ApiResponse<object?>()
            {
                Mensagem = "Musica não encontrada",
                StatusCode = 400
            };

            var insercao = await _playlistRepository.InserirMusicaPlaylist(idMusica, idPlaylist);
            if (!insercao)
                return new ApiResponse<object?> { StatusCode = 400, Mensagem = "Não foi possivel inserir objeto na base" };


            return new ApiResponse<object?> { Mensagem = "Música inserida com sucesso", StatusCode = 201 };

        }



        
    }
}