using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers
{
    [Route("api/[controller]")]
    public class RollController : ControllerBase
    {
        private readonly IRollService _rollService;
        public RollController(IRollService rollService)
        {
            _rollService = rollService;
        }
        [HttpGet("obter-info-musica/{id}")]
        public async Task<IActionResult> ObterInfoMusicaPorId(int id)
        {
            return Ok(await _rollService.ObterInfoMusicaPorId(id));
        }

        [HttpPost("inserir-musica")]
        public async Task<IActionResult> InserirMusica(CriarMusicaCommand command)
        {
            return Ok(await _rollService.InserirMusica(command));
        }

        [HttpGet("obter-musica/{url}")]
        public async Task<IActionResult> ObterMusicaPorUrl(string url)
        {
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/storage", url);

            if(!System.IO.File.Exists(caminho)) return NotFound();

            var stream = new FileStream(caminho, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 64 * 1024, useAsync: true);

            return File(stream, "audio/mpeg", enableRangeProcessing: true);
        }
    }
}