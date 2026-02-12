using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.DTOs;
using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;

namespace backend.Domain.UseCases.AlbunsCommands
{
    public class ExcluirMusicaAlbum
    {
        private readonly IAlbumRepository _albumRepository;

        public ExcluirMusicaAlbum(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }
        public async Task<ApiResponse<bool>> Executar(int idAlbum, int idMusica)
        {
            var exclusao = await _albumRepository.ExcluirMusicaAlbum(idAlbum, idMusica);
            return exclusao
            ? new ApiResponse<bool> { StatusCode = 200, Mensagem = "Sucesso" }
            : new ApiResponse<bool> { StatusCode = 400, Mensagem = "Nao foi possivel excluir" };
        }
    }
}