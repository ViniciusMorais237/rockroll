using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Entities;

namespace backend.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        Task<bool> CadastrarUsuario(Usuario usuario);
    }
}