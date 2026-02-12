using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.UseCases.AlbunsQueries;
using backend.Domain.UseCases.AlbunsCommands;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using backend.Domain.Entities.DTOs.Commands;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlbunsController : ControllerBase
    {
        [HttpGet("obter-albuns/{idArtista}")]
        public async Task<IActionResult> ObterAlbunsPorIdArtista(int idArtista,
        [FromServices] ObterAlbunsPorIdArtista _obterAlbunsPorIdArtista)
        {
            return Ok(await _obterAlbunsPorIdArtista.Executar(idArtista));
        }

        [HttpGet("obter-album/{id}")]
        public async Task<IActionResult> ObterAlbum(int id,
        [FromServices] ObterAlbum _obterAlbum)
        {
            return Ok(await _obterAlbum.Executar(id));
        }

        [HttpPost("criar-album/{idArtista}")]
        public async Task<IActionResult> CriarAlbum(int idArtista, CriarAlbumCommand command,
        [FromServices] CriarAlbum _criarAlbum)
        {
            return Ok(await _criarAlbum.Executar(idArtista, command));
        }

        [HttpPost("adicionar-musica-album/{idAlbum}")]
        public async Task<IActionResult> AdicionarMusicaAlbum(int idAlbum, int idMusica,
        [FromServices] AdicionarMusicaAlbum _adicionarMusicaAlbum)
        {
            return Ok(await _adicionarMusicaAlbum.Executar(idAlbum, idMusica));
        }

        [HttpDelete("excluir-musica-album/{idAlbum}/{idMusica}")]
        public async Task<IActionResult> CriarAlbum(int idAlbum, int idMusica,
        [FromServices] ExcluirMusicaAlbum _excluirMusicaAlbum)
        {
            return Ok(await _excluirMusicaAlbum.Executar(idAlbum, idMusica));
        }
    }
}