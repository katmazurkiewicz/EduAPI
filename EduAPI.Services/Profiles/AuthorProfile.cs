using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
