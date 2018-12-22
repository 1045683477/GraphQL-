using GraphQL.Types;
using GraphStudy.Movies.Movies;

namespace GraphStudy.Movies.Schema
{
    public class MovieInputType:InputObjectGraphType<MovieInput>
    {
        public MovieInputType()
        {
            Name = "MovieInput";

            Field(x => x.Name);
            Field(x => x.ActorId);
            Field(x => x.Company);
            Field(x => x.ReleaseDate);
            Field(x => x.MovieRating,type:typeof(MovieRatingEnum));
        }
    }
}
