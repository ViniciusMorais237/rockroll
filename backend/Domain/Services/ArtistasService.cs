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
        private readonly IWebHostEnvironment _env;
        private readonly IArtistasRepository _ArtistasRepository;
        private readonly IArquivoService _arquivoService;
        private readonly IUoW _uow;

        public ArtistasService(IArtistasRepository ArtistasRepository, IArquivoService arquivoService, IUoW uow, IWebHostEnvironment env)
        {
            _ArtistasRepository = ArtistasRepository;
            _arquivoService = arquivoService;
            _uow = uow;
            _env = env;
        }

        public async Task<bool> AdicionarArtista(CriarArtistaCommand command)
        {
            var imagem = string.Empty;

            await _uow.Begin();

            try
            {
                if (command.Foto != null)
                    imagem = await _arquivoService.ArmazenarERetornarCaminho(command.Foto, "Images");

                var insercao = await _ArtistasRepository.AdicionarArtista(Artista.Criar(null, command.Nome, command.Premium, imagem));

                await _uow.Commit();

                return insercao;
            }
            catch (Exception)
            {
                var caminhoImagem = Path.Combine(
                    _env.ContentRootPath,
                    "wwwroot",
                    "storage",
                    "Images",
                    imagem);

                if (File.Exists(caminhoImagem))
                    File.Delete(caminhoImagem);

                await _uow.Rollback();

                throw;
            }
        }

        public async Task<IEnumerable<Artista>> ObterArtistasPorPesquisa(string pesquisa)
        {
            return await _ArtistasRepository.ObterArtistasPorPesquisa(pesquisa);
        }
    }
}