using Api.DTOs;
using Api.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterReadDto>();
            CreateMap<CharacterCreateDto, Character>();
            CreateMap<CharacterUpdateDto, Character>();
            CreateMap<Character, CharacterUpdateDto>();
        }
    }
}
