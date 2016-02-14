using MoviesDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.Core.Services
{
    public interface IMoviesService
    {
        Task<IEnumerable<MovieModel>> GetMovies();
    }
}
