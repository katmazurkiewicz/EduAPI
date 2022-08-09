using EduAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EduAPI.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        [Authorize]
        public class TypeController : ControllerBase
        {
            private readonly ITypeService _service;

            public TypeController(ITypeService service)
            {
                _service = service;
            }
            [SwaggerOperation(Summary = "Returns single Type by ID")]
            [HttpGet("{id}", Name = "GetTypeAsync")]
            public async Task<IActionResult> GetTypeAsync(int id)
            {
                return Ok(await _service.GetSingleAsync(id));
            }

            [SwaggerOperation(Summary = "Returns all Types")]
            [HttpGet]
            public async Task<IActionResult> GetAllAsync()
            {
                return Ok(await _service.GetAllAsync());
            }

            [SwaggerOperation(Summary = "Returns all Materials for given Type")]
            [HttpGet("{id}/materials", Name = "GetTypeMaterialsAsync")]
            public async Task<IActionResult> GetTypeMaterialsAsync(int id)
            {
                return Ok(await _service.GetTypeMaterialsAsync(id));
            }
    }
}
