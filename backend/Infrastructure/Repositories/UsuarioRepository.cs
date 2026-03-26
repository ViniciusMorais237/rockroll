using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;
using backend.Domain.Entities.Infrastructure;
using backend.Domain.Interfaces.Repositories;
using backend.Infrastructure.Mapping;

namespace backend.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly RollDBContext _context;

        public UsuarioRepository(RollDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CadastrarUsuario(Usuario usuario)
        {
            var usuarioDb = new UsuarioDB
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                SenhaHash = usuario.SenhaHash,
                IsArtista = usuario.IsArtista,
                NomeArquivoImagem = usuario.NomeArquivoImagem
            };

            _context.Usuarios.Add(usuarioDb);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}