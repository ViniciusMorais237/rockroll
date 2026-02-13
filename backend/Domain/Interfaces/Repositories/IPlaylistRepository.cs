using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Entities.DTOs.Queries;
using backend.Domain.Entities.Infrastructure;

namespace backend.Domain.Interfaces.Repositories
{
    public interface IPlaylistRepository
    {
        Task<int> CriarPlaylist(Playlist playlist);
        Task<Playlist?> ObterPlaylistPorId(int id);

        Task<IEnumerable<Playlist>?> ObterPlaylistsPorIdUsuario(int idUsuario);



        Task<IEnumerable<Musica?>?> ObterMusicasPlaylist(int id);
        Task<bool> InserirMusicaPlaylist(int idMusica, int idPlaylist);
    }
}