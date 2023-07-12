using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TCM.Core.Dto.TrainComponentDto;
using TCM.Core.Interfaces;

namespace TCM.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrainComponentController : Controller
    {
        private ITrainComponentService _trainComponentService;

        public TrainComponentController(
            ITrainComponentService trainComponentService)
        {
            _trainComponentService = trainComponentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int? parentId = null, int pageIndex = 0, int pageSize = 10)
        {
            var components = await _trainComponentService.GetAllAsync(parentId, pageIndex, pageSize);
            return Ok(components);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var component = await _trainComponentService.GetById(id);
            return Ok(component);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(TrainComponentCreateRequest model)
        {
            await _trainComponentService.CreateComponentAsync(model);
            return Ok(new { message = "Component created" });
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TrainComponentUpdateRequest request)
        {
            if (id != request.Id)
            {
                return BadRequest();
            }

            await _trainComponentService.UpdateComponentAsync(request);
            return Ok(new { message = "Component updated" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _trainComponentService.DeleteComponentAsync(id);
            return Ok(new { message = "Component deleted" });
        }


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateQantityAsync(int id, [FromBody] JsonPatchDocument<TrainComponentPatchRequest> patchDoc)
        {
            if (patchDoc != null)
            {
                var request = new TrainComponentPatchRequest();

                patchDoc.ApplyTo(request);

                await _trainComponentService.UpdateQantityAsync(id, request.Quantity);
                return Ok(new { message = "Component Qantity updated" });
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPost("{id}/addChild")]
        public async Task<IActionResult> AddChildRelationAsync(int id, [FromBody] TrainComponentRelationRequest request)
        {
            if (id != request.ParentId)
            {
                return BadRequest();
            }

            await _trainComponentService.CreateRelationAsync(request.ParentId, request.ChildId);
            return Ok(new { message = "Component updated" });

        }


        [HttpDelete("{id}/delChild")]
        public async Task<IActionResult> DeleteChildRelationAsync(int id, [FromBody] TrainComponentRelationRequest request)
        {
            if (id != request.ParentId)
            {
                return BadRequest();
            }

            await _trainComponentService.DeleteRelationAsync(request.ParentId, request.ChildId);
            return Ok(new { message = "Component updated" });

        }
    }
}
