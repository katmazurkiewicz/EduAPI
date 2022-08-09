using EduAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EduAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _service;

        public AuthorController(IAuthorService service)
        {
            _service = service;
        }
        [SwaggerOperation(Summary = "Returns single Author by ID")]
        [HttpGet("{id}", Name = "GetAuthorAsync")]
        public async Task<IActionResult> GetAuthorAsync(int id)
        {
            return Ok(await _service.GetSingleAsync(id));
        }

        [SwaggerOperation(Summary = "Returns all Authors")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }

        [SwaggerOperation(Summary = "Returns all Author materials with avg rating over 5")]
        [HttpGet]
        [Route("{id}/topmaterials")]
        public async Task<IActionResult> GetTopMaterialsAsync(int id)
        {
            return Ok(await _service.GetTopMaterialsAsync(id));
        }
        [SwaggerOperation(Summary ="Gets author(s) with most materials")]
        [HttpGet]
        [Route("mostproductive")]
        public async Task<IActionResult> GetMostProductiveAsync()
        {
            return Ok(await _service.GetMostProductiveAsync());
        }
    }
}
