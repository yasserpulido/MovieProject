using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IMovie : IDisposable
    {
        Task<bool> CreateMovie(Movie movie);
        Task<List<Movie>> GetAllMovies();
        Task<Movie> GetMovieBy(string title, int released);
        Task<bool> UpdateMovie(Movie movie);
        Task<bool> DeleteMovie(string title, int released);
    }
}
