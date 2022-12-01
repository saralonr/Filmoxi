using Microsoft.AspNetCore.Mvc;

namespace Filmoxi.UI.Controllers
{
    public class MovieController : Controller
    {
        [Route("Film/{id}--{filmName}")]
        public IActionResult Detail()
        {
            return View();
        }
        [Route("FilmTurleri")]
        public IActionResult MovieTypes()
        {
            return View();
        }
        [Route("FilmTuru/{filmType}")]
        public IActionResult MovieTypeDetail()
        {
            return View();
        }
        [Route("FilmYillari")]
        public IActionResult MovieYears()
        {
            return View();
        }
        [Route("FilmYili/{filmYear}")]
        public IActionResult MovieYearDetail()
        {
            return View();
        }
    }
}
