using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class MovieService
    {
        private readonly IMovie movie;
        public MovieService(IMovie movie)
        {
            this.movie = movie;
        }

        public async Task<bool> CreateMovie(Movie movie)
        {
            try
            {
                var result = await this.movie.CreateMovie(movie);
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<Movie>> GetAllMovies()
        {
            try
            {
                var result = await this.movie.GetAllMovies();
                return result;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<Movie> GetMovieBy(string title, int released)
        {
            try
            {
                var result = await this.movie.GetMovieBy(title, released);
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            try
            {
                var result = await this.movie.UpdateMovie(movie);
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<bool> DeleteMovie(string title, int released)
        {
            try
            {
                var result = await this.movie.DeleteMovie(title, released);
                return result;
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
