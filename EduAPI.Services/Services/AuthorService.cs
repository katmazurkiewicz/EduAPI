using AutoMapper;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Data.Entities;
using EduAPI.Services.Interfaces;
using EduAPI.Services.Models.DTOs;

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
        public async Task<ReadAuthorDTO> GetSingleAsync(int id)
        {
            var author = await _unitOfWork.Authors.GetSingleAsync(id);
            //if (author is null)
            //    throw new ResourceNotFoundException($"Author with id {id} not found");
            return _mapper.Map<ReadAuthorDTO>(author);
        }
        public async Task<IEnumerable<ReadAuthorDTO>> GetAllAsync()
        {
            var authors = await _unitOfWork.Authors.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadAuthorDTO>>(authors);
        }

        public async Task<IEnumerable<ReadMaterialDTO>> GetTopMaterialsAsync(int id)
        {
            var author = await _unitOfWork.Authors.GetSingleWithDetailsAsync(id);
            //if (author is null) throw exception
            var topMaterials = new List<Material>();
            foreach (var material in author.Materials)
            {
                var reviewValues = new List<int>();
                if (material.Reviews != null && material.Reviews.Count() > 0)
                {
                    foreach (var review in material.Reviews)
                    {
                        reviewValues.Add(review.Points);
                    }
                    if (reviewValues.Average() > 5) topMaterials.Add(material);
                }
            }
            //if topmaterials is empty throw exception
            return _mapper.Map<IEnumerable<ReadMaterialDTO>>(topMaterials);
        }
        public async Task<IEnumerable<ReadAuthorDTO>> GetMostProductiveAsync()
        {
            var authorList = await _unitOfWork.Authors.GetAllWithDetailsAsync();
            authorList = authorList.OrderByDescending(a => a.CreatedTotal).ToList();
            var topAuthor = authorList.FirstOrDefault();
            //exception here
            var topList = authorList.Where(a => a.CreatedTotal == topAuthor.CreatedTotal);
            return _mapper.Map <IEnumerable<ReadAuthorDTO>>(topList);
        }

    }
}
