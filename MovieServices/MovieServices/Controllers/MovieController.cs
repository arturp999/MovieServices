using MovieServices.Filters;
using MovieServices.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using WebsiteAccess; //acess dll DB context

namespace MovieServices.Controllers
{
    public class MovieController : ApiController
    {
        [Route("api/listMovies")]
        public IEnumerable<Movy> GetMovies()
        {
            using (PressWatchEntities entities = new PressWatchEntities()) //connection to the sql model thats connected to the db
            {
                
                return entities.Movies.ToList();
            }
        }
        [Route("api/getMovie/{id}")]
        public Movy GetMovie(int id)
        {
            using (PressWatchEntities entities = new PressWatchEntities()) //connection to the sql model thats connected to the db
            {
                return entities.Movies.FirstOrDefault(e => e.id == id);
            }
        }

        [Route("api/newMovie")]
        [ValidateModelAttribute]
        public IHttpActionResult NewMovie([FromBody]Movie oMovie)
        {
            Movy newM = new Movy()
            {
                Name = oMovie.Name,
                Rating = oMovie.Rating,
                Release_Year = oMovie.Release_Year,
                Movie_Img = oMovie.Movie_Img,
                Description = oMovie.Description,
                Movie_Trailer = oMovie.Movie_Trailer
            };

            using (PressWatchEntities entities = new PressWatchEntities()) //connection to the sql model thats connected to the db
            {
                entities.Movies.Add(newM);
                entities.SaveChanges();
                return Ok();
            }
        }

        [HttpPatch]
        [Route("api/updateMovie/{id}")]
        [ValidateModelAttribute]
        public IHttpActionResult UpdateMovie([FromBody] Movie oMovie, int id)
        {//need to 
            using (PressWatchEntities entities = new PressWatchEntities()) //connection to the sql model thats connected to the db
            {
                var result = entities.Movies.FirstOrDefault(e => e.id == id);

                if (result == null)
                {
                    return StatusCode(HttpStatusCode.NotFound);
                } else
                {
                    if (oMovie.Name != null)
                    {
                        result.Name = oMovie.Name;
                    }
                    if (oMovie.Rating != 0)
                    {
                        result.Rating = oMovie.Rating;
                    }
                    if (oMovie.Release_Year != 0)
                    {
                        result.Release_Year = oMovie.Release_Year;
                    }
                    if (oMovie.Movie_Img != null)
                    {
                        result.Movie_Img = oMovie.Movie_Img;
                    }
                    if (oMovie.Description != null)
                    {
                        result.Description = oMovie.Description;
                    }
                    if (oMovie.Movie_Trailer != null)
                    {
                        result.Movie_Trailer = oMovie.Movie_Trailer;
                    }

                    entities.SaveChanges();
                    return StatusCode(HttpStatusCode.OK);
                }
            }
        }

        [Route("api/deleteMovie/{id}")]
        [ValidateModelAttribute]
        public IHttpActionResult DeleteMovie(int id)
        {
            using (PressWatchEntities entities = new PressWatchEntities()) //connection to the sql model thats connected to the db
            {
                var result = entities.Movies.FirstOrDefault(e => e.id == id);
                if (result == null)
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }
                else
                {
                    entities.Movies.Remove(result);
                    entities.SaveChanges();
                    return StatusCode(HttpStatusCode.OK);
                }
            }
        }

















    }
}
