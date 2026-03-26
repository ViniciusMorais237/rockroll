using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("Cadastro")]
        public async Task<IActionResult> CadastrarUsuario(CriarUsuarioCommand command)
        {
            return Ok(await _usuarioService.CadastrarUsuario(command));
        }
    }
}