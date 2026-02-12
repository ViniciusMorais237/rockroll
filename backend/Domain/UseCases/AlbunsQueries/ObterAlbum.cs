using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.DTOs;
using backend.Domain.Entities.DTOs.Queries;
using backend.Domain.Interfaces.Repositories;

namespace backend.Domain.UseCases.AlbunsQueries
{
    public class ObterAlbum
    {
        private readonly IAlbumRepository _albumRepository;

        public ObterAlbum(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<ApiResponse<AlbumResponse?>> Executar(int id)
        {
            var album = await _albumRepository.ObterAlbumPorId(id);
            if (album == null) return new ApiResponse<AlbumResponse?>
            {
                StatusCode = 404,
                Mensagem = $"Não foi possivel encontrar album com id : '{id}'"
            };

            return new ApiResponse<AlbumResponse?>
            {
                Mensagem = "Sucesso",
                Resultado = album,
                StatusCode = 200
            };

        }
    }
}