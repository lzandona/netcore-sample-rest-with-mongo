using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloRest.Model;
using HelloRest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HelloRest.Controllers
{
    [Produces("application/json")]
    [Route("api/Movie")]
    public class MovieController : Controller
    {
        private readonly MongoDbService service;

        public MovieController()
        {
            service = new MongoDbService("MovieDatabase", "Movies", "mongodb://localhost");
        }

        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var allMovies = await service.GetAllMovies();
            return Json(allMovies);
        }


        [HttpPost]
        public async Task CreateMovie([FromBody] Movie movie)
        {

            await service.insertMovie(movie);

        }


    }
}