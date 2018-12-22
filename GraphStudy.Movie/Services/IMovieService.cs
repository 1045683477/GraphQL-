using GraphStudy.Movies.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphStudy.Movies.Services
{
    public interface IMovieService
    {
        Task<IEnumerable<Movie>> GetAsyncs();//获取所有电影信息
        Task<Movie> GetByIdAsync(int id);//获取某个对应id属性的电影信息
        Task<Movie> CreateAsync(Movie movie);//创建电影信息
    }
}
