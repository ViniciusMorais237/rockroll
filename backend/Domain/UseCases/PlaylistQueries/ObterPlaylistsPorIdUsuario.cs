using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs;
using backend.Domain.Interfaces.Repositories;

namespace backend.Domain.UseCases.PlaylistQueries
{
    public class ObterPlaylistsPorIdUsuario
    {
        private readonly IPlaylistRepository _playlistRepository;

        public ObterPlaylistsPorIdUsuario(IPlaylistRepository playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }

        public async Task<ApiResponse<IEnumerable<Playlist>?>> Executar(int idUsuario)
        {
            var playlists = await _playlistRepository.ObterPlaylistsPorIdUsuario(idUsuario);

            if (playlists == null) return new ApiResponse<IEnumerable<Playlist>?>
            {
                StatusCode = 404,
                Mensagem = "Nenhuma playlist encontrada",
                Resultado = null
            };

            return new ApiResponse<IEnumerable<Playlist>?>
            {
                StatusCode = 200,
                Mensagem = "Sucesso",
                Resultado = playlists
            };
        }
    }
}