using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.DTOs;
using backend.Domain.Entities.DTOs.Queries;
using backend.Domain.Interfaces.Repositories;

namespace backend.Domain.UseCases.AlbunsQueries
{
    public class ObterAlbunsPorIdArtista
    {
        private readonly IAlbumRepository _albumRepository;

        public ObterAlbunsPorIdArtista(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<ApiResponse<IEnumerable<AlbumResponseResumido>>> Executar(int idArtista)
        {
            var albuns = await _albumRepository.ObterAlbunsPorIdArtista(idArtista);
            if (albuns == null) return new ApiResponse<IEnumerable<AlbumResponseResumido>>()
            {
                Mensagem = "Não foi possivel obter nenhum albúm",
                Resultado = null,
                StatusCode = 400
            };

            return new ApiResponse<IEnumerable<AlbumResponseResumido>>()
            {
                Mensagem = "Sucesso",
                Resultado = albuns,
                StatusCode = 200
            };
        }
    }
}