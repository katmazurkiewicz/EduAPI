using AutoMapper;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Services.Interfaces;
using EduAPI.Services.Models.DTOs;

namespace EduAPI.Services
{
    public class TypeService: ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public TypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ReadTypeDTO> GetSingleAsync(int id)
        {
            var type = await _unitOfWork.Types.GetSingleAsync(id);
            //if (type is null)
            //    throw new ResourceNotFoundException($"Type with id {id} not found");
            return _mapper.Map<ReadTypeDTO>(type);
        }
        public async Task<IEnumerable<ReadTypeDTO>> GetAllAsync()
        {
            var types = await _unitOfWork.Types.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadTypeDTO>>(types);
        }
        public async Task<IEnumerable<ReadMaterialDTO>> GetTypeMaterialsAsync(int id)
        {
            var type = await _unitOfWork.Types.GetSingleWithDetailsAsync(id);
            return _mapper.Map<IEnumerable<ReadMaterialDTO>>(type.Materials);
        }
    }
}
