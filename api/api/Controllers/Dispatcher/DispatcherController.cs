using api.Controllers.Dispatcher.Dtos;
using api.Controllers.Dispatcher.Services;
using api.Database.Entities.Dispatcher;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.Dispatcher
{
    [ApiController]
    [Route("api/[controller]")]
    public class DispatcherController : Controller
    {
        private readonly DispatcherService dispatcherService;
        private readonly IMapper mapper;

        public DispatcherController(DispatcherService dispatcherService, IMapper mapper)
        {
            this.dispatcherService = dispatcherService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DispatcherResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAll()
        {
            List<DispatcherEntity> dispatchers = await dispatcherService.ListAll();
            List<DispatcherResponseDto> response = mapper.Map<List<DispatcherResponseDto>>(dispatchers);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(DispatcherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DispatcherResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            DispatcherEntity? result = await dispatcherService.getById(id);
            if (result == null) { return NotFound(); }
            DispatcherResponseDto response = mapper.Map<DispatcherResponseDto>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(DispatcherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DispatcherResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            Boolean? result = await dispatcherService.delete(id);
            if (result == false) { return NotFound(); }
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(DispatcherResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(DispatcherResponseDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateDispatcherDto dispatcher)
        {
            DispatcherEntity? result = await dispatcherService.create(dispatcher);
            if (result == null) return BadRequest();
            DispatcherResponseDto response = mapper.Map<DispatcherResponseDto>(result);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DispatcherResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(DispatcherResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, CreateDispatcherDto dispatcher)
        {
            DispatcherEntity? result = await dispatcherService.update(id, dispatcher);
            if (result == null) return NotFound();
            DispatcherResponseDto response = mapper.Map<DispatcherResponseDto>(result);
            return Ok(response);
        }
    }
}
