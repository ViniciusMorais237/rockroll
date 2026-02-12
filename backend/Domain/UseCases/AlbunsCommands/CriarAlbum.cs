using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;

namespace backend.Domain.UseCases.AlbunsCommands
{
    public class CriarAlbum
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IRollRepository _rollRepository;
        private readonly IArquivoService _arquivoService;
        private readonly IUoW _uow;

        public CriarAlbum(IArquivoService arquivoService, IAlbumRepository albumRepository, IRollRepository rollRepository, IUoW uow)
        {
            _rollRepository = rollRepository;
            _albumRepository = albumRepository;
            _arquivoService = arquivoService;
            _uow = uow;
        }

        public async Task<ApiResponse<int?>> Executar(int idArtista, CriarAlbumCommand command)
        {
            string? imagem = "";
            var response = new ApiResponse<int?>();
            try
            {
                await _uow.Begin();

                if (command.Foto is not null)
                    imagem = await _arquivoService.ArmazenarERetornarCaminho(command.Foto, "Images");

                if (command.IdsMusicas is not null && command.IdsMusicas.Any())
                {
                    var idsInvalidos = await VerificarSeMusicasExistem(command.IdsMusicas);
                    if (idsInvalidos.Any())
                    {
                        response.StatusCode = 404;
                        response.Mensagem = $"Não foi possivel encontrar musicas com id(s) : '{idsInvalidos}'";
                        response.Resultado = null;

                        throw new Exception();
                    }
                    ;
                }

                var album = Album.Criar(idArtista, command.Titulo, imagem, command.IdsMusicas);

                var idRetornado = await _albumRepository.CriarAlbum(album);
                album.DefinirId(idRetornado);

                await album.PersistirMusicas(_albumRepository);

                await _uow.Commit();

                return new ApiResponse<int?>()
                {
                    StatusCode = 200,
                    Mensagem = "Sucesso",
                    Resultado = idRetornado
                };
            }
            catch (Exception)
            {
                await _uow.Rollback();

                var caminhoImagem = _arquivoService.RetornarCaminho("Images", imagem);
                if (File.Exists(caminhoImagem))
                    File.Delete(caminhoImagem);

                return response;
            }
        }

        private async Task<IEnumerable<int>> VerificarSeMusicasExistem(IEnumerable<int> idsMusicas)
        {
            var musicas = await _rollRepository.ObterInfoMusicasPorIds(idsMusicas) ?? [];

            var idsEncontrados = new HashSet<int?>(musicas.Select(m => m.Id));

            return idsMusicas
            .Where(id => !idsEncontrados.Contains(id))
            .ToList();
        }
    }
}