using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesDemo.Core.Models;

namespace MoviesDemo.Core.Services
{
    public class FakeMoviesService : IMoviesService
    {
        public async Task<IEnumerable<MovieModel>> GetMovies()
        {
            return new MovieModel[]
            {
              new MovieModel()
              {
                  Title="Zootopia",
                  Runtime="2:34",
                  RelaseDate="2016-03-04",
                  Director="Byron Howard, Rich Moore",
                  Cast="Ginnifer Goodwin, Jason Bateman",
                  Genre="Comedy, Action and Adventure",
                  Poster="http://trailers.apple.com/trailers/disney/zootopia/images/poster.jpg",
                  LargePoster="http://trailers.apple.com/trailers/disney/zootopia/images/poster-xlarge.jpg",
                  Description=@"The modern mammal metropolis of Zootopia is a city like no other. Comprised of habitat neighborhoods like ritzy Sahara Square and frigid Tundratown, it’s a melting pot where animals from every environment live together—a place where no matter what you are, from the biggest elephant to the smallest shrew, you can be anything. But when rookie officer Judy Hopps (voice of Ginnifer Goodwin) arrives, she discovers that being the first bunny on a police force of big, tough animals isn’t so easy. Determined to prove herself, she jumps at the opportunity to crack a case, even if it means partnering with a fast-talking, scam-artist fox, Nick Wilde (voice of Jason Bateman), to solve the mystery. Walt Disney Animation Studios’ “Zootopia,” a comedy-adventure directed by Byron Howard (“Tangled,” “Bolt”) and Rich Moore (“Wreck-It Ralph,” “The Simpsons”), opens in theaters on March 4, 2016."

              }
            };
        }
    }
}
