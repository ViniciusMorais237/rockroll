using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Interfaces.Repositories;

namespace backend.Domain.UseCases.ArtistasQueries
{
    public class ObterArtistaPorId
    {
        private readonly IArtistasRepository _artistasRepository;
        private readonly IRollRepository _musicasRepository;
        public ObterArtistaPorId(IArtistasRepository artistasRepository, IRollRepository musicasRepository)
        {
            _artistasRepository = artistasRepository;
            _musicasRepository = musicasRepository;
        }

        public async Task<Artista?> Executar(int id)
        {
            var artistaDb = await _artistasRepository.ObterArtistaPorId(id);
            if (artistaDb == null) return null;

            var artista = new Artista(artistaDb.Id, artistaDb.Nome, artistaDb.Premium, artistaDb.UrlFoto);

            var musicas = await _musicasRepository.ObterInfoMusicasPorArtistaId(artista.Id);
            if (musicas != null && musicas.Any())
                artista.AdicionarMusicas(musicas!);

            return artista;
        }
    }
}