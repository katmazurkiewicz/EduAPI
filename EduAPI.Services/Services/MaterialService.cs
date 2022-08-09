using AutoMapper;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Data.Entities;
using EduAPI.Services.Models.DTOs;
using EduAPI.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using EduAPI.Services.Models.Exceptions;

namespace EduAPI.Services
{
    public class MaterialService :IMaterialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public MaterialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ReadMaterialDTO> GetSingleAsync(int id)
        {
            var material = await _unitOfWork.Materials.GetSingleAsync(id);
            if (material is null)
                throw new ResourceNotFoundException($"Material with id {id} not found");
            return _mapper.Map<ReadMaterialDTO>(material);
        }
        public async Task<IEnumerable<ReadMaterialDTO>> GetAllAsync()
        {
            var materials = await _unitOfWork.Materials.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadMaterialDTO>>(materials);
        }
        public async Task<ReadMaterialDTO> CreateAsync(WriteMaterialDTO dto)
        {
            Material newMaterial = _mapper.Map<Material>(dto);
            _unitOfWork.Materials.Add(newMaterial);
            await _unitOfWork.CompleteUnitAsync();
            return _mapper.Map<ReadMaterialDTO>(newMaterial);
        }

        public async Task UpdateAsync(int id, JsonPatchDocument materialPatch)
        {
            var materialToUpdate = await _unitOfWork.Materials.GetSingleAsync(id);
            if (materialToUpdate is null)
                throw new ResourceNotFoundException($"Material with id {id} not found");

            materialPatch.ApplyTo(materialToUpdate);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var materialToDelete = await _unitOfWork.Materials.GetSingleAsync(id);
            if (materialToDelete is null)
                throw new ResourceNotFoundException($"Material with id {id} not found");

            _unitOfWork.Materials.Delete(materialToDelete);
            await _unitOfWork.CompleteUnitAsync();
        }
    }
}
