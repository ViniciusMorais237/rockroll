using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.UseCases.PlaylistQueries;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaylistsController : ControllerBase
    {
        private readonly CriarPlaylist _criarPlaylist;
        private readonly AdicionarMusicaPlaylist _adicionarMusicaPlaylist;
        // private readonly AdicionarMusicasPlaylist _adicionarMusicasPlaylist;

        public PlaylistsController(CriarPlaylist criarPlaylist, AdicionarMusicaPlaylist adicionarMusicaPlaylist)
        {
            _criarPlaylist = criarPlaylist;
            _adicionarMusicaPlaylist = adicionarMusicaPlaylist;
        }
        

        [HttpPost("criar-playlist")]
        public async Task<IActionResult> CriarPlaylist(CriarPlaylistCommand command)
        {
            return Ok(await _criarPlaylist.Executar(command));
        }

        [HttpPost("adicionar-musica-playlist")]
        public async Task<IActionResult> AdicionarMusicaPlaylist(int idMusica, int idPlaylist)
        {
            return Ok(await _adicionarMusicaPlaylist.Executar(idMusica, idPlaylist));
        }

        [HttpPost("adicionar-musicas-playlist")]
        public async Task<IActionResult> AdicionarMusicasPlaylist(List<int> idsMusicas)
        {
            throw new NotImplementedException();
            // return Ok(await _adicionarMusicasPlaylist.Executar(idsMusicas));
        }
    }
}