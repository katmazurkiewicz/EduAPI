namespace EduAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaterialController : ControllerBase
    {
        private readonly IMaterialService _service;

        public MaterialController(IMaterialService service)
        {
            _service = service;
        }
        [SwaggerOperation(Summary = "Returns single Material by ID")]
        [HttpGet("{id}", Name = "GetMaterialAsync")]
        
        public async Task<IActionResult> GetMaterialAsync(int id)
        {
            return Ok(await _service.GetSingleAsync(id));
        }

        [SwaggerOperation(Summary = "Returns all Materials")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _service.GetAllAsync());
        }
        [SwaggerOperation(Summary = "Creates new Material")]
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> CreateAsync(WriteMaterialDTO dto)
        {
            var newMaterial = await _service.CreateAsync(dto);
            return CreatedAtRoute(nameof(GetMaterialAsync), new { id = newMaterial.Id }, newMaterial);
        }
        [SwaggerOperation(Summary = "Updates Material by ID")]
        [HttpPatch("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateAsync(int id, JsonPatchDocument materialPatch)
        {
            await _service.UpdateAsync(id, materialPatch);
            return NoContent();
        }
        [SwaggerOperation(Summary = "Updates Material by ID")]
        [HttpPut("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> PutAsync(int id, WriteMaterialDTO dto)
        {
            await _service.PutAsync(id, dto);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Deletes Material by ID")]
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
