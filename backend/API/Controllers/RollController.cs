using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Interfaces.Services;
using backend.Domain.UseCases.MusicasQueries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace backend.API.Controllers
{
    [Route("api/[controller]")]
    public class RollController : ControllerBase
    {
        private readonly IRollService _rollService;
        private readonly ObterMusicasPorFiltro _obterMusicasPorFiltro;
        public RollController(IRollService rollService, ObterMusicasPorFiltro obterMusicasPorFiltro)
        {
            _rollService = rollService;
            _obterMusicasPorFiltro = obterMusicasPorFiltro;
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

        [HttpGet("obter-musicas")]
        public async Task<IActionResult> ObterMusicasPorFiltro([FromQuery] string? filtro)
        {
            //adicionar filtro em outros campos a partir de 2 musicas -- por enquanto so no nome da musica e do usuario
            return Ok(await _obterMusicasPorFiltro.Executar(filtro));
        }

        [HttpGet("obter-arquivo/{local}/{url}")]
        public async Task<IActionResult> ObterMusicaPorUrl(string local, string url)
        {
            var caminho = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "storage", local, url);

            if (!System.IO.File.Exists(caminho)) return NotFound();

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(caminho, out string contentType))
            {
                contentType = "application/octet-stream";
            }

            var stream = new FileStream(caminho, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 64 * 1024, useAsync: true);

            return File(stream, contentType, enableRangeProcessing: true);
        }
    }
}