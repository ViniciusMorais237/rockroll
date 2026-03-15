using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using backend.Domain.Entities;
using backend.Domain.Entities.DTOs.Queries;

namespace backend.Domain.Automapper;

public class Mapper : Profile
{
    public Mapper()
    {
        CreateMap<Musica, MusicaResponse>();
    }
}
