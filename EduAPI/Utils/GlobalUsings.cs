﻿global using AuthData;
global using EduAPI.Services.Models.DTOs.Users;
global using Microsoft.AspNetCore.Authorization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.IdentityModel.Tokens;
global using System.IdentityModel.Tokens.Jwt;
global using System.Security.Claims;
global using System.Security.Cryptography;
global using System.Text;
global using EduAPI.Services.Interfaces;
global using Swashbuckle.AspNetCore.Annotations;
global using EduAPI.Services.Models.DTOs;
global using Microsoft.AspNetCore.JsonPatch;
global using EduAPI.Data.Context;
global using EduAPI.Data.DAL;
global using EduAPI.Data.DAL.Interfaces;
global using EduAPI.Middlewares;
global using EduAPI.Services;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.OpenApi.Models;
global using Serilog;
global using Swashbuckle.AspNetCore.Filters;
global using EduAPI.Services.Models.Exceptions;
global using System.Net;
