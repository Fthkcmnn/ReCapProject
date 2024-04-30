using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CarImagesController : ControllerBase
{
    private ICarImageService _carImageService;

    public CarImagesController(ICarImageService carImageService)
    {
        _carImageService = carImageService;
    }

    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _carImageService.GetAll();
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }
    #region IfileBasic
    //[HttpPost("add")]
    //public IActionResult Add(Ifile file)
    //{
    //    var result = _carImageService.Add(new CarImage());
    //    if (result.IsSuccess)
    //    {
    //        return Ok(result);
    //    }
    //    return BadRequest(result);
    //}
    #endregion
    //TODO: Freamwork'e göre yeniden yazılacak
    #region Ifile
    //[HttpPost("add")]
    //public async Task<IActionResult> Add([FromForm] IFormFile file)
    //{
    //    var result = _carImageService.Add(file);
    //    if (result.)
    //    {

    //    }
    //}
    #endregion
}

