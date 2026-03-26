using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Commands;
using backend.Domain.Interfaces.Repositories;
using backend.Domain.Interfaces.Services;

namespace backend.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IPasswordService _passwordService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IArquivoService _arquivoService;
        public UsuarioService(IUsuarioRepository usuarioRepository, IPasswordService passwordService, IArquivoService arquivoService)
        {
            _usuarioRepository = usuarioRepository;
            _passwordService = passwordService;
            _arquivoService = arquivoService;
        }
        public async Task<bool> CadastrarUsuario(CriarUsuarioCommand command)
        {
            var senhaHash = _passwordService.HashearSenha(command.Senha);

            var nomeArquivoImagem = await _arquivoService.ArmazenarERetornarCaminho(command.Imagem, "Images");

            var usuario = new Usuario
            {
                Nome = command.Nome,
                Email = command.Email,
                SenhaHash = senhaHash,
                IsArtista = command.IsArtista,
                NomeArquivoImagem = nomeArquivoImagem
            };

            return await _usuarioRepository.CadastrarUsuario(usuario);
        }
    }
}