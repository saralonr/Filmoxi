using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Dtos
{
    public class PartDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public List<FilmPartDto>? List { get; set; }
    }
}
