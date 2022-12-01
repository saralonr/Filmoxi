using Catalog.Domain.Dtos;
using Catalog.Domain.Models.RequestModels;
using Catalog.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services.Interfaces
{
    public interface IFilmService
    {
        Task<BaseResponseDto<List<FilmResponseDto>>> GetListAsync(FilmFilterRequestDto model); 
        Task<BaseResponseDto<FilmResponseDto>> GetByIdAsync(int id);
        Task<BaseResponseDto<List<FilmTypeResponseDto>>> GetFilmTypesAsync();
        Task<BaseResponseDto<List<FilmYearResponseDto>>> GetFilmYearsAsync();
    }
}
