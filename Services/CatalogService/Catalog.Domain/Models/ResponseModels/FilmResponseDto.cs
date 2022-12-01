using Catalog.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Models.ResponseModels
{
    public  class FilmResponseDto
    {
        public FilmDto? Film { get; set; }
        public List<PartDto>? List { get; set; }
    }
}
