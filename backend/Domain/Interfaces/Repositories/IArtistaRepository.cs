using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.Infrastructure;

namespace backend.Domain.Interfaces.Repositories;

public interface IArtistasRepository
{
    Task<bool> AdicionarArtista(Artista artista);
    Task<ArtistaDB?> ObterArtistaPorId(int id);
    Task<IEnumerable<Artista>> ObterArtistasPorPesquisa(string pesquisa);

}