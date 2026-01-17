using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Commands;

namespace backend.Domain.Interfaces.Services
{
    public interface IArtistasService
    {
        Task<bool> AdicionarArtista(CriarArtistaCommand command);
        Task<Artista> ObterArtistaPorId(int id);
        Task<IEnumerable<Artista>> ObterArtistasPorPesquisa(string pesquisa);
    }
}