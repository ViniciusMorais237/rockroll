using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Interfaces.Services;
using backend.Domain.UseCases.ArtistasQueries;
using Microsoft.AspNetCore.Mvc;

namespace backend.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArtistasController : ControllerBase
{
    private readonly IArtistasService _artistaService;
    private readonly ObterArtistaPorId _obterArtistaPorId;
    public ArtistasController(IArtistasService artistaService, ObterArtistaPorId obterArtistaPorId)
    {
        _artistaService = artistaService;
        _obterArtistaPorId = obterArtistaPorId;
    }

    [HttpPost("adicionar-artista")]
    public async Task<IActionResult> AdicionarArtista(CriarArtistaCommand command)
    {
        return Ok(await _artistaService.AdicionarArtista(command));
    }

    [HttpGet("obter-artista/{id}")]
    public async Task<IActionResult> ObterArtistaPorId(int id)
    {
        return Ok(await _obterArtistaPorId.Executar(id));
    }

    [HttpGet("obter-artistas/{pesquisa}")]
    public async Task<IActionResult> ObterArtistasPorPesquisa(string pesquisa)
    {
        return Ok(await _artistaService.ObterArtistasPorPesquisa(pesquisa));
    }
}
