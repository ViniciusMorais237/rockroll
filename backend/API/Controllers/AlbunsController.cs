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

        [HttpPost("criar-album/{idArtista}")]
        public async Task<IActionResult> CriarAlbum(int idArtista, CriarAlbumCommand command,
        [FromServices] CriarAlbum _criarAlbum)
        {
            return Ok(await _criarAlbum.Executar(idArtista, command));
        }
    }
}