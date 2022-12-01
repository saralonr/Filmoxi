using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Dtos
{
    public class FilmPartDto
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public int? PartNo { get; set; }
    }
}
