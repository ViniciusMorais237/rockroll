using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Entities.DTOs.Queries;
using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;

namespace backend.Domain.UseCases.PlaylistQueries
{
    public class CriarPlaylist
    {
        private readonly IPlaylistRepository _playlistRepository;
        private readonly IArquivoService _arquivoService;
        private readonly IUoW _uow;

        public CriarPlaylist(IPlaylistRepository playlistRepository, IArquivoService arquivoService, IUoW uow)
        {
            _playlistRepository = playlistRepository;
            _arquivoService = arquivoService;
            _uow = uow;
        }

        public async Task<ApiResponse<PlaylistSelect>> Executar(CriarPlaylistCommand command)
        {
            var nomeImagem = "";

            try
            {
                await _uow.Begin();

                if (command.Imagem != null)
                    nomeImagem = await _arquivoService.ArmazenarERetornarCaminho(command.Imagem, "Images");

                var playlist = Playlist.Criar(command.IdUsuario, command.Titulo, nomeImagem, null);

                var idPlaylist = await _playlistRepository.CriarPlaylist(playlist);

                await _uow.Commit();

                return new ApiResponse<PlaylistSelect>
                {
                    Resultado = new PlaylistSelect { Id = idPlaylist, Titulo = playlist.Titulo },
                    Mensagem = "Playlist criada com sucesso",
                    StatusCode = 200
                };
            }
            catch (Exception)
            {
                var caminhoImagem = _arquivoService.RetornarCaminho("Images", nomeImagem);
                
                await _uow.Rollback();

                if (File.Exists(caminhoImagem))
                    File.Delete(caminhoImagem);
                throw;
            }
        }

    }
}