using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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
        public async Task<Movy> newMovie(Movy oMovie)
        {
            using (PressWatchEntities entities = new PressWatchEntities()) //connection to the sql model thats connected to the db
            {

                entities.Movies.Add(oMovie);

                entities.SaveChanges(); //
                return oMovie;
            }


        }





    }
}
