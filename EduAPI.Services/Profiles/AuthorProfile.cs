using AutoMapper;
using EduAPI.Data.Entities;
using EduAPI.Services.Models.DTOs;

namespace EduAPI.Services.Profiles
{
    public class AuthorProfile:Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author,ReadAuthorDTO>();
        }
        
    }
}
