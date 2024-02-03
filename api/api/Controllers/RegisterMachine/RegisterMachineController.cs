using api.Controllers.RegisterMachine.Dtos;
using api.Controllers.RegisterMachine.Services;
using api.Database.Entities.RegisterMachine;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers.RegisterMachine
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterMachineController : Controller
    {
        private readonly RegisterMachineService registerMachineService;
        private readonly IMapper mapper;

        public RegisterMachineController(RegisterMachineService registerMachineService, IMapper mapper)
        {
            this.registerMachineService = registerMachineService;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<RegisterMachineResponseDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ListAll()
        {
            List<RegisterMachineEntity> registerMachines = await registerMachineService.ListAll();
            List<RegisterMachineResponseDto> response = mapper.Map<List<RegisterMachineResponseDto>>(registerMachines);
            return Ok(response);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RegisterMachineResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RegisterMachineResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            RegisterMachineEntity? result = await registerMachineService.getById(id);
            if (result == null) { return NotFound(); }
            RegisterMachineResponseDto response = mapper.Map<RegisterMachineResponseDto>(result);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(RegisterMachineResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RegisterMachineResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            Boolean? result = await registerMachineService.delete(id);
            if (result == false) { return NotFound(); }
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(typeof(RegisterMachineResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(RegisterMachineResponseDto), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateRegisterMachineDto registerMachine)
        {
            RegisterMachineEntity? result = await registerMachineService.create(registerMachine);
            if (result == null) return BadRequest();
            RegisterMachineResponseDto response = mapper.Map<RegisterMachineResponseDto>(result);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(RegisterMachineResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RegisterMachineResponseDto), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, CreateRegisterMachineDto registerMachine)
        {
            RegisterMachineEntity? result = await registerMachineService.update(id, registerMachine);
            if (result == null) return NotFound();
            RegisterMachineResponseDto response = mapper.Map<RegisterMachineResponseDto>(result);
            return Ok(response);
        }
    }
}
