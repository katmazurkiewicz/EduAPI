using AutoMapper;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Services.Interfaces;
using EduAPI.Services.Models.DTOs;
using EduAPI.Services.Models.Exceptions;
using Serilog;

namespace EduAPI.Services
{
    public class TypeService: ITypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private static readonly ILogger _logger = Log.ForContext<TypeService>();

        public TypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ReadTypeDTO> GetSingleAsync(int id)
        {
            var type = await _unitOfWork.Types.GetSingleAsync(id);
            if (type is null)
                throw new ResourceNotFoundException($"Type with id {id} not found");
            _logger.Information($"User displayed Type with id {id}");
            return _mapper.Map<ReadTypeDTO>(type);
        }
        public async Task<IEnumerable<ReadTypeDTO>> GetAllAsync()
        {
            var types = await _unitOfWork.Types.GetAllAsync();
            _logger.Information("User displayed all Types");
            return _mapper.Map<IEnumerable<ReadTypeDTO>>(types);
        }
        public async Task<IEnumerable<ReadMaterialDTO>> GetTypeMaterialsAsync(int id)
        {
            var type = await _unitOfWork.Types.GetSingleWithDetailsAsync(id);
            _logger.Information($"User displayed materials for type {id}");
            return _mapper.Map<IEnumerable<ReadMaterialDTO>>(type.Materials);
        }
    }
}
