using AutoMapper;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Data.Entities;
using EduAPI.Services.Interfaces;
using EduAPI.Services.Models.DTOs;
using EduAPI.Services.Models.Exceptions;
using Serilog;

namespace EduAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        private static readonly ILogger _logger = Log.ForContext<AuthorService>();
        public async Task<ReadAuthorDTO> GetSingleAsync(int id)
        {
            var author = await _unitOfWork.Authors.GetSingleAsync(id);
            if (author is null)
               throw new ResourceNotFoundException($"Author with id {id} not found");
            _logger.Information($"User displayed Author with id {id}");
            return _mapper.Map<ReadAuthorDTO>(author);
        }
        public async Task<IEnumerable<ReadAuthorDTO>> GetAllAsync()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            _logger.Information($"User displayed all Authors");
            return _mapper.Map<IEnumerable<ReadAuthorDTO>>(authors);
        }

        public async Task<IEnumerable<ReadMaterialDTO>> GetTopMaterialsAsync(int id)
        {
            var author = await _unitOfWork.Authors.GetSingleWithDetailsAsync(id);
            if (author is null)
                throw new ResourceNotFoundException($"Author with id {id} not found");
            var topMaterials = new List<Material>();
            foreach (var material in author.Materials)
            {
                var reviewValues = new List<int>();
                if (material.Reviews != null && material.Reviews.Any())
                {
                    foreach (var review in material.Reviews)
                    {
                        reviewValues.Add(review.Points);
                    }
                    if (reviewValues.Average() > 5) topMaterials.Add(material);
                }
            }
            if (topMaterials is null || topMaterials.Count == 0)
               throw new ResourceNotFoundException($"No materials with avg rating over 5 for Author with id {id}");
            _logger.Information($"User displayed top rated materials for Author with id {id}");
            return _mapper.Map<IEnumerable<ReadMaterialDTO>>(topMaterials);
        }
        public async Task<IEnumerable<ReadAuthorDTO>> GetMostProductiveAsync()
        {
            var authorList = await _unitOfWork.Authors.GetAllWithDetailsAsync();
            authorList = authorList.OrderByDescending(a => a.CreatedTotal).ToList();
            var topAuthor = authorList.FirstOrDefault();
            if (topAuthor is null)
                throw new ResourceNotFoundException($"No Authors in database");
            var topList = authorList.Where(a => a.CreatedTotal == topAuthor.CreatedTotal);
            _logger.Information("User displayed most productive Authors");
            return _mapper.Map <IEnumerable<ReadAuthorDTO>>(topList);
        }

    }
}
