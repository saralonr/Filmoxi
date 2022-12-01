using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Models
{
    public class Part
    {
        public int Id { get; set; }
        public string? PartName { get; set; }

        public virtual ICollection<FilmPart>? FilmParts { get; set; }
    }
}
