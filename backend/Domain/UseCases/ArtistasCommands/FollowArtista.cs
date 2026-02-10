using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.Infrastructure;
using backend.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace backend.Domain.UseCases.ArtistasCommands
{
    public class FollowArtista
    {
        private readonly IArtistasRepository _artistasRepository;

        public FollowArtista(IArtistasRepository artistasRepository)
        {
            _artistasRepository = artistasRepository;
        }

        public async Task<bool> Executar(int idArtista, int idUsuario)
        {
            //obter usuario (Jwt??)
            return await _artistasRepository.FollowArtista(idArtista, idUsuario);
        }
    }
}