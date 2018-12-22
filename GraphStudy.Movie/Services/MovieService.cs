using GraphStudy.Movies.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphStudy.Movies.Services
{
    public class MovieService : IMovieService
    {
        //因为我们需要创建子列表，所以一要用到IList
        private readonly IList<Movie> _movie;
        private readonly IMovieEventService _movieEventService;

        public MovieService(IMovieEventService movieEventService)
        {
            _movieEventService = movieEventService;

            _movie=new List<Movie>
            {
                #region 电影列表
    
                new Movie
                {
                    Id = 1,
                    Name = "肖申克的救赎The Shawshank Redemption",
                    Company = "美国",
                    MovieRating = MovieRating.G,
                    ActorId = 1,
                    ReleaseDate = new DateTime(1994-10-14)
                },
                new Movie
                {
                    Id = 2,
                    Name = "这个杀手不太冷 Léon ",
                    Company = "法国",
                    MovieRating = MovieRating.NC17,
                    ActorId = 2,
                    ReleaseDate = new DateTime(1994-09-14)
                },
                new Movie
                {
                    Id = 3,
                    Name = "三傻大闹好莱坞",
                    Company = "印度",
                    MovieRating = MovieRating.PG,
                    ActorId = 3,
                    ReleaseDate = new DateTime(2011-12-08)
                },
                new Movie
                {
                    Id = 4,
                    Name = "功夫",
                    Company = "美国",
                    MovieRating = MovieRating.G,
                    ActorId = 4,
                    ReleaseDate = new DateTime(2004-12-23)
                }
                #endregion
            };
        }


        public Task<Movie> CreateAsync(Movie movie)
        {
            _movie.Add(movie);

            //创建时发布事件
            var movieEvent = new MovieEvent
            {
                Name = $"Add Movie",
                MovieId = movie.Id,
                MovieRating = movie.MovieRating,
                TimeStamp = DateTime.Now
            };
            _movieEventService.AddEvent(movieEvent);

            return Task.FromResult(movie);
        }

        public Task<IEnumerable<Movie>> GetAsyncs()
        {
            return Task.FromResult(_movie.AsEnumerable());
        }

        public Task<Movie> GetByIdAsync(int id)
        {
            //在这里需要做个判断这个id是否存在
            var movie = _movie.SingleOrDefault(x => x.Id == id);
            if (movie == null)
            {
                throw new ArgumentException(String.Format("Movie ID {0} 不正确", id));
            }

            return Task.FromResult(movie);
        }
    }
}
