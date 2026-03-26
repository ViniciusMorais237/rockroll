using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Interfaces.Services
{
    public interface IPasswordService
    {
        string HashearSenha(string senha);
        bool VerificarSenha(string senhaDigitada, string senhaHash);
    }
}