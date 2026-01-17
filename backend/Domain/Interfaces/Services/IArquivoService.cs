using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Interfaces.Services
{
    public interface IArquivoService
    {
        Task<string> ArmazenarERetornarCaminho(IFormFile arquivo, string pasta);
    }
}