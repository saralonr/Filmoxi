using Catalog.Domain.Dtos;
using Catalog.Domain.Interfaces;
using Catalog.Domain.Models;
using Catalog.Domain.Models.RequestModels;
using Catalog.Domain.Models.ResponseModels;
using Catalog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services.Implementations
{
    public class FilmService : IFilmService
    {
        private readonly ICatalogRepository<Film> _filmRepository;

        public FilmService(ICatalogRepository<Film> filmRepository)
        {
            _filmRepository = filmRepository;
        }

        public async Task<BaseResponseDto<List<FilmResponseDto>>> GetListAsync(FilmFilterRequestDto model)
        {
            BaseResponseDto<List<FilmResponseDto>> getMovieResponse = new BaseResponseDto<List<FilmResponseDto>>();

            try
            {
                IEnumerable<Film> films = new List<Film>();

                if (!string.IsNullOrWhiteSpace(model.SearchKey))
                {
                    films = await _filmRepository.GetQueryListAsync(
                        predicate: x => x.FilmName.Contains(model.SearchKey) || x.FilmType.Contains(model.SearchKey) || x.FilmTags.Contains(model.SearchKey),
                        orderBy: x => x.FilmName,
                        isDesc: false,
                        skip: ((model.PageNumber - 1) * model.PageSize),
                        take: model.PageSize);
                }
                else
                {
                    films = await _filmRepository.GetQueryListAsync(
                        predicate: null,
                        orderBy: x => x.FilmName,
                        isDesc: false,
                        skip: ((model.PageNumber - 1) * model.PageSize),
                        take: model.PageSize);
                }

                if (films.Any())
                {
                    getMovieResponse.Data = films.Select(x => new FilmResponseDto()
                    {
                        Film = new FilmDto()
                        {
                            Id = x.Id,
                            Category = x.FilmCategory,
                            Director = x.FilmDirector,
                            IMBDScore = x.FilmIMBDScore,
                            Language = x.FilmLanguage,
                            Name = x.FilmName,
                            Summary = x.FilmSummary,
                            Tags = x.FilmTags,
                            Time = x.FilmTime,
                            Type = x.FilmType,
                            Year = x.FilmYear
                        },
                        List = new List<PartDto>()
                    }).ToList();

                    getMovieResponse.Data.ForEach(x =>
                    {
                        var film = films.FirstOrDefault(y => y.Id == x.Film.Id);
                        var filmParts = film.FilmParts;

                        if (filmParts != null)
                        {
                            var partGroups = filmParts.GroupBy(p => p.Part).Select(p => new PartDto()
                            {
                                Name = p.Key?.PartName,
                                Id = p.Key?.Id,
                                List = new List<FilmPartDto>()
                            }).ToList();

                            partGroups.ForEach(f =>
                            {
                                var partLinks = filmParts.Where(z => z.PartId == f.Id).ToList();
                                partLinks.ForEach(j =>
                                {
                                    f.List.Add(new FilmPartDto()
                                    {
                                        Id = j.Id,
                                        PartNo = j.PartNo,
                                        Url = j.Url
                                    });
                                });
                            });

                            x.List = partGroups;
                        }
                    });
                }
                else
                {
                    getMovieResponse.Errors.Add("Movie not found.");
                }
            }
            catch (Exception ex)
            {
                getMovieResponse.Errors.Add(ex.Message);
            }

            return getMovieResponse;
        }
        public async Task<BaseResponseDto<FilmResponseDto>> GetByIdAsync(int id)
        {
            BaseResponseDto<FilmResponseDto> getMovieResponse = new BaseResponseDto<FilmResponseDto>();

            try
            {
                var film = await _filmRepository.GetAsync(id);

                if (film != null)
                {
                    getMovieResponse.Data = new FilmResponseDto()
                    {
                        Film = new FilmDto()
                        {
                            Id = film.Id,
                            Category = film.FilmCategory,
                            Director = film.FilmDirector,
                            IMBDScore = film.FilmIMBDScore,
                            Language = film.FilmLanguage,
                            Name = film.FilmName,
                            Summary = film.FilmSummary,
                            Tags = film.FilmTags,
                            Time = film.FilmTime,
                            Type = film.FilmType,
                            Year = film.FilmYear
                        },
                        List = new List<PartDto>()
                    };


                    var filmParts = film.FilmParts;
                    if (filmParts != null)
                    {
                        var partGroups = filmParts.GroupBy(p => p.Part).Select(p => new PartDto()
                        {
                            Name = p.Key?.PartName,
                            Id = p.Key?.Id,
                            List = new List<FilmPartDto>()
                        }).ToList();

                        partGroups.ForEach(f =>
                        {
                            var partLinks = filmParts.Where(z => z.PartId == f.Id).ToList();
                            partLinks.ForEach(j =>
                            {
                                f.List.Add(new FilmPartDto()
                                {
                                    Id = j.Id,
                                    PartNo = j.PartNo,
                                    Url = j.Url
                                });
                            });
                        });

                        getMovieResponse.Data.List = partGroups;
                    }
                }
                else
                {
                    getMovieResponse.Errors.Add("Movie not found.");
                }
            }
            catch (Exception ex)
            {
                getMovieResponse.Errors.Add(ex.Message);
            }

            return getMovieResponse;
        }

        public async Task<BaseResponseDto<List<FilmTypeResponseDto>>> GetFilmTypesAsync()
        {
            BaseResponseDto<List<FilmTypeResponseDto>> getMovieTypeResponse = new BaseResponseDto<List<FilmTypeResponseDto>>();

            try
            {
                var films = await _filmRepository.GetQueryListAsync(null, x => x.FilmType);

                if (films.Any())
                {
                    getMovieTypeResponse.Data = films.GroupBy(x=>x).Select(x => new FilmTypeResponseDto()
                    {
                        FilmType = x.Key
                    }).OrderBy(x => x.FilmType).ToList();

                }
                else
                {
                    getMovieTypeResponse.Errors.Add("Category not found.");
                }
            }
            catch (Exception ex)
            {
                getMovieTypeResponse.Errors.Add(ex.Message);
            }

            return getMovieTypeResponse;
        }
        public async Task<BaseResponseDto<List<FilmYearResponseDto>>> GetFilmYearsAsync()
        {
            BaseResponseDto<List<FilmYearResponseDto>> getMovieYearResponse = new BaseResponseDto<List<FilmYearResponseDto>>();

            try
            {
                var films = await _filmRepository.GetQueryListAsync(null, x => x.FilmYear);

                if (films.Any())
                {
                    getMovieYearResponse.Data = films.GroupBy(x => x).Select(x => new FilmYearResponseDto()
                    {
                        FilmYear = x.Key
                    }).OrderByDescending(x => x.FilmYear).ToList();

                }
                else
                {
                    getMovieYearResponse.Errors.Add("List not found.");
                }
            }
            catch (Exception ex)
            {
                getMovieYearResponse.Errors.Add(ex.Message);
            }

            return getMovieYearResponse;
        }
    }
}
