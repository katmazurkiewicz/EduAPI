using AutoMapper;
using EduAPI.Data.Entities;
using EduAPI.Services.Models.DTOs;

namespace EduAPI.Services.Profiles
{
    public class TypeProfile:Profile
    {
        public TypeProfile()
        {
            CreateMap<MatType, ReadTypeDTO>();
        }

    }
}
