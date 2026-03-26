using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace backend.Domain.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordHasher<string> _hasher = new();
        public string HashearSenha(string senha)
        {
            return _hasher.HashPassword(null, senha);
        }

        public bool VerificarSenha(string senhaDigitada, string senhaHash)
        {
            var resultado = _hasher.VerifyHashedPassword(null, senhaHash, senhaDigitada);

            return resultado == PasswordVerificationResult.Success;
        }
    }
}