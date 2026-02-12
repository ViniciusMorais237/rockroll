using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs;
using backend.Domain.Entities.DTOs.Queries;
using backend.Domain.Interfaces.Repositories;

namespace backend.Domain.UseCases.PlaylistQueries
{
    public class ObterPlaylist
    {
        private readonly IPlaylistRepository _playlistRepository;

        public ObterPlaylist(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public async Task<ApiResponse<Playlist>> Executar(int id)
        {
            var playlist = await _playlistRepository.ObterPlaylistPorId(id);

            if (playlist == null) return new ApiResponse<Playlist>
            {
                Mensagem = "Playlist não encontrada",
                StatusCode = 400
            };

            var musicas = await _playlistRepository.ObterMusicasPlaylist(id);
            
            if (musicas == null) return new ApiResponse<Playlist> { StatusCode = 200, Mensagem = "Não foi possivel carregar musicas", Resultado = playlist };

            playlist.AdicionarMusicas(musicas);

            return new ApiResponse<Playlist> { StatusCode = 200, Mensagem = "Sucesso", Resultado = playlist };
        }
    }
}