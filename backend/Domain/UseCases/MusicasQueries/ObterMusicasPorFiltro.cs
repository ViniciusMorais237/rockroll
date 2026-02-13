using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.DTOs.Queries;
using backend.Domain.Interfaces.Repositories;

namespace backend.Domain.UseCases.MusicasQueries
{
    public class ObterMusicasPorFiltro
    {
        private readonly IRollRepository _musicasRepository;

        public ObterMusicasPorFiltro(IRollRepository musicasRepository)
        {
            _musicasRepository = musicasRepository;
        }

        public async Task<IEnumerable<MusicaSelect?>?> Executar(string? filtro)
        {
            return await _musicasRepository.ObterSelectMusicasPorFiltro(filtro);
        }
    }
}