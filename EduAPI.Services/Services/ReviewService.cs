using AutoMapper;
using EduAPI.Data.DAL.Interfaces;
using EduAPI.Data.Entities;
using EduAPI.Services.Interfaces;
using EduAPI.Services.Models.DTOs;
using EduAPI.Services.Models.Exceptions;
using Microsoft.AspNetCore.JsonPatch;

namespace EduAPI.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ReadReviewDTO> GetSingleAsync(int id)
        {
            var review = await _unitOfWork.Reviews.GetSingleAsync(id);
            if (review is null)
                throw new ResourceNotFoundException($"Review with id {id} not found");
            return _mapper.Map<ReadReviewDTO>(review);
        }
        public async Task<IEnumerable<ReadReviewDTO>> GetAllAsync()
        {
            var reviews = await _unitOfWork.Reviews.GetAllAsync();
            return _mapper.Map<IEnumerable<ReadReviewDTO>>(reviews);
        }
        public async Task<ReadReviewDTO> CreateAsync(WriteReviewDTO dto)
        {
            Review newReview = _mapper.Map<Review>(dto);
            _unitOfWork.Reviews.Add(newReview);
            await _unitOfWork.CompleteUnitAsync();
            return _mapper.Map<ReadReviewDTO>(newReview);
        }

        public async Task UpdateAsync(int id, WriteReviewDTO dto)
        {
            var reviewToUpdate = await _unitOfWork.Reviews.GetSingleAsync(id);
            if (reviewToUpdate is null)
                throw new ResourceNotFoundException($"Review with id {id} not found");
            var newMaterial = await _unitOfWork.Materials.GetSingleAsync(dto.MaterialId);
            if (newMaterial is null)
                throw new ResourceNotFoundException($"Material with id {id} not found");
            var update = _mapper.Map<Review>(dto);
            reviewToUpdate.MaterialId = update.MaterialId;
            reviewToUpdate.Contents = update.Contents;
            reviewToUpdate.Points = update.Points;
            _unitOfWork.Reviews.Update(reviewToUpdate);
            await _unitOfWork.CompleteUnitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var reviewToDelete = await _unitOfWork.Reviews.GetSingleAsync(id);
            if (reviewToDelete is null)
                throw new ResourceNotFoundException($"Review with id {id} not found");

            _unitOfWork.Reviews.Delete(reviewToDelete);
            await _unitOfWork.CompleteUnitAsync();
        }
    }
}
