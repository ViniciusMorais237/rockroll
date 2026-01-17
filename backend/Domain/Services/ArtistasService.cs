using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;

namespace backend.Domain.Services
{
    public class ArtistasService : IArtistasService
    {
        private readonly IArtistasRepository _ArtistasRepository;
        private readonly IArquivoService _arquivoService;

        public ArtistasService(IArtistasRepository ArtistasRepository, IArquivoService arquivoService)
        {
            _ArtistasRepository = ArtistasRepository;
            _arquivoService = arquivoService;
        }

        public async Task<bool> AdicionarArtista(CriarArtistaCommand command)
        {
            var imagem = string.Empty;
            if (command.Foto != null)
                imagem = await _arquivoService.ArmazenarERetornarCaminho(command.Foto, "Imagens");

            return await _ArtistasRepository.AdicionarArtista(Artista.Criar(command.Nome, imagem));
        }

        public async Task<Artista> ObterArtistaPorId(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Artista>> ObterArtistasPorPesquisa(string pesquisa)
        {
            throw new NotImplementedException();
        }
    }
}