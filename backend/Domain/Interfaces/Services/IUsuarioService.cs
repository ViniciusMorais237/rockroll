using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities.DTOs.Commands;

namespace backend.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<bool> CadastrarUsuario(CriarUsuarioCommand command);
    }
}