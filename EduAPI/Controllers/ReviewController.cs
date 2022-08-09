using EduAPI.Services.Interfaces;
using EduAPI.Services.Models.DTOs;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EduAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _service;

        public ReviewController(IReviewService service)
        {
            _service = service;
        }
        [SwaggerOperation(Summary = "Returns single Review by ID")]
        [HttpGet("{id}", Name = "GetReviewAsync")]

        public async Task<IActionResult> GetReviewAsync(int id)
        {
            return Ok(await _service.GetSingleAsync(id));
        }

        [SwaggerOperation(Summary = "Returns all Reviews")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }
        [SwaggerOperation(Summary = "Creates new Review")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync(WriteReviewDTO dto)
        {
            var newReview = await _service.CreateAsync(dto);
            return CreatedAtRoute(nameof(GetReviewAsync), new { id = newReview.Id }, newReview);
        }
        [SwaggerOperation(Summary = "Updates Review by ID")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, WriteReviewDTO dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Deletes Review by ID")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
