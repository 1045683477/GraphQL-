using GraphQL.Types;
using GraphStudy.Movies.Services;

namespace GraphStudy.Movies.Schema
{
    //查询
    public class MoviesQuery:ObjectGraphType
    {
        public MoviesQuery(IMovieService movieService)
        {
            Name = "Query";

            //查询所有Movie
            Field<ListGraphType<MovieType>>("movies", resolve: context => movieService.GetAsyncs());
        }
    }
}
