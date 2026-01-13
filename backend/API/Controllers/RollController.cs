using backend.Domain.Entities.DTOs;
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
        [HttpGet]
        public async Task<IActionResult> ObterMusicaPorId(int id)
        {
            return Ok(await _rollService.ObterMusicaPorId(id));
        }

        [HttpPost]
        public async Task<IActionResult> InserirMusica(CriarMusicaCommand command)
        {
            return Ok(await _rollService.InserirMusica(command));
        }
    }
}