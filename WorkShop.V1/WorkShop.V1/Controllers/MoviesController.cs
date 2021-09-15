using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShop.V1.Models;

namespace WorkShop.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public ActionResult <List<Movie>> Get()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticDb.Movies);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        //http://localhost:47435/api/movies/2
        [HttpGet("{id}")]
        public ActionResult<Movie> Get(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request");
                }

                if (id >= StaticDb.Movies.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note not found");
                }
                return StatusCode(StatusCodes.Status200OK, StaticDb.Movies[id]);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        //api/movies
        [HttpPost]
        public ActionResult Post([FromBody] Movie movie)
        {
            try
            {
                StaticDb.Movies.Add(movie);
                return StatusCode(StatusCodes.Status201Created,"Movie added");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        ///http://localhost:47435/api/movies/genre?Genre=Horor
        [HttpGet("genre")]
        public ActionResult<Movie> Get(string genre)
        {
            try
            {
                if (string.IsNullOrEmpty(genre))
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Try again");
                }
                
                Movie movieByGenre = StaticDb.Movies.FirstOrDefault(x => x.Genre.Contains(genre));
                return StatusCode(StatusCodes.Status200OK, movieByGenre.Title.ToString());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Internet not working");
            }
        }

        
        [HttpDelete("{index}")]
        public IActionResult Delete(int index)
        {
            try
            {
                if (index < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Bad request!");
                }

                if (index >= StaticDb.Movies.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Note does not exist!");
                }

                StaticDb.Movies.RemoveAt(index);
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        



    }
}
