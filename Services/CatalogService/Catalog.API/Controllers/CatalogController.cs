using Catalog.Domain.Dtos;
using Catalog.Domain.Models.RequestModels;
using Catalog.Domain.Models.ResponseModels;
using Catalog.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IFilmService _filmService;
        public CatalogController(IFilmService filmService)
        {
            _filmService = filmService;
        }
        [HttpGet("Detail/{id}")]
        public async Task<ActionResult<string>> Get([FromRoute] int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            BaseResponseDto<FilmResponseDto> movie = await _filmService.GetByIdAsync(id);

            if (!movie.HasError || movie.Data != null)
            {
                return Ok(movie.Data);
            }
            else if (!movie.HasError || movie.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(movie.Errors);
            }
        }
        [HttpGet("List")]
        public async Task<ActionResult<string>> GetList([FromQuery] FilmFilterRequestDto model)
        {
            BaseResponseDto<List<FilmResponseDto>> movie = await _filmService.GetListAsync(model);

            if (!movie.HasError || movie.Data != null)
            {
                return Ok(movie.Data);
            }
            else if (!movie.HasError || movie.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(movie.Errors);
            }
        }

        [HttpGet("TypeList")]
        public async Task<ActionResult<string>> GetTypeList()
        {
            BaseResponseDto<List<FilmTypeResponseDto>> movie = await _filmService.GetFilmTypesAsync();

            if (!movie.HasError || movie.Data != null)
            {
                return Ok(movie.Data);
            }
            else if (!movie.HasError || movie.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(movie.Errors);
            }
        }
        [HttpGet("YearList")]
        public async Task<ActionResult<string>> GetYearList()
        {
            BaseResponseDto<List<FilmYearResponseDto>> movie = await _filmService.GetFilmYearsAsync();

            if (!movie.HasError || movie.Data != null)
            {
                return Ok(movie.Data);
            }
            else if (!movie.HasError || movie.Data == null)
            {
                return NotFound();
            }
            else
            {
                return BadRequest(movie.Errors);
            }
        }
    }
}
