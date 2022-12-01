using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.Dtos
{
    public class FilmDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Year { get; set; }
        public string? Director { get; set; }
        public string? IMBDScore { get; set; }
        public string? Type { get; set; }
        public string? Time { get; set; }
        public string? Language { get; set; }
        public string? Category { get; set; }
        public string? Tags { get; set; }
        public string? Summary { get; set; }
    }
}
