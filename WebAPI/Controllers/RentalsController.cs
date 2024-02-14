using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;
        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllRentals()
        {
            var result = _rentalService.GetAllRentals();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult AddRental([FromBody] Rental rental)
        {
            var result = _rentalService.AddRental(rental);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult DeleteRental([FromBody] Rental rental)
        {
            var result = _rentalService.DeleteRental(rental);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateRental([FromBody] Rental rental)
        {
            var result = _rentalService.UpdateRental(rental);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _rentalService.GetRentalById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("cardeliver")]
        public IActionResult CarDeliver(int id, DateTime dateTime)
        {
            var result = _rentalService.CarDeliver(id, dateTime);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);

        } 


    }



}
