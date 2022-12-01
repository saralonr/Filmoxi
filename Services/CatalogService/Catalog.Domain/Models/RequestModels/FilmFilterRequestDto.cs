using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Models.RequestModels
{
    public class FilmFilterRequestDto
    {
        public string? SearchKey { get; set; }
        public int PageNumber { get; set; } = 1;
        public int TotalSize { get; set; }
        public int PageSize { get; set; }
    }
}
