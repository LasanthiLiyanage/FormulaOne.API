using AutoMapper;
using FormulaOne.API.Commands;
using FormulaOne.API.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : BaseController    {
        
        public DriversController(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator) : base(unitOfWork, mapper, mediator)
        {            
        }

        [HttpGet]
        [Route(template: "{driverId:guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var query = new GetDriverQuery(driverId);
            var result = await _mediator.Send(query);

            if(result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new CreateDriverInfoRequest(driver);
            var result =  await _mediator.Send(command);

            return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var command = new UpdateDriverInfoRequest(driver);
            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            // Specifying the query that I have for this endpoint
            var query = new GetAllDriversQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpDelete]
        [Route(template: "{driverId:guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var command = new DeleteDriverInfoRequest(driverId);
            var result = await _mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }
    }
}
