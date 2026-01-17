using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Domain.Interfaces.Services;

namespace backend.Domain.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IWebHostEnvironment _env;

        public ArquivoService(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> ArmazenarERetornarCaminho(IFormFile arquivo, string pasta)
        {
            var caminho = $"storage/{pasta}";
            var storagePath = Path.Combine(_env.WebRootPath, caminho);

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(arquivo.FileName)}";
            var filePath = Path.Combine(storagePath, fileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await arquivo.CopyToAsync(stream);

            return $"{caminho}/{fileName}";
        }
    }
}