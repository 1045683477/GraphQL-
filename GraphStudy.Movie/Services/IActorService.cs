using GraphStudy.Movies.Movies;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphStudy.Movies.Services
{
    public interface IActorService
    {
        Task<Actor> GetByIdAsync(int id);//获取某个演员信息
        Task<IEnumerable<Actor>> GetAsync();//获取所有演员信息
    }
}
