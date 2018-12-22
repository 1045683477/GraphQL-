using GraphQL.Types;
using GraphStudy.Movies.Movies;
using GraphStudy.Movies.Services;
using System.Linq;

namespace GraphStudy.Movies.Schema
{
    public class MoviesMutation:ObjectGraphType
    {
        public MoviesMutation(IMovieService movieService)
        {
            Name = "Mutation";

            //返回类型为MovieType，所以Field<MovieType>
            FieldAsync<MovieType> 
            (
                "createMovie",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<MovieInputType>>
                {
                    Name = "movie"//注意此处无需标点符号，不然会出错
                }),
                resolve: async context =>
                {
                    var movieInput = context.GetArgument<MovieInput>("movie");//此处movie的字应该与arguments里面的Name字一样
                    //用异步处理下面Id自增
                    var movies = await movieService.GetAsyncs();
                    var maxId = movies.Select(x => x.Id).Max();

                    var movie = new Movie
                    {
                        Id = ++maxId,
                        Name = movieInput.Name,
                        Company = movieInput.Company,
                        ActorId = movieInput.ActorId,
                        MovieRating = movieInput.MovieRating,
                        ReleaseDate = movieInput.ReleaseDate
                    };
                    var result = await movieService.CreateAsync(movie);
                    return result;
                }
            );
        }
    }
}
