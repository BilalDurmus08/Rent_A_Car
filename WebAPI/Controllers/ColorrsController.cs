using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorrsController : ControllerBase
    {
        IColorrService _colorrService;
        public ColorrsController(IColorrService colorrService)
        {
            _colorrService = colorrService;
        }

        [HttpGet("getall")]
        public IActionResult GetAllColorrs()
        {
            var result = _colorrService.GetAllColors();
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult AddColorr([FromBody] Colorr colorr)
        {
            var result = _colorrService.AddColor(colorr);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult DeleteColorr([FromBody] Colorr colorr)
        {
            var result = _colorrService.DeleteColor(colorr);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult UpdateColorr([FromBody] Colorr colorr)
        {
            var result = _colorrService.UpdateColor(colorr);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _colorrService.GetColorById(id);
            if (result.Success == true)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }


}