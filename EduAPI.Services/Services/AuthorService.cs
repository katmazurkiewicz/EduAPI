using AutoMapper;
using EduAPI.Data.DAL.Interfaces;
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
        //public async Task<IEnumerable<ReadMaterialDTO>> GetTopMaterialsAsync(int id)
        //{
        //    var materials = await _unitOfWork.Authors.GetTopMaterialsAsync(id);
        //    return _mapper.Map<IEnumerable<ReadMaterialDTO>>(materials);
        //}
        public async Task<IEnumerable<ReadAuthorDTO>> GetMostProductiveAsync()
        {
            var topauthors = await _unitOfWork.Authors.GetMostProductiveAsync();
            return _mapper.Map<IEnumerable<ReadAuthorDTO>>(topauthors);

        }

    }
}
