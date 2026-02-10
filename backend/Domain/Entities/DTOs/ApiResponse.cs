using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Domain.Entities.DTOs
{
    public class ApiResponse<T>
    {
        public string Mensagem { get; set; } = "200/Ok";
        public int StatusCode { get; set; }
        public T? Resultado { get; set; }
    }
}