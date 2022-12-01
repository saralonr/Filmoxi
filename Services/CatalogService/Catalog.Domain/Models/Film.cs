using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string? FilmName { get; set; }
        public string? FilmYear { get; set; }
        public string? FilmDirector { get; set; }
        public string? FilmIMBDScore { get; set; }
        public string? FilmType { get; set; }
        public string? FilmTime { get; set; }
        public string? FilmLanguage { get; set; }
        public string? FilmCategory { get; set; }
        public string? FilmTags { get; set; }
        public string? FilmSummary { get; set; }

        public virtual ICollection<FilmPart>? FilmParts { get; set; }
    }
}
