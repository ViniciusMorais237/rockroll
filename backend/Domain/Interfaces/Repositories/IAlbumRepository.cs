using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Queries;

namespace backend.Domain.Interfaces.Repositories
{
    public interface IAlbumRepository
    {
        Task<int> CriarAlbum(Album album);
        Task<bool> ObterAlbumPorId(int id);
        Task<bool> EditarAlbum(Album album);
        Task<bool> ExcluirAlbum(int idAlbum);

        Task<IEnumerable<AlbumResponse>?> ObterAlbunsPorIdArtista(int idArtista);
        Task<bool> ObterAlbuns(string filtro, string nomeCampo);

        Task<bool> AdicionarMusicasAlbum(int idAlbum, int idMusica);
        Task<bool> AdicionarMusicasAlbum(int idAlbum, IEnumerable<int> idMusicas);
        Task<bool> ExcluirMusicaAlbum(int idAlbum, int idMusica);
    }
}