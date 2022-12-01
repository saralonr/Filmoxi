using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Models
{
    public class FilmPart
    {
        public int Id { get; set; }
        public int? FilmId { get; set; }
        public virtual Film? Film { get; set; }
        public int? PartId { get; set; }
        public virtual Part? Part { get; set; }
        public int? PartNo { get; set; }
        public string? Url { get; set; }
    }
}
